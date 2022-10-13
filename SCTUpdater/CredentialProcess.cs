using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SCTUpdater
{
    internal class CredentialProcess
    {
        /*Checks if Credentialsfile exists,
        if yes he starts writing
        if not he creates the json and writes it*/
        public static void SaveCredentials(string name, long cid, string password, string CDPLC)
        {
            if (CheckCredentialsJson())
            {
                File.Delete(Directory.GetCurrentDirectory() + @"\credentials.json");
                CreateCredentialsJson(name, cid, password, CDPLC);
            }
            else
            {
                CreateCredentialsJson(name, cid, password, CDPLC);
            }
        }

        /*Checks if the File exists*/
        private static bool CheckCredentialsJson()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\credentials.json"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void CreateCredentialsJson(
            string name,
            long cid,
            string password,
            string cpdlc
        )
        {
            Credentials saveCredentials = new();

            saveCredentials.Name = name;
            saveCredentials.Password = password;
            saveCredentials.Cpdlc = cpdlc;
            saveCredentials.Cid = cid;

            string Json = JsonConvert.SerializeObject(saveCredentials);

            using (
                StreamWriter streamWriter = new StreamWriter(
                    Directory.GetCurrentDirectory() + @"\credentials.json"
                )
            )
            {
                streamWriter.Write(Json);
                streamWriter.Close();
            }
        }

        public static bool ImportCredentialsJson()
        {
            StreamReader reader = new StreamReader(
                Directory.GetCurrentDirectory() + @"\credentials.json"
            );
            string JsonOutput = reader.ReadToEnd();
            if (JsonConvert.DeserializeObject<Credentials>(JsonOutput) != null)
            {
                Credentials? MainCredentials = JsonConvert.DeserializeObject<Credentials>(
                    JsonOutput
                );
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
