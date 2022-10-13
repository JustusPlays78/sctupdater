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

            CreateConfigJson();
            if (CheckConfigJson())
            {
            }
        }

        /*Cheks if Config.json exists*/
        private static bool CheckConfigJson()
        {
            if (File.Exists(  "config.json"))
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

            SetDefaultConfigVariables();

            string JsonResultpath = JsonConvert.SerializeObject(DefaultPath);
            string JsonResultEdgg= JsonConvert.SerializeObject(DefaultEdgg);
            string JsonResultEdww = JsonConvert.SerializeObject(DefaultEdww);
            string JsonResultEdmm = JsonConvert.SerializeObject(DefaultEdmm);

            string JsonResult = JsonResultpath + JsonResultEdgg + JsonResultEdww + JsonResultEdmm;

            File.WriteAllText(@"C:\Users\Julian\Desktop\sctshit\test_13_10\config.json", JsonResult);
            RemoveDefaultConfigVariablesValue();

        }

        private static void SetDefaultConfigVariables()
        {

            DefaultEdgg.PheonixTwr = "Tower Phoenix.prf";
            DefaultEdgg.Edgg = "EDGG Langen Radar.prf";
            DefaultEdgg.Eduu = "EDUU Rhein Radar.prf";
            DefaultEdgg.EddfApn = "EDDF Apron.prf";
            DefaultEdgg.Alternate = "Alternate.prf";
            DefaultEdgg.AlternateGrp = "Alternate GRP.prf";

            DefaultEdww.EdbbAppCtr = "EDBB-CTR-APP.prf";
            DefaultEdww.EdwwAppCtr = "EDWW-CTR-APP.prf";
            DefaultEdww.EdbbTwr = "EDBB-TWR.prf";
            DefaultEdww.EdwwTwr = "EDWW-TWR.prf";
            DefaultEdww.EduuCtr = "EDUU-CTR.prf";
            DefaultEdww.EdyyCtr = "EDYY-CTR.prf";

            DefaultEdmm.Edmm = "EDMM.prf";
            DefaultEdmm.Eduu = "EDUU.prf";
            DefaultEdmm.TwrReal = "TWR_REAL.prf";
        }

        private static void RemoveDefaultConfigVariablesValue()
        {
        }

        public static void ImportConfigJson()
        {

        }
    }
}