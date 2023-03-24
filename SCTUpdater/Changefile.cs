using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using SCTUpdater;

namespace SCTUpdater
{
    internal class Changefile
    {
        private static String path;

        public static void StartButton()
        {
            //foreach (var Profile in MainWindow.ProfilesClass.Profiles)
            //{
            //    EditPrf(Profile.Path);
            //}
        }

        private static void EditPrf(string profile)
        {
            string Credentials = CreateCredentials();
            string NewFile;

            StreamReader reader = new StreamReader(profile);
            string FileContent = reader.ReadToEnd();
            reader.Close();
            NewFile = FileContent + "\n" + Credentials;
            StreamWriter writer = new StreamWriter(profile);
            writer.Write(NewFile);
            writer.Close();
        }

        private static string CreateCredentials()
        {
            StringBuilder builder = new StringBuilder();

            Credential creds = Jsonfile.GetJson();
            builder.AppendLine("LastSession realname " + creds.Name);
            builder.AppendLine("LastSession certificate " + creds.CID);
            builder.AppendLine("LastSession password " + creds.Password);
            builder.AppendLine("LastSession facility 0");
            builder.AppendLine("LastSession rating 3");
            builder.AppendLine("LastSession server SINGAPORE");

            return builder.ToString();
        }
    }
}
