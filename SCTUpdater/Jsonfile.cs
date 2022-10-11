using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace SCTUpdater
{

    internal class Jsonfile
    {
        public static string path = @"C:\Users\Julian\Desktop\sctshit\creds.json";

        public static void savecreds(
            string nametext,
            string passwordtext,
            string cpdlctext,
            string cidtext
        )
        {
            creds cred = new creds
            {
                name = nametext,
                password = passwordtext,
                cpdlc = cpdlctext,
                cid = cidtext
            };
            string JSONresult = JsonConvert.SerializeObject(cred);
            File.WriteAllText(path, JSONresult);
        }

        public static creds getjson()
        {
            string text = File.ReadAllText(path);
            creds creds = JsonConvert.DeserializeObject<creds>(text);
            return creds;
        }
    }
}
