using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using SCTUpdater;
using static SCTUpdater.Variable;

namespace SCTUpdater
{
    internal class StartProcess
    {
        public static Credentials ProcessCredentials;
        public static Paths ProcessPaths;
        public static EDGGProfiles ProcessEdggProfiles;
        public static EDWWProfiles ProcessEdwwProfiles;
        public static EDMMProfiles ProcessEdmmProfiles;
        private static string profileContentwithout;

        //Langen 0, Bremen 1, München 2
        public static void Start(int profil, bool? namecid, bool? password, bool? cpdlc)
        {
            ProcessCredentials = CredentialProcess.ImportCredentialsJson();
            ProcessPaths = Config.ImportPaths();
            ProcessEdggProfiles = Config.ImportEdggProfiles();
            ProcessEdwwProfiles = Config.ImportEdwwProfiles();
            ProcessEdmmProfiles = Config.ImportEdmmProfiles();



            mainTainer(profil, namecid, password, cpdlc);
        }

        private static void mainTainer(int profil, bool? namecid, bool? password, bool? cpdlc)
        {

            if (profil == 0)
            {

                getProfileContent(ProcessEdggProfiles.PheonixTwr);
                string builder = generateStuff(namecid, password, cpdlc, ProcessCredentials);
                insertStuff(ProcessEdggProfiles.PheonixTwr, builder, profileContentwithout);

                getProfileContent(ProcessEdggProfiles.Edgg);
                insertStuff(ProcessEdggProfiles.Edgg, builder, profileContentwithout);

                getProfileContent(ProcessEdggProfiles.Eduu);
                insertStuff(ProcessEdggProfiles.Eduu, builder, profileContentwithout);

                getProfileContent(ProcessEdggProfiles.EddfApn);
                insertStuff(ProcessEdggProfiles.EddfApn, builder, profileContentwithout);

                getProfileContent(ProcessEdggProfiles.Alternate);
                insertStuff(ProcessEdggProfiles.Alternate, builder, profileContentwithout);

                getProfileContent(ProcessEdggProfiles.AlternateGrp);
                insertStuff(ProcessEdggProfiles.AlternateGrp, builder, profileContentwithout);


            }
            
        }

        private static string getProfileContent(string path)
        {
            StreamReader reader = new StreamReader(path);
            profileContentwithout = reader.ReadToEnd();
            reader.Close();
            return profileContentwithout;
        }

        private static string generateStuff( bool? ifnamecid, bool? ifpassword, bool? ifcpdlc, Credentials ProcessCredentials)
        {
            StringBuilder builder = new StringBuilder();
            if (ifnamecid == true)
            { 
                string realname = "LastSession realname " + ProcessCredentials.Name;
                string certificate = "LastSession certificate " + ProcessCredentials.Cid;
                builder.AppendLine(realname);
                builder.AppendLine(certificate);
            }

            if (ifpassword == true)
            {
                string password = "LastSession password " + ProcessCredentials.Password;
                builder.AppendLine(password);
            }

            return builder.ToString();

        }

        private static void insertStuff(string path, string builder, string profileContentwithout)
        {
            string insert = profileContentwithout + "\n" + builder;

            File.WriteAllText(path,insert);
        }



        private static void CheckIfCredentialsAlreadyInserted()
        {
           
        }
    }
}
