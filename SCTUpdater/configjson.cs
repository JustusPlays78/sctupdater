using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace SCTUpdater
{
    public class SCTPath
    {
        public static string Path;
    }
    public class Credential
    {
        public string Name;
        public string Password;
        public string CPDLC;
        public string CID;
    }
    internal class configjson
    {
        public static bool IsConfigCreated()
        {
            //configjson vorhanden
            //path für edgg ordner
            if (File.Exists(@"config.json"))
            {
                return true;
            }
            
            CreateConfig();
            return false;
        }

        public static void CreateConfig()
        {
            string Path = @"config.json";
        }

        public static void SavePath(string paths)
        {
            StreamReader reader = new StreamReader(SCTPath.Path + @"\config.json");
            string json = reader.ReadToEnd();
            reader.Close();
            SCTPath pathdialog =JsonSerializer.Deserialize<SCTPath>(json) ?? throw new Exception("JSON nix gut");
            string JSONresult = JsonSerializer.Serialize(paths);
            File.WriteAllText(@"config.json", JSONresult);
        }


    }
}
