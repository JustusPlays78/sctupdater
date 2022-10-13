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
using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using SCTUpdater;
using static SCTUpdater.Strings;

namespace SCTUpdater
{
    internal class Config
    {

        public static Paths DefaultPath = new Paths();
        public static EDGGProfiles DefaultEdgg = new EDGGProfiles();
        public static EDWWProfiles DefaultEdww = new EDWWProfiles();
        public static EDMMProfiles DefaultEdmm = new EDMMProfiles();

        /*Checks if...
         ...Config.json exists,
         if yes, then nothing
         if no, then it creates a config.json*/
        public static void StartupChecks()
        {
            SetDefaultConfigVariables();


            if (CheckConfigJson() == false)
            {
                CreateConfigJson();
            }
            ImportConfigJson();
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
            DefaultPath.ConfigPath = Directory.GetCurrentDirectory();

            string JsonResultpath = JsonConvert.SerializeObject(DefaultPath);
            string JsonResultEdgg= JsonConvert.SerializeObject(DefaultEdgg);
            string JsonResultEdww = JsonConvert.SerializeObject(DefaultEdww);
            string JsonResultEdmm = JsonConvert.SerializeObject(DefaultEdmm);

            using (var tw = new StreamWriter(Directory.GetCurrentDirectory() + @"\config.json"))
            {
                tw.WriteLine(JsonResultpath);
                tw.WriteLine(JsonResultEdgg);
                tw.WriteLine(JsonResultEdww);
                tw.WriteLine(JsonResultEdmm);
                tw.Close();
            }

            //File.WriteAllText(Directory.GetCurrentDirectory() + @"\config.json", JsonResult);

        }

        /*Importiert die ConfigJson in die Main... Objekte, die dann nutzbar sind*/
        public static void ImportConfigJson()
        {
            StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + @"\config.json");
            string JsonOutputPath = reader.ReadLine();
            string JsonOutputEdgg = reader.ReadLine();
            string JsonOutputEdww = reader.ReadLine();
            string JsonOutputEdmm = reader.ReadLine();
            reader.Close();

            //string JsonOutput = System.IO.File.ReadAllText(Directory.GetCurrentDirectory() + @"\config.json");
            //reader.Close();

            Variable.Mainpath = JsonConvert.DeserializeObject<Paths>(JsonOutputPath);
            Variable.MainEdggProfile = JsonConvert.DeserializeObject<EDGGProfiles>(JsonOutputEdgg);
            Variable.MainEdwwProfile = JsonConvert.DeserializeObject<EDWWProfiles>(JsonOutputEdww);
            Variable.MainEdmmProfile = JsonConvert.DeserializeObject<EDMMProfiles>(JsonOutputEdmm);

            //ConfigClass ?Config = JsonConvert.DeserializeObject<ConfigClass>(JsonOutput);


            if (IsSctPathSet)
            { 
                
                
                //EDGG
                Variable.MainEdggProfile.PheonixTwr = Variable.Mainpath.SctPath + Variable.MainEdggProfile.PheonixTwr;
                Variable.MainEdggProfile.Edgg = Variable.Mainpath.SctPath + Variable.MainEdggProfile.Edgg;
                Variable.MainEdggProfile.Eduu = Variable.Mainpath.SctPath + Variable.MainEdggProfile.Eduu;
                Variable.MainEdggProfile.EddfApn = Variable.Mainpath.SctPath + Variable.MainEdggProfile.EddfApn;
                Variable.MainEdggProfile.Alternate = Variable.Mainpath.SctPath + Variable.MainEdggProfile.Alternate;
                Variable.MainEdggProfile.AlternateGrp = Variable.Mainpath.SctPath + Variable.MainEdggProfile.AlternateGrp;

                //EDWW
                Variable.MainEdwwProfile.EdbbAppCtr = Variable.Mainpath.SctPath + Variable.MainEdwwProfile.EdbbAppCtr;
                Variable.MainEdwwProfile.EdwwAppCtr = Variable.Mainpath.SctPath + Variable.MainEdwwProfile.EdwwAppCtr;
                Variable.MainEdwwProfile.EdbbTwr = Variable.Mainpath.SctPath + Variable.MainEdwwProfile.EdbbTwr;
                Variable.MainEdwwProfile.EdwwTwr = Variable.Mainpath.SctPath + Variable.MainEdwwProfile.EdwwTwr;
                Variable.MainEdwwProfile.EduuCtr = Variable.Mainpath.SctPath + Variable.MainEdwwProfile.EduuCtr;
                Variable.MainEdwwProfile.EdyyCtr = Variable.Mainpath.SctPath + Variable.MainEdwwProfile.EdyyCtr;

                //EDMM
                Variable.MainEdmmProfile.Edmm = Variable.Mainpath.SctPath + Variable.MainEdmmProfile.Edmm;
                Variable.MainEdmmProfile.Eduu = Variable.Mainpath.SctPath + Variable.MainEdmmProfile.Eduu;
                Variable.MainEdmmProfile.TwrReal = Variable.Mainpath.SctPath + Variable.MainEdmmProfile.TwrReal;


            }
        }

