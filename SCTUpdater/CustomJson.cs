using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCTUpdater
{
    internal class CustomJson
    {
        public static Paths CustomJsonProcessPaths;

        public static string Maintainer()
        {
            CustomJsonProcessPaths = Config.ImportPaths();

            List<bool> JsonDone = new List<bool>();
            CustomJsonVariables customJsonNew = getJson();
            for (int i = 0; i < customJsonNew.Setting.GetLength(0); i++)
            {
                JsonDone.Add(CustomInsertFromJson(i, customJsonNew, CustomJsonProcessPaths));
            }

            return null;
        }

        private static CustomJsonVariables? getJson()
        {
            CustomJsonProcessPaths = Config.ImportPaths();
            StreamReader reader = new StreamReader(CustomJsonProcessPaths.CustomJsonPath);
            string JsonOutput = reader.ReadToEnd();
            if (JsonConvert.DeserializeObject<CustomJsonVariables>(JsonOutput) != null)
            {
                CustomJsonVariables? CustomJsonContent = JsonConvert.DeserializeObject<CustomJsonVariables>(
                    JsonOutput
                );
                return CustomJsonContent;
            }
            else
            {
                return null;
            }
        }

        private static bool CustomInsertFromJson(int i, CustomJsonVariables custonJsonNew, Paths Path)
        {
            
            string customJsonFilename = custonJsonNew.Setting.GetValue(i, 0).ToString();
            string customJsonOldContent = custonJsonNew.Setting.GetValue(i, 1).ToString();
            string customJsonNewContent = custonJsonNew.Setting.GetValue(i, 2).ToString();
            string JsonPath = Path.CustonJsonPathwjson + "\\" + customJsonFilename;
            string newcontent;

            if (Checker(JsonPath) != true)
            {
                return false;
            }


            StreamReader reader = new StreamReader(JsonPath);
            string oldcontent = reader.ReadToEnd();
            reader.Close();
            if (customJsonOldContent != null)
            {
                oldcontent.Contains(customJsonOldContent);
                newcontent = oldcontent.Replace(customJsonOldContent, customJsonNewContent);
            }
            else
            {
                newcontent = customJsonNewContent;
            }
            
            File.WriteAllText(JsonPath, newcontent);
            return true;

        }

        private static bool Checker(string file)
        {
            if (File.Exists(file))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
