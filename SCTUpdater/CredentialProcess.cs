using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;


namespace SCTUpdater
{
    internal class CredentialProcess
    {

        public static Paths CredentialsProcessPaths;



        /*Checks if Credentialsfile exists,
        if yes he starts writing
        if not he creates the json and writes it*/
        public static void SaveCredentials(string name, long cid, string? password, string? CDPLC)
        {
            CredentialsProcessPaths = Config.ImportPaths();
            if (CheckCredentialsJson())
            {
                File.Delete(CredentialsProcessPaths.CredentialsPath);
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
            CredentialsProcessPaths = Config.ImportPaths();
            if (File.Exists(CredentialsProcessPaths.CredentialsPath))
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

            using (StreamWriter streamWriter = new StreamWriter(CredentialsProcessPaths.CredentialsPath))
            {
                streamWriter.Write(Json);
                streamWriter.Close();
            }
        }

        public static Credentials? ImportCredentialsJson()
        {
            CredentialsProcessPaths = Config.ImportPaths();
            StreamReader reader = new StreamReader(CredentialsProcessPaths.CredentialsPath);
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

        public static void EnterCredentials()
        {
            
        }
    }
}
