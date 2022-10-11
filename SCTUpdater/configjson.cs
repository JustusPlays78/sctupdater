using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SCTUpdater
{
    public class SCTPath
    {
        public static string pathdialog;
    }
    public class profiles
    {
        public static string phoenix = "Tower Phoenix.prf";
        public static string edggpro = "EDGG Langen Radar";
        public static string eduupro = "EDUU Rhein Radar.prf";
        public static string alternate = "Alternate.prf";
        public static string apron = "EDDF Apron.prf";
        public static string alternateGrp = "Alternate GRP.prf";
    }
   
    public class List
    {
        //public static List<string> profilesList = new List<string>
        //{
        //    "Tower Phoenix.prf",
        //    "EDGG Langen Radar",
        //    "EDUU Rhein Radar.prf",
        //    "Alternate.prf",
        //    "EDDF Apron.prf",
        //    "Alternate GRP.prf"
        //};
    }
    public class creds
    {
        public string name;
        public string password;
        public string cpdlc;
        public string cid;
    }
    internal class configjson
    {
        public static bool startcheck()
        {
            //configjson vorhanden
            //path für edgg ordner
            if (File.Exists(@"config.json"))
            {
                return true;
            }
            else
            {
                configjsoncheck();
                return true;
            }
        }

        private static void configjsoncheck()
        {
            /*profiles profile = new profiles
            {
                phoenix = "Tower Phoenix.prf",
                edggpro = "EDGG Langen Radar",
                eduupro = "EDUU Rhein Radar.prf",
                alternate = "Alternate.prf",
                apron = "EDDF Apron.prf",
                alternateGrp = "Alternate GRP.prf",
            };*/

            //string JSONresult = JsonConvert.SerializeObject(profile);
            //File.WriteAllText(@"config.json", JSONresult);
            }

        public void savepath(string paths)
        {
            StreamReader reader = new StreamReader(SCTPath.pathdialog + @"\config.json");
            string json = reader.ReadToEnd();
            reader.Close();
            SCTPath pathdialog = JsonConvert.DeserializeObject<SCTPath>(json);
            string JSONresult = JsonConvert.SerializeObject(paths);
            File.WriteAllText(@"config.json", JSONresult);
        }

        public static profiles getprofiles()
        {
            StreamReader reader = new StreamReader(SCTPath.pathdialog +@"\config.json");
            string json = reader.ReadToEnd();
            reader.Close();
            profiles profile = JsonConvert.DeserializeObject<profiles>(json);
            return profile;
        }

    }
}
