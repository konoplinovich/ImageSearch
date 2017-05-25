using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageIndex.Test
{
    [TestClass]
    public class ImageIndexTest
    {
        const string BasePath = @"s:\dev\!tests\test1\";
        string[] testPaths = { Path.Combine(BasePath, "1"), Path.Combine(BasePath, "2") };

        private Index MakeIndex()
        {
            Index index = new Index();

            foreach (string path in testPaths)
            {
                index.Add(path);
            }

            return index;
        }

        [TestMethod]
        public void getFilesCount()
        {
            Index index = MakeIndex();

            Assert.AreEqual(12, index.FilesCount);
        }

        [TestMethod]
        public void getIndexCount()
        {
            Index index = MakeIndex();

            Assert.AreEqual(6, index.IndexCount);
        }

        [TestMethod]
        public void getFileKeywordsCount()
        {
            Index index = MakeIndex();

            int count1 = index.GetImageKeywordsCount(Path.Combine(BasePath, "1","AA007-123456.tif"));
            int count2 = index.GetImageKeywordsCount(Path.Combine(BasePath, "1", "AA011-x12345-x123456.tif")); 
            int count3 = index.GetImageKeywordsCount(@"w:\AA011-x12345-x123456.tif");

            Assert.AreEqual(1, count1);
            Assert.AreEqual(2, count2);
            Assert.AreEqual(-1, count3);
        }

        [TestMethod]
        public void getFileKeywords()
        {
            Index index = MakeIndex();

            List<string> key1 = index.GetImageKeywords(Path.Combine(BasePath, "1", "AA007-123456.tif"));
            List<string> key2 = index.GetImageKeywords(Path.Combine(BasePath, "1", "AA011-x12345-x123456.tif"));
            List<string> key3 = index.GetImageKeywords(@"w:\AA011-x12345-x123456.tif");

            Assert.AreEqual("123456", key1[0]);
            Assert.AreEqual("12345", key2[0]);
            Assert.AreEqual("123456", key2[1]);
            Assert.AreEqual(null, key3);
        }

        [TestMethod]
        public void Search()
        {
            Index index = MakeIndex();

            List<string> s1 = index.Search("1234");
            List<string> s2 = index.Search("12345");
            List<string> s3 = index.Search("123");
            List<string> s4 = index.Search("123456");

            Assert.AreEqual(1, s1.Count);
            Assert.AreEqual(1, s2.Count);
            Assert.AreEqual(0, s3.Count);
            Assert.AreEqual(1, s4.Count);
        }

        [TestMethod]
        public void SaveAndLoad()
        {
            Index index = MakeIndex();
            int oldCount = index.FilesCount;
            index.Save(@"paths.txt");

            index = new Index(@"paths.txt");
            int newCount = index.FilesCount;
            List<string> key1 = index.GetImageKeywords(Path.Combine(BasePath, "1", "AA011-x12345-x123456.tif"));
            List<string> key2 = index.GetImageKeywords(Path.Combine(BasePath, "2", "AA011-x12345-x123456.tif"));

            Assert.AreEqual("12345", key1[0]);
            Assert.AreEqual("123456", key2[1]);
            Assert.AreEqual(oldCount, newCount);
        }
    }
}
