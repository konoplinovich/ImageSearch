using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileCollector.Test
{
    [TestClass]
    public class FileCollectorTest
    {
        const string BasePath = @"w:\dev\workspace\Developed\ImageSearch\TestData\";
        Collector collector = new Collector(Path.Combine(BasePath, "New"));

        [TestInitialize]
        public void DeleteFolder()
        {
            if (Directory.Exists(Path.Combine(BasePath, "new")))
                Directory.Delete(Path.Combine(BasePath, "new"), true);
            Directory.CreateDirectory(Path.Combine(BasePath, "new"));
        }

        [TestMethod]
        public void AddSameFileTwice()
        {
            collector.Add(Path.Combine(BasePath, "1", "AA007-123456.tif"));
            collector.Add(Path.Combine(BasePath, "2", "AA007-123456.tif"));

            string newName1 = collector.GetCopyByOriginal(Path.Combine(BasePath, "1", "AA007-123456.tif"));
            string newName2 = collector.GetCopyByOriginal(Path.Combine(BasePath, "2", "AA007-123456.tif"));

            Assert.AreEqual(Path.Combine(BasePath, "New", "AA007-123456.tif"), newName1);
            Assert.AreEqual(Path.Combine(BasePath, "New", "AA007-123456-1.tif"), newName2);
        }
    }
}
