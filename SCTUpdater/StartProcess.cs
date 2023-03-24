using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;
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
        public static void Start(bool? namecid, bool? password, bool? cpdlc, bool? hdgdrawtool, bool? insertcustomjson)
        {
            ProcessCredentials = CredentialProcess.ImportCredentialsJson();
            ProcessPaths = Config.ImportPaths();



            mainTainer(namecid, password, cpdlc, hdgdrawtool, insertcustomjson);
        }

        private static void mainTainer(bool? namecid, bool? password, bool? cpdlc, bool? hdgdrawtool, bool? insertcustomjson)
        {
            string builder = generateStuff(namecid, password, cpdlc, hdgdrawtool,ProcessCredentials);
            GetProfileFiles();
            foreach (var file in Profiles)
            {
                getProfileContent(file);
                insertStuff(file, builder, profileContentwithout);
            }

            if (insertcustomjson == true)
            {
                CustomJson.Maintainer();
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
            string connecttype = "LastSession\tconnecttype\t0";
            string callsign = "LastSession\tcallsign\tXX_OBS";
            builder.AppendLine(connecttype);
            builder.AppendLine(callsign);
            if (ifnamecid == true)
            { 
                string realname = "LastSession\trealname\t" + ProcessCredentials.Name;
                string certificate = "LastSession\tcertificate\t" + ProcessCredentials.Cid;
                builder.AppendLine(realname);
                builder.AppendLine(certificate);
            }

            if (ifpassword == true)
            {
                string password = "LastSession\tpassword\t" + ProcessCredentials.Password;
                builder.AppendLine(password);
            }

            string facility = "LastSession\tfacility\t0";
            string rating = "LastSession\trating\t0";
            string server = "LastSession\tserver\tAUTOMATIC";
            string tovatsim = "LastSession\ttovatsim\t1";
            string range = "LastSession\trange\t100";
            string proxy = "LastSession\tproxyserver\tlocalhost";
            string simdatapublish = "LastSession\tsimdatapublish\t0";
            builder.AppendLine(facility);
            builder.AppendLine(rating);
            builder.AppendLine(server);
            builder.AppendLine(tovatsim);
            builder.AppendLine(range);
            builder.AppendLine(proxy);
            builder.AppendLine(simdatapublish);


            if (ifcpdlc == true)
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
            string[] oldcreds = new string[]
            {
                "LastSession\tserver",
                "LastSession\tconnecttype",
                "LastSession\tfacility",
                "LastSession\trating",
                "LastSession\ttovatsim",
                "LastSession\trange",
                "LastSession\tproxyserver",
                "LastSession\tsimdatapublish",
                "LastSession\tconnecttype",
                "LastSession\tcallsign",
                "LastSession\trealname",
                "LastSession\tcertificate",
                "LastSession\tpassword",
                "LastSession\tserver"

            };
            string[] lines = profileContentwithout.Split("\r\n");
            for (int i = 0; i < lines.Length; i++)
            {
                for (int a = 0; a < oldcreds.Length; a++)
                {
                    if (lines[i].Contains(oldcreds[a]))
                    {
                        lines[i] = "";
                    }
                }

            }

            profileContentwithout = string.Join("\r\n", lines);



            string insert = profileContentwithout + builder;
            insert.Replace("realname", "");
            insert.Replace("certificate", "");

            File.WriteAllText(path, insert);
        }


        private static bool CheckIfCredentialsAlreadyInserted(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string[] lines = File.ReadAllLines(path);
                string check = "realname";
                string[] checkArray = new string[] { "realname", "certificate", "password" };
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

            files.ToList().ForEach(x => Profiles.Add(x));
        }

        private static void EditHoppieCode()
        {
            var files = Directory.GetFiles(ProcessPaths.SctPath, "*.txt", SearchOption.AllDirectories).ToList();

            var hoppiePaths = files.Where(x => Path.GetFileNameWithoutExtension(x) == "TopSkyCPDLChoppieCode").ToList();

            var count = files.Count;
            hoppiePaths.ForEach(x => File.WriteAllText(x, ProcessCredentials.Cpdlc));
        }

        private static void EditHdgDrawTool()
        {
            var files = Directory.GetFiles(ProcessPaths.SctPath, "*.txt");
            foreach (var file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
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
