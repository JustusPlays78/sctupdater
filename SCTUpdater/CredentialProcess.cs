using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;


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
                File.Delete(CredentialsProcessPaths.CredentialsPath!);
            }

            CreateCredentialsJson(name, cid, password, CDPLC);
        }

        /*Checks if the File exists*/
        private static bool CheckCredentialsJson()
        {
            CredentialsProcessPaths = Config.ImportPaths();

            return File.Exists(CredentialsProcessPaths.CredentialsPath);
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

            string Json = JsonSerializer.Serialize(saveCredentials);

            using StreamWriter streamWriter = new StreamWriter(CredentialsProcessPaths.CredentialsPath);
            streamWriter.Write(Json);
            streamWriter.Close();
        }

        public static Credentials? ImportCredentialsJson()
        {
            CredentialsProcessPaths = Config.ImportPaths();
            StreamReader reader = new StreamReader(CredentialsProcessPaths.CredentialsPath);
            string JsonOutput = reader.ReadToEnd();
            if (JsonSerializer.Deserialize<Credentials>(JsonOutput) != null)
            {
                Credentials? MainCredentials = JsonSerializer.Deserialize<Credentials>(
                    JsonOutput
                );
                return MainCredentials;
            }
           
            return null;
        }

        public static void EnterCredentials()
        {
            
        }
    }
}
