using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using IOTools;
using System.Threading.Tasks;

namespace ImageIndex
{
    public class Index
    {
        readonly string IndexPattern = @"(\d{4,})";
        IProgress<string> m_progress;
        List<string> paths;
        List<string> files;
        Dictionary<string, List<string>> mainIndex = new Dictionary<string, List<string>>();

        public int FilesCount { get { return files.Count; } }
        public int IndexCount { get { return mainIndex.Keys.Count; } }
        public string Pattern { get { return IndexPattern; } }

        public Index(IProgress<string> progress = null)
        {
            paths = new List<string>();
            files = new List<string>();
            m_progress = progress;
        }

        public async Task Add(string path)
        {
            if (!Directory.Exists(path)) return;
            if (files.Contains(path)) return;
            await Building(path);
        }

        public Index(string filename)
        {
            Load(filename);
        }

        public void Save(string filename)
        {
            List<string> pathsToSave = new List<string>();
            pathsToSave.Add("[Paths]");
            pathsToSave.AddRange(paths);
            File.WriteAllLines(filename, pathsToSave);

            List<string> filesToSave = new List<string>();
            filesToSave.Add("[Files]");

            foreach (string file in files)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"{file};");

                if (mainIndex.ContainsKey(file))
                {
                    foreach (var keyword in mainIndex[file])
                    {
                        sb.Append($"{keyword};");
                    }
                }

                filesToSave.Add(sb.ToString());
            }

            File.AppendAllLines(filename, filesToSave);
        }

        public int GetImageKeywordsCount(string filename)
        {
            if (mainIndex.ContainsKey(filename)) return mainIndex[filename].Count;
            else return -1;
        }

        public List<string> GetImageKeywords(string filename)
        {
            if (mainIndex.ContainsKey(filename)) return mainIndex[filename];
            else return null;
        }

        public List<string> Search(string pattern)
        {
            var list = new List<string>();

            foreach (var kv in mainIndex)
            {
                if (kv.Value.Contains(pattern)) list.Add(kv.Key);
            }

            if (list.Count == 0 || list.Count == 1) return list;
            else
            {
                Dictionary<string, DateTime> filesWithDates = new Dictionary<string, DateTime>();

                foreach (string file in list)
                {
                    filesWithDates.Add(file, File.GetLastWriteTime(file));
                }

                List<DateTime> dates = filesWithDates.Values.ToList();
                dates.Sort();

                foreach (var date in filesWithDates)
                {
                    if (date.Value == dates[dates.Count - 1]) return new List<string> { date.Key };
                }
            }

            return list;
        }

        private void Load(string filename)
        {
            paths = new List<string>();
            files = new List<string>();

            string[] lines = File.ReadAllLines(filename);

            int pathSection = 0;
            int fileSection = 0;
            string[] separator = { ";" };

            for (int i = 0; i < lines.Length; i++)
            {
                string s = lines[i];

                int searchPath = s.IndexOf("[Paths]");
                if (searchPath != -1) pathSection = i + 1;

                int searchFile = s.IndexOf("[Files]");
                if (searchFile != -1) fileSection = i + 1;
            }

            for (int i = pathSection; i < fileSection - 1; i++) paths.Add(lines[i]);

            for (int i = fileSection; i < lines.Length; i++)
            {
                string[] splited = lines[i].Split(separator, StringSplitOptions.RemoveEmptyEntries);

                string key = splited[0];

                List<string> values = new List<string>();
                for (int x = 1; x < splited.Length; x++)
                {
                    values.Add(splited[x]);
                }

                mainIndex[key] = values;
                files.Add(key);
            }
        }

        private async Task Building(string path)
        {
            IOHelper helper = new IOHelper(path, m_progress);
            await helper.TraverseTreeAsync();
            List<string> filesForIndexing = helper.FileList;

            Regex regex = new Regex(IndexPattern);

            foreach (string f in filesForIndexing)
            {
                List<string> matches = new List<string>();

                foreach (Match match in regex.Matches(f))
                {
                    matches.Add(match.Groups[1].Value);
                }

                if (matches.Count != 0) mainIndex[f] = matches;
            }

            files.AddRange(filesForIndexing);
        }
    }
}
