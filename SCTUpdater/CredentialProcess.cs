using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using static SCTUpdater.Config;

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
                File.Delete(DefaultPath.CredentialsPath);
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
            if (File.Exists(DefaultPath.CredentialsPath))
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

            using (StreamWriter streamWriter = new StreamWriter(DefaultPath.CredentialsPath))
            {
                streamWriter.Write(Json);
                streamWriter.Close();
            }
        }

        public static Credentials? ImportCredentialsJson()
        {
            StreamReader reader = new StreamReader(DefaultPath.CredentialsPath);
            string JsonOutput = reader.ReadToEnd();
            if (JsonConvert.DeserializeObject<Credentials>(JsonOutput) != null)
            {
                Credentials? MainCredentials = JsonConvert.DeserializeObject<Credentials>(
                    JsonOutput
                );
                return MainCredentials;
            }
            else
            {
                return null;
            }
        }
    }
}
