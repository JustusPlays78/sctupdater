using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;
using Newtonsoft.Json;
using SCTUpdater;
using static SCTUpdater.Variable;
using Path = System.IO.Path;
using MessageBox = System.Windows.Forms.MessageBox;

namespace SCTUpdater
{
    internal class StartProcess
    {
        public static Credentials ProcessCredentials;
        public static Paths ProcessPaths;
        private static string profileContentwithout;

        private static List<string> Profiles = new List<string>();

        //Langen 0, Bremen 1, München 2
        public static void Start(bool? namecid, bool? password, bool? cpdlc, bool? hdgdrawtool)
        {
            ProcessCredentials = CredentialProcess.ImportCredentialsJson();
            ProcessPaths = Config.ImportPaths();



            mainTainer(namecid, password, cpdlc, hdgdrawtool);
        }

        private static void mainTainer(bool? namecid, bool? password, bool? cpdlc, bool? hdgdrawtool)
        {
            string builder = generateStuff(namecid, password, cpdlc, hdgdrawtool,ProcessCredentials);
            GetProfileFiles();
            foreach (var file in Profiles)
            {
                if (CheckIfCredentialsAlreadyInserted(file) == false)
                {
                    getProfileContent(file);
                    insertStuff(file, builder, profileContentwithout);
                }

            }
        }

        private static string getProfileContent(string path)
        {
            StreamReader reader = new StreamReader(path);
            profileContentwithout = reader.ReadToEnd();
            reader.Close();
            return profileContentwithout;
        }

        private static string generateStuff( bool? ifnamecid, bool? ifpassword, bool? ifcpdlc, bool? ifhdgdrawtool, Credentials ProcessCredentials)
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

            if(ifcpdlc == true)
            {
                EditHoppieCode();          
            }
            if (ifhdgdrawtool == true)
            {
                EditHdgDrawTool();
            }
            return builder.ToString();

        }

        private static void insertStuff(string path, string builder, string profileContentwithout)
        {
            string insert = profileContentwithout + "\n" + builder;

            File.WriteAllText(path, insert);
        }


        private static bool CheckIfCredentialsAlreadyInserted(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string[] lines = File.ReadAllLines(path);
                string check = "realname";
                string[] checkArray = new string[] {"realname", "certificate", "password" };
                if (checkArray.Any(File.ReadAllText(path).Contains))
                {
                    return true;
                }

                return false;
            }
        }
        private static void GetProfileFiles()
        {
            var files = Directory.GetFiles(ProcessPaths.SctPath, "*.prf");
            foreach (var file in files)
            {
                Profiles.Add(file);
            }

        }

        private static void EditHoppieCode()
        {
            var files = Directory.GetFiles(ProcessPaths.SctPath, "*.txt");
            foreach (var file in files)
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(file);
                if(fileName == "TopSkyCPDLChoppieCode")
                {
                    File.WriteAllText(file, ProcessCredentials.Cpdlc);
                }
            }
        }

        private static void EditHdgDrawTool()
        {
            var files = Directory.GetFiles(ProcessPaths.SctPath, "*.txt");
            foreach (var file in files)
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(file);
                if (fileName == "EDGG_Tags")
                {
                    StreamReader reader = new StreamReader(file);
                    string content = reader.ReadToEnd();
                    reader.Close();

                    content = Regex.Replace(content, "TAGITEM:54::0:1:14:14:TopSky plugin:0:1:TopSky plugin::1",
                        "TAGITEM: 25::0:1:14:14::0:1:TopSky plugin::1");
                    MessageBox.Show("HDG DRAWTOOL");
                    File.WriteAllText(file, content);

                }
            }
        }
    }
}