        public static void SetSctPath(string Path)
        {
            StreamReader streamReader = new StreamReader(DefaultPath.ConfigPath);

            string Line1 = streamReader.ReadLine();
            string Line2 = streamReader.ReadLine();
            string Line3 = streamReader.ReadLine();
            string Line4 = streamReader.ReadLine();
            streamReader.Close();

            Paths Json = JsonConvert.DeserializeObject<Paths>(Line1);

            Paths newPaths = new Paths
            {
                SctPath = Path,
                ConfigPath = Json.ConfigPath,
                CredentialsPath = Json.CredentialsPath,
            };

            string line1Edited = JsonConvert.SerializeObject(newPaths);


            StreamWriter writer = new StreamWriter(DefaultPath.ConfigPath);
            writer.WriteLine(line1Edited);
            writer.WriteLine(Line2);
            writer.WriteLine(Line3);
            writer.WriteLine(Line4);
            writer.Close();

        }

        public static void SetCredentialsPath(string Path)
        {
            StreamReader streamReader = new StreamReader(DefaultPath.ConfigPath);

            string Line1 = streamReader.ReadLine();
            string Line2 = streamReader.ReadLine();
            string Line3 = streamReader.ReadLine();

            Paths Json = JsonConvert.DeserializeObject<Paths>(Line1);


            Paths newPaths = new Paths
            {
                SctPath = Json.SctPath,
                ConfigPath = Json.ConfigPath,
                CredentialsPath = Path,
            };

            string line1Edited = JsonConvert.SerializeObject(newPaths);

            StreamWriter writer = new StreamWriter(DefaultPath.ConfigPath);
            writer.WriteLine(line1Edited);
            writer.WriteLine(Line2);
            writer.WriteLine(Line3);
            writer.Close();
        }

        /*Setzt die Standartwerte für die config.json*/
        private static void SetDefaultConfigVariables()
        {

            DefaultPath.ConfigPath = Directory.GetCurrentDirectory() + @"\config.json";
            DefaultPath.CredentialsPath = Directory.GetCurrentDirectory() + @"\credentials.json";

            DefaultEdgg.PheonixTwr = @"\Tower Phoenix.prf";
            DefaultEdgg.Edgg = @"\EDGG Langen Radar.prf";
            DefaultEdgg.Eduu = @"\EDUU Rhein Radar.prf";
            DefaultEdgg.EddfApn = @"\EDDF Apron.prf";
            DefaultEdgg.Alternate = @"\Alternate.prf";
            DefaultEdgg.AlternateGrp = @"\Alternate GRP.prf";

            DefaultEdww.EdbbAppCtr = @"\EDBB-CTR-APP.prf";
            DefaultEdww.EdwwAppCtr = @"\EDWW-CTR-APP.prf";
            DefaultEdww.EdbbTwr = @"\EDBB-TWR.prf";
            DefaultEdww.EdwwTwr = @"\EDWW-TWR.prf";
            DefaultEdww.EduuCtr = @"\EDUU-CTR.prf";
            DefaultEdww.EdyyCtr = @"\EDYY-CTR.prf";

            DefaultEdmm.Edmm = @"\EDMM.prf";
            DefaultEdmm.Eduu = @"\EDUU.prf";
            DefaultEdmm.TwrReal = @"\TWR_REAL.prf";
        }

    }
}