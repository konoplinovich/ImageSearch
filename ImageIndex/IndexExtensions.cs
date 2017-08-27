using System.Collections.Generic;

namespace ImageIndex
{
    static class IndexExtensions
    {
        public static void AddRange(this Dictionary<string, string> target, Dictionary<string, string> source)
        {
            foreach (KeyValuePair<string, string> kv in source)
            {
                if (!target.ContainsKey(kv.Key)) target.Add(kv.Key, kv.Value);
            }
        }
    }
}
