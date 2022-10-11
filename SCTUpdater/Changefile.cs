using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SCTUpdater
{
    internal class Changefile
    {
        private static String path;

        public static void startbutton()
        {
            prfedit();
        }

        private static void prfedit()
        {
            string credentialslogin = credentialscreatetext();
            string newfile;

            StreamReader reader = new StreamReader(
                @"C:\Users\Julian\Desktop\sctshit\Tower Phoenix.prf"
            );
            string filecontent = reader.ReadToEnd();
            reader.Close();
            newfile = filecontent + "\n" + credentialslogin;
            StreamWriter writer = new StreamWriter(
                @"C:\Users\Julian\Desktop\sctshit\Tower Phoenix.prf"
            );
            writer.Write(newfile);
            writer.Close();
        }

        private static string credentialscreatetext()
        {
            creds creds = Jsonfile.getjson();
            string realname = "LastSession realname " + creds.name;
            string certificate = "LastSession certificate " + creds.cid;
            string password = "LastSession password " + creds.password;
            string rest1 = "LastSession facility 0";
            string rest2 = "LastSession rating 3";
            string rest3 = "LastSession server SINGAPORE";

            StringBuilder builder = new StringBuilder();
            builder.AppendLine(realname);
            builder.AppendLine(certificate);
            builder.AppendLine(password);
            builder.AppendLine(rest1);
            builder.AppendLine(rest2);
            builder.AppendLine(rest3);

            return builder.ToString();
        }
    }
}
