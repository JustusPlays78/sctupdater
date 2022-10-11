using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace SCTUpdater

{
    internal class Jsonfile
    {
        

        public static void savecreds(string nametext, string passwordtext, string cpdlctext)
        {
            string path = @"C:\Users\Julian\Desktop\sctshit\creds.json";

                creds cred = new creds { cidname = nametext, password = passwordtext, cpdlc = cpdlctext };
                string JSONresult = JsonConvert.SerializeObject(cred); 
                File.WriteAllText(path,JSONresult);
                /*using (var js = new StreamWriter(path, true))
                {
                    js.WriteLine(JSONresult);
                    js.Close();
                }*/

        }

    }

    internal class creds
    {
        public string cidname;
        public string password;
        public string cpdlc;
    }
}
