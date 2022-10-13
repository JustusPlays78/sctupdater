using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCTUpdater
{
    internal class CredentialProcess
    {
        /*Checks if Credentialsfile exists, 
        if yes he starts writing
        if not he creates the json and writes it*/
        public static void SaveCredentials(string name, string cid, string password, string CDPLC)
        {
            if (CheckCredentialsJson())
            {
                JsonCredentialsWrite(name, cid, password, CDPLC);
            }
            else
            {
                CreateCredentialsJson();
                JsonCredentialsWrite(name, cid, password, CDPLC);
            }
        }

        /*Writes the credentials in the credentials.json*/
        private static void JsonCredentialsWrite(string name, string cid, string password, string CDPLC)
        {

        }

        /*Checks if the File exists*/
        private static bool CheckCredentialsJson()
        {
            if (File.Exists( "credentials.json"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void CreateCredentialsJson()
        {

        }
    }
}
