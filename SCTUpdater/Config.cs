using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using SCTUpdater;
using static SCTUpdater.Strings;

namespace SCTUpdater
{
    internal class Config : HomePage
    {
        public static Paths ConfigcsPath;

        /*Checks if...
         ...Config.json exists,
         if yes, then nothing
         if no, then it creates a config.json*/
        public static void StartupChecks()
        {

            if (CheckConfigJson() == false)
            {
                CreateConfigJson();
                ConfigcsPath = ImportPaths();
            }

            ConfigcsPath = ImportPaths();
        }

        /*Cheks if Config.json exists*/
        private static bool CheckConfigJson()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\config.json"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*Sets the path to currentdirectory
         Therafter opens method to set defaultconfigvariables(later via download)
        Thereafter sets the Objects*/
        private static void CreateConfigJson()
        {
             string ConfigPathcreate = Directory.GetCurrentDirectory() + "\\config.json";
             ConfigcsPath = new Paths()
             {
                 ConfigPath = ConfigPathcreate,
                 SctPath = null,
                 CredentialsPath = Directory.GetCurrentDirectory() + "\\credentials.json",
                 CustomJsonPath = null,
             };

            string JsonResultpath = JsonConvert.SerializeObject(ConfigcsPath);

            using (var tw = new StreamWriter(ConfigPathcreate))
            {
                tw.WriteLine(JsonResultpath);
                tw.Close();
            }

            //File.WriteAllText(Directory.GetCurrentDirectory() + @"\config.json", JsonResult);

        }


        public static Paths ImportPaths()
        {
            StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + "\\config.json");
            string JsonOutputPath = reader.ReadLine();
            reader.Close();


            Paths Mainpath = JsonConvert.DeserializeObject<Paths>(JsonOutputPath);

            return Mainpath;
        }




        public static void SetSctPath(string Path)
        {
            StreamReader streamReader = new StreamReader(ConfigcsPath.ConfigPath);

            string Line1 = streamReader.ReadLine();
            streamReader.Close();

            Paths Json = JsonConvert.DeserializeObject<Paths>(Line1);

            Paths newPaths = new Paths
            {
                SctPath = Path,
                ConfigPath = Json.ConfigPath,
                CredentialsPath = Json.CredentialsPath,
                CustomJsonPath = Json.CustomJsonPath,
            };

            string line1Edited = JsonConvert.SerializeObject(newPaths);


            StreamWriter writer = new StreamWriter(ConfigcsPath.ConfigPath);
            writer.WriteLine(line1Edited);
            writer.Close();

            List<string> topskyFolders = GetTopskyFolders(Path);
            RenderTopskyFoldersPanel(topskyFolders);

        }
        public static void SetJsonPath(string Path)
        {
            StreamReader streamReader = new StreamReader(ConfigcsPath.ConfigPath);

            string Line1 = streamReader.ReadLine();
            streamReader.Close();

            Paths Json = JsonConvert.DeserializeObject<Paths>(Line1);

            Paths newPaths = new Paths
            {
                SctPath = Json.SctPath,
                ConfigPath = Json.ConfigPath,
                CredentialsPath = Json.CredentialsPath,
                CustomJsonPath = Path,
            };

            string line1Edited = JsonConvert.SerializeObject(newPaths);


            StreamWriter writer = new StreamWriter(ConfigcsPath.ConfigPath);
            writer.WriteLine(line1Edited);
            writer.Close();

        }

        public static void SetCredentialsPath(string Path)
        {
            StreamReader streamReader = new StreamReader(ConfigcsPath.ConfigPath);

            string Line1 = streamReader.ReadLine();

            Paths Json = JsonConvert.DeserializeObject<Paths>(Line1);


            Paths newPaths = new Paths
            {
                SctPath = Json.SctPath,
                ConfigPath = Json.ConfigPath,
                CredentialsPath = Path,
                CustomJsonPath = Json.CustomJsonPath,
            };

            string line1Edited = JsonConvert.SerializeObject(newPaths);

            StreamWriter writer = new StreamWriter(ConfigcsPath.ConfigPath);
            writer.WriteLine(line1Edited);
            writer.Close();
        }

        private static List<string> GetTopskyFolders(string path)
        {
            List<string> topskyFolders = new List<string>();
            var AllPluginDlls = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories);

            foreach (var plugin in AllPluginDlls)
            {
                var pluginName = System.IO.Path.GetFileNameWithoutExtension(plugin);
                if (pluginName == "TopSky")
                {
                    string topskyDirectory = Path.GetDirectoryName(plugin);
                    topskyFolders.Add(topskyDirectory);
                }
            }

            return topskyFolders;
        }

        private static void RenderTopskyFoldersPanel(List<string> topskyFolders)
        {
            var textBox = Main.DebugBox;

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var folder in topskyFolders)
            {
                stringBuilder.AppendLine(folder);
            }

            textBox.Text = stringBuilder.ToString();
        }
    }
}