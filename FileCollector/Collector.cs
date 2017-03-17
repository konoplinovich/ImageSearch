using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileCollector
{
    public class Collector
    {
        private string baseFolder;
        private Dictionary<string, string> filesMap;

        public string Base { get { return baseFolder; } }

        public Collector(string folder)
        {
            if (Directory.Exists(folder)) baseFolder = folder;
            filesMap = new Dictionary<string, string>();
        }

        public int Count { get { return filesMap.Keys.Count; } }

        public void Add(string oldFullPath)
        {
            if (!File.Exists(oldFullPath)) return;
            if (filesMap.ContainsKey(oldFullPath)) return;

            FileInfo file = new FileInfo(oldFullPath);
            string fileName = file.Name;
            string ext = file.Extension;

            int filesCount = FilesCount(fileName);

            if (filesCount != 0)
            {
                string fileNameWithoutExt = fileName.Replace(ext, "");
                fileName = $"{fileNameWithoutExt}-{filesCount}{ext}";
            }

            string newFullPath = Path.Combine(baseFolder, fileName);

            filesMap[oldFullPath] = newFullPath;
        }

        public async Task<int> Copy(IProgress<Tuple<string, string, int, int>> progress)
        {
            int count = 0;
            int totalCount = filesMap.Keys.Count;

            foreach (KeyValuePair<string, string> kv in filesMap)
            {
                DateTime modify = File.GetLastWriteTime(kv.Key);

                using (FileStream SourceStream = File.Open(kv.Key, FileMode.Open))
                {
                    using (FileStream DestinationStream = File.Create(kv.Value))
                    {
                        await SourceStream.CopyToAsync(DestinationStream);
                    }
                }

                count++;
                File.SetLastWriteTime(kv.Value, modify);

                progress.Report(new Tuple<string, string, int, int>(kv.Key, kv.Value, totalCount, count));
            }

            return count;
        }

        public string GetCopyByOriginal(string fullName)
        {
            return filesMap[fullName];
        }

        private int FilesCount(string fileName)
        {
            int index = 0;
            foreach (KeyValuePair<string, string> kv in filesMap)
            {
                if (kv.Value.IndexOf(fileName) != -1) index++;
            }

            return index;
        }
    }
}