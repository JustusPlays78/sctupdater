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
using SCTUpdater;
using static SCTUpdater.Strings;
using System.Text.Json;

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
            Customsettings();
        }

        private static void Customsettings()
        {
            Paths costumpath = ImportPaths();
            if (costumpath.CustomJsonPath == null)
            {
                costumpath.CustomJsonPath = Directory.GetCurrentDirectory() + "\\customsettings.json";
                return;
            }
            if (File.Exists(costumpath.CustomJsonPath))
            {
                //TODO
                return;
            }

            CustomJsonVariables defaultvariable = new CustomJsonVariables()
            {
                Settings = new List<Setting>()
            };

            string JsonResultpath = JsonSerializer.Serialize(defaultvariable, new JsonSerializerOptions { WriteIndented = true });

            using (var tw = new StreamWriter(costumpath.CustomJsonPath))
            {
                tw.WriteLine(JsonResultpath);
                tw.Close();
            }
        }

        /*Cheks if Config.json exists*/
        private static bool CheckConfigJson() => File.Exists(Directory.GetCurrentDirectory() + @"\config.json");
        

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
                 CustonJsonPathwjson = null,
             };

            string JsonResultpath = JsonSerializer.Serialize(ConfigcsPath, new JsonSerializerOptions { WriteIndented = true });

            using var tw = new StreamWriter(ConfigPathcreate);
            tw.WriteLine(JsonResultpath);
            tw.Close();

            //File.WriteAllText(Directory.GetCurrentDirectory() + @"\config.json", JsonResult);
        }


        public static Paths ImportPaths()
        {
            StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + "\\config.json");
            string JsonOutputPath = reader.ReadLine();
            reader.Close();


            Paths Mainpath = JsonSerializer.Deserialize<Paths>(JsonOutputPath);

            return Mainpath;
        }




        public static void SetSctPath(string Path)
        {
            StreamReader streamReader = new StreamReader(ConfigcsPath.ConfigPath);

            string Line1 = streamReader.ReadLine();
            streamReader.Close();

            Paths Json = JsonSerializer.Deserialize<Paths>(Line1);

            Paths newPaths = new Paths
            {
                SctPath = Path,
                ConfigPath = Json.ConfigPath,
                CredentialsPath = Json.CredentialsPath,
                CustomJsonPath = Json.CustomJsonPath,
                CustonJsonPathwjson = Json.CustonJsonPathwjson,
            };

            string line1Edited = JsonSerializer.Serialize(newPaths, new JsonSerializerOptions { WriteIndented = true});


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

            Paths Json = JsonSerializer.Deserialize<Paths>(Line1);

            Paths newPaths = new Paths
            {
                SctPath = Json.SctPath,
                ConfigPath = Json.ConfigPath,
                CredentialsPath = Json.CredentialsPath,
                CustomJsonPath = Path + "\\customsettings.json",
                CustonJsonPathwjson = Path,
            };

            string line1Edited = JsonSerializer.Serialize(newPaths, new JsonSerializerOptions { WriteIndented = true});


            StreamWriter writer = new StreamWriter(ConfigcsPath.ConfigPath);
            writer.WriteLine(line1Edited);
            writer.Close();

        }

        public static void SetCredentialsPath(string Path)
        {
            var path = ConfigcsPath.ConfigPath;

            if(path == null)
            {
                throw new Exception();
            }

            StreamReader streamReader = new StreamReader(path);

            string Line1 = streamReader.ReadLine() ?? throw new Exception();

            Paths Json = JsonSerializer.Deserialize<Paths>(Line1) ?? throw new Exception("Paths nix gut");


            Paths newPaths = new Paths
            {
                SctPath = Json.SctPath,
                ConfigPath = Json.ConfigPath,
                CredentialsPath = Path,
                CustomJsonPath = Json.CustomJsonPath,
                CustonJsonPathwjson = Json.CustonJsonPathwjson,
            };

            string line1Edited = JsonSerializer.Serialize(newPaths, new JsonSerializerOptions { WriteIndented = true });

            StreamWriter writer = new StreamWriter(ConfigcsPath.ConfigPath);
            writer.WriteLine(line1Edited);
            writer.Close();
        }

        private static List<string> GetTopskyFolders(string path)
        {
            List<string> topskyFolders = new List<string>();
            var AllPluginDlls = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories);

            topskyFolders = AllPluginDlls.Where(x => Path.GetFileNameWithoutExtension(x) == "TopSky").Select(y => Path.GetDirectoryName(y)).ToList();
            //foreach (var plugin in AllPluginDlls)
            //{
            //    var pluginName = Path.GetFileNameWithoutExtension(plugin);
            //    if (pluginName == "TopSky")
            //    {
            //        string topskyDirectory = Path.GetDirectoryName(plugin);
            //        topskyFolders.Add(topskyDirectory);
            //    }
            //}

            if(topskyFolders.Count == 0)
            {
                return Enumerable.Empty<string>().ToList();
            }

            return topskyFolders;
        }

        private static void RenderTopskyFoldersPanel(List<string> topskyFolders)
        {
            var textBox = Main.DebugBox;

            StringBuilder stringBuilder = new StringBuilder();

            topskyFolders.ForEach(x => stringBuilder.AppendLine(x));

            textBox.Text = stringBuilder.ToString();
        }
    }
}