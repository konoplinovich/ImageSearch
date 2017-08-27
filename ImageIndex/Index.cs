using IOTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ImageIndex
{
    public class Index
    {
        const string DefaultPattern = @"\d{4,}";
        string m_indexPattern;
        IProgress<string> m_progress;
        List<string> m_paths;
        List<string> m_files;
        Dictionary<string, List<string>> m_mainIndex = new Dictionary<string, List<string>>();
        private Dictionary<string, string> m_errors = new Dictionary<string, string>();

        public int FilesCount { get { return m_files.Count; } }
        public int IndexCount { get { return m_mainIndex.Keys.Count; } }
        public Dictionary<string, List<string>> IndexDictionary { get { return m_mainIndex; } }
        public Dictionary<string, string> ErrorDictionary { get { return m_errors; } }
        public string Pattern
        {
            get { return m_indexPattern; }
            set
            {
                try { Regex regex = new Regex(value); }
                catch (Exception ex) { throw ex; }
                m_indexPattern = value;
            }
        }

        public Index(IProgress<string> progress = null)
        {
            m_paths = new List<string>();
            m_files = new List<string>();
            m_progress = progress;
            m_indexPattern = DefaultPattern;
        }

        public async Task Add(string path)
        {
            if (!Directory.Exists(path)) return;
            if (m_files.Contains(path)) return;
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
            pathsToSave.AddRange(m_paths);
            File.WriteAllLines(filename, pathsToSave);

            List<string> filesToSave = new List<string>();
            filesToSave.Add("[Files]");

            foreach (string file in m_files)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"{file};");

                if (m_mainIndex.ContainsKey(file))
                {
                    foreach (var keyword in m_mainIndex[file])
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
            if (m_mainIndex.ContainsKey(filename)) return m_mainIndex[filename].Count;
            else return -1;
        }

        public List<string> GetImageKeywords(string filename)
        {
            if (m_mainIndex.ContainsKey(filename)) return m_mainIndex[filename];
            else return null;
        }

        public List<string> Search(string pattern)
        {
            var list = new List<string>();

            foreach (var kv in m_mainIndex)
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
            m_paths = new List<string>();
            m_files = new List<string>();

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

            for (int i = pathSection; i < fileSection - 1; i++) m_paths.Add(lines[i]);

            for (int i = fileSection; i < lines.Length; i++)
            {
                string[] splited = lines[i].Split(separator, StringSplitOptions.RemoveEmptyEntries);

                string key = splited[0];

                List<string> values = new List<string>();
                for (int x = 1; x < splited.Length; x++)
                {
                    values.Add(splited[x]);
                }

                m_mainIndex[key] = values;
                m_files.Add(key);
            }
        }

        private async Task Building(string path)
        {
            IOHelper helper = new IOHelper(path, m_progress);
            await helper.TraverseTreeAsync();
            List<string> filesForIndexing = helper.FileList;
            m_errors.AddRange(helper.ErrorList);

            Regex regex = new Regex(m_indexPattern);

            foreach (string f in filesForIndexing)
            {
                List<string> matches = new List<string>();

                string filename = Path.GetFileName(f);

                foreach (Match match in regex.Matches(filename))
                {
                    matches.Add(match.Groups[0].Value);
                }

                if (matches.Count != 0) m_mainIndex[f] = matches;
            }

            m_files.AddRange(filesForIndexing);
        }
    }
}
