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
        public static EDGGProfiles Defaultedgg = new EDGGProfiles();

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
            String genpath = Directory.GetCurrentDirectory();

            SetDefaultConfigVariables();


            string JsonResult = JsonConvert.SerializeObject(Defaultedgg);

            File.WriteAllText(@"C:\Users\Julian\Desktop\sctshit\test_13_10\config.json", JsonResult);
            RemoveDefaultConfigVariablesValue();

        }

        private static void SetDefaultConfigVariables()
        {


            Defaultedgg.PheonixTwr = "Tower Phoenix.prf";
            Defaultedgg.Edgg = "EDGG Langen Radar.prf";
            Defaultedgg.Eduu = "EDUU Rhein Radar.prf";
            Defaultedgg.EddfApn = "EDDF Apron.prf";
            Defaultedgg.Alternate = "Alternate.prf";
            Defaultedgg.AlternateGrp = "Alternate GRP.prf";

            EDWWProfiles.EdbbAppCtr = "EDBB-CTR-APP.prf";
            EDWWProfiles.EdwwAppCtr = "EDWW-CTR-APP.prf";
            EDWWProfiles.EdbbTwr = "EDBB-TWR.prf";
            EDWWProfiles.EdwwTwr = "EDWW-TWR.prf";
            EDWWProfiles.EduuCtr = "EDUU-CTR.prf";
            EDWWProfiles.EdyyCtr = "EDYY-CTR.prf";

            EDMMProfiles.Edmm = "EDMM.prf";
            EDMMProfiles.Eduu = "EDUU.prf";
            EDMMProfiles.TwrReal = "TWR_REAL.prf";
        }

        private static void RemoveDefaultConfigVariablesValue()
        {
        }

        public static void ImportConfigJson()
        {

        }
    }
}