using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileCollector;

namespace ImageSearch.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            p.AddSameFileTwice();
            Console.ReadLine();
        }

        const string BasePath = @"w:\dev\workspace\Developed\ImageSearch\TestData\";
        Collector collector = new Collector(Path.Combine(BasePath, "New"));

        public void DeleteFolder()
        {
            //if (Directory.Exists(Path.Combine(BasePath, "New")))
            //    Directory.Delete(Path.Combine(BasePath, "New"), true);
            //Directory.CreateDirectory(Path.Combine(BasePath, "New"));
        }

        public async void AddSameFileTwice()
        {
            collector.Add(Path.Combine(BasePath, "1", "AA007-123456.tif"));
            collector.Add(Path.Combine(BasePath, "2", "AA007-123456.tif"));

            var progress = new Progress<Tuple<string, string, int, int>>(Report);

            int count = await collector.Copy(progress);
            Console.WriteLine(count);

            string newName1 = collector.GetCopyByOriginal(Path.Combine(BasePath, "1", "AA007-123456.tif"));
            string newName2 = collector.GetCopyByOriginal(Path.Combine(BasePath, "2", "AA007-123456.tif"));
        }

        public void Report(Tuple<string, string, int, int> msg)
        {
            Console.WriteLine($"{msg.Item1} -> {msg.Item2}");
        }
    }
}

