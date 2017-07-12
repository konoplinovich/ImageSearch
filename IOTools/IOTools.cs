using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IOTools
{
    public class IOHelper
    {
        private string m_path;
        private IProgress<string> m_progress;
        private List<string> m_dirs;
        private ConcurrentStack<string> m_files;
        private Dictionary<string, string> m_errors;

        public List<string> FileList { get { return new List<string>(m_files); } }
        public List<string> DirectoryList { get { return m_dirs; } }
        public Dictionary<string, string> ErrorList { get { return m_errors; } }
        public string Path { get { return m_path; } }

        public IOHelper(string path, IProgress<string> progress)
        {
            m_path = path;
            m_progress = progress;
        }

        public async Task<List<string>> TraverseTreeAsync()
        {
            m_dirs = new List<string>();
            m_files = new ConcurrentStack<string>();
            m_errors = new Dictionary<string, string>();

            await AddFilesToList(m_path);
            await GetDirectoriesTree(m_path, m_progress);
            return new List<string>(m_files);
        }

        public Task<List<string>> GetFilesAsync(string path)
        {
            var tcs = new TaskCompletionSource<List<string>>();

            string[] files;
            try
            {
                files = Directory.GetFiles(path);
                tcs.SetResult(new List<string>(files));
            }
            catch (Exception e)
            {
                tcs.SetException(e);
                AddError(e.Message);
            }

            return tcs.Task;
        }

        public Task<List<string>> GetDirectoriesAsync(string path)
        {
            var tcs = new TaskCompletionSource<List<string>>();

            string[] dirs;
            try
            {
                dirs = Directory.GetDirectories(path);
                tcs.SetResult(new List<string>(dirs));
            }
            catch (Exception e)
            {
                tcs.SetException(e);
                AddError(e.Message);
            }

            return tcs.Task;
        }

        private async Task GetDirectoriesTree(string path, IProgress<string> progress)
        {
            if (!m_dirs.Contains(path)) m_dirs.Add(path);

            try
            {
                var directories = await GetDirectoriesAsync(path);

                foreach (var dir in directories)
                {
                    await GetDirectoriesTree(dir, progress);
                    if (!m_dirs.Contains(path)) m_dirs.Add(path);
                    await AddFilesToList(dir);
                    progress?.Report(dir);
                }
            }
            catch (Exception e) { AddError(e.Message); }
        }

        private async Task AddFilesToList(string dir)
        {
            try
            {
                List<string> dirfiles = await GetFilesAsync(dir);
                if (dirfiles.Count != 0)
                {
                    foreach (string f in dirfiles) m_files.Push(f);
                }
            }
            catch (IOException e) { AddError(e.Message); }
            catch (UnauthorizedAccessException e) { AddError(e.Message); }
        }

        private void AddError(string msg)
        {
            string part = Regex.Match(msg, @"(?<=').*?(?=')").Value;
            if (string.IsNullOrEmpty(part)) return;
            if (!m_errors.ContainsKey(part)) m_errors[part] = msg;
        }
    }
}