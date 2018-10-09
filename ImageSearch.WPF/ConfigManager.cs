using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ImageSearch.WPF
{
    public sealed class ConfigManager
    {
        public sealed class Config
        {
            private string imageRoot = @"w:\!ЭССЕН\ПРОМО\";
            private string noImageStub = @"w:\!ЭССЕН\!ОБЩАЯ\NoImages.tif";
            private string pattern = @"\d{4,}";

            public string ImageRoot { get => imageRoot; set => imageRoot = value; }
            public string NoImageStub { get => noImageStub; set => noImageStub = value; }
            public string Pattern { get => pattern; set => pattern = value; }
        }

        public enum LoadStatus { Loaded, LoadedDefault };

        private static Config conf;
        private static string configFileName;

        public Config Conf { get { return conf; } }

        public ConfigManager(string configFileName)
        {
            ConfigManager.configFileName = configFileName;
            conf = new Config();
        }

        public void SaveConfig()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            TextWriter writer = new StreamWriter(configFileName);
            serializer.Serialize(writer, conf);
            writer.Close();
        }

        public LoadStatus LoadConfig()
        {
            if (!File.Exists(configFileName))
            {
                SaveConfig();
                return LoadStatus.LoadedDefault;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            TextReader reader = new StreamReader(configFileName);
            conf = (Config)serializer.Deserialize(reader);
            reader.Close();

            return LoadStatus.Loaded;
        }

        public override string ToString()
        {
            return string.Format("[ConfigManager] ImageRoot: {0}, NoImageStub: {1}",
                                   conf.ImageRoot, conf.NoImageStub);
        }
    }
}
