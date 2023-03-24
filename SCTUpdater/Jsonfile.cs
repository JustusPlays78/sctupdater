using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using System.Text.Json;

namespace SCTUpdater
{

    internal class Jsonfile
    {
        public static string path = SCTPath.Path;

        public static void SaveCredentials(
            string Name,
            string Password,
            string CPDLC,
            string CID
        )
        {
            Credential cred = new Credential
            {
                Name = Name,
                Password = Password,
                CPDLC = CPDLC,
                CID = CID
            };
            string JSONresult = JsonSerializer.Serialize(cred);
            File.WriteAllText("config.json", JSONresult);
        }

        public static Credential GetJson()
        {
            string text = File.ReadAllText(path);
            Credential? creds = JsonSerializer.Deserialize<Credential>(text);

            return creds;
            
        }
    }
}
