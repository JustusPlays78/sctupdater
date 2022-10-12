using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace SCTUpdater
{
    public class SCTPath
    {
        public string pathedgg { get; set; }
        public string pathedww { get; set; }
        public string pathedmm { get; set; }
        public string pathconfig { get; set; }
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
            getpaths();
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

        public static void savepath(string paths)
        {
            StreamReader reader = new StreamReader(SCTPath.pathdialog + @"\config.json");
            string json = reader.ReadToEnd();
            reader.Close();
            string JSONresult = JsonConvert.SerializeObject(paths);
            File.WriteAllText(@"config.json", JSONresult);
        }

        /*public static profiles getprofiles()
        {
            StreamReader reader = new StreamReader( +@"\config.json");
            string json = reader.ReadToEnd();
            reader.Close();
            profiles profile = JsonConvert.DeserializeObject<profiles>(json);
            return profile;
        }*/

        public static void getpaths()
        {
            StreamReader reader = new StreamReader(@"C:\Users\Julian\Desktop\sctshit\config.json");
            string json = reader.ReadToEnd();
            reader.Close();
            List<SCTPath> pathouts = JsonConvert.DeserializeObject<List<SCTPath>>(json);

            foreach(SCTPath pathout in pathouts)
            {
                MessageBox.Show(pathout.pathconfig);
            }
        }

    }
}
