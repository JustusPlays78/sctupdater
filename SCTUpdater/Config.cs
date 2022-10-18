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
    internal class Config
    {
        public static Paths ConfigcsPath;

        /*Checks if...
         ...Config.json exists,
         if yes, then nothing
         if no, then it creates a config.json*/
        public static void StartupChecks()
        {
            ConfigcsPath = ImportPaths();


            if (CheckConfigJson() == false)
            {
                CreateConfigJson();
            }
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
             string ConfigPath = Directory.GetCurrentDirectory() + "\\config.json";

            string JsonResultpath = JsonConvert.SerializeObject(ConfigPath);

            using (var tw = new StreamWriter(Directory.GetCurrentDirectory() + @"\config.json"))
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
            };

            string line1Edited = JsonConvert.SerializeObject(newPaths);

            StreamWriter writer = new StreamWriter(ConfigcsPath.ConfigPath);
            writer.WriteLine(line1Edited);
            writer.Close();
        }


    }
}