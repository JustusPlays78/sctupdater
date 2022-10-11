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
        public string? phoenix;
        public string? edggpro;
        public string? eduupro;
        public string? alternate;
        public string apron;
        public string alternateGrp;
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

            bool returned = true;
            return returned;
        }

        private void configjsoncheck()
        {
            profiles profile = new profiles
                {
                    phoenix = "Tower Phoenix.prf",
                    edggpro = "EDGG Langen Radar",
                    eduupro = "EDUU Rhein Radar.prf",
                    alternate = "Alternate.prf",
                    apron = "EDDF Apron.prf",
                    alternateGrp = "Alternate GRP.prf",
                };




                string JSONresult = JsonConvert.SerializeObject(profile);
                File.WriteAllText(path, JSONresult);
            }

    }
}
