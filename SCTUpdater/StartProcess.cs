using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SCTUpdater;
using static SCTUpdater.Variable;

namespace SCTUpdater
{
    internal class StartProcess
    {
        private static string profileContentwithout;

        //Langen 0, Bremen 1, München 2
        public static void Start(int profil, bool? namecid, bool? password, bool? cpdlc)
        {
            CredentialProcess.ImportCredentialsJson();
            Config.ImportConfigJson();

            mainTainer(profil, namecid, password, cpdlc);
        }

        private static void mainTainer(int profil, bool? namecid, bool? password, bool? cpdlc)
        {
            if (profil == 0)
            {

                getProfileContent(MainEdggProfile.PheonixTwr);
                string builder = generateStuff(MainEdggProfile.PheonixTwr,namecid, password, cpdlc);
                insertStuff(MainEdggProfile.AlternateGrp, builder);

                getProfileContent(MainEdggProfile.Edgg);
                string builder1 = generateStuff(MainEdggProfile.Edgg, namecid, password, cpdlc);
                insertStuff(MainEdggProfile.AlternateGrp, builder1);

                getProfileContent(MainEdggProfile.Eduu);
                string builder2 = generateStuff(MainEdggProfile.Eduu, namecid, password, cpdlc);
                insertStuff(MainEdggProfile.AlternateGrp, builder2);

                getProfileContent(MainEdggProfile.EddfApn);
                string builder3 = generateStuff(MainEdggProfile.EddfApn, namecid, password, cpdlc);
                insertStuff(MainEdggProfile.AlternateGrp, builder3);

                getProfileContent(MainEdggProfile.Alternate);
                string builder4 = generateStuff(MainEdggProfile.Alternate, namecid, password, cpdlc);
                insertStuff(MainEdggProfile.AlternateGrp, builder4);

                getProfileContent(MainEdggProfile.AlternateGrp);
                string builder5 = generateStuff(MainEdggProfile.AlternateGrp, namecid, password, cpdlc);
                insertStuff(MainEdggProfile.AlternateGrp, builder5);
            }
            
        }

        private static void getProfileContent(string path)
        {
            StreamReader reader = new StreamReader(path);
            profileContentwithout = reader.ReadToEnd();
            reader.Close();
        }

        private static string generateStuff(string path, bool? ifnamecid, bool? ifpassword, bool? ifcpdlc)
        {
            StringBuilder builder = new StringBuilder();
            if (ifnamecid == true)
            { 
                string realname = "LastSession realname " + MainCredentials.Name;
            string certificate = "LastSession certificate " + MainCredentials.Cid;
            builder.AppendLine(realname);
            builder.AppendLine(certificate);
            }

            if (ifpassword == true)
            {
                string password = "LastSession password " + MainCredentials.Password;
                builder.AppendLine(password);
            }

            return builder.ToString();

        }

        private static void insertStuff(string path, string builder)
        {
            string insert = profileContentwithout + "\n" + builder;

            StreamWriter writer = new StreamWriter(path);
            writer.Write(insert);
            writer.Close();
        }



        private static void CheckIfCredentialsAlreadyInserted()
        {
           
        }
    }
}
