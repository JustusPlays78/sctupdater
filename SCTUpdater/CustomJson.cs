using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCTUpdater
{
    internal class CustomJson
    {
        public static Paths CustomJsonProcessPaths;

        public static void Maintainer()
        {
            CustomJsonProcessPaths = Config.ImportPaths();

            List<bool> JsonDone = new List<bool>();
            CustomJsonVariables customJsonNew = getJson()!;

            customJsonNew.Settings.ForEach(
                x => JsonDone.Add(CustomInsertFromJson(x, CustomJsonProcessPaths))
            );
        }

        private static CustomJsonVariables? getJson()
        {
            CustomJsonProcessPaths = Config.ImportPaths();
            StreamReader reader = new StreamReader(
                CustomJsonProcessPaths.CustomJsonPath ?? throw new Exception()
            );
            string JsonOutput = reader.ReadToEnd();

            var deserializeJson = JsonSerializer.Deserialize<CustomJsonVariables>(JsonOutput);
            if (deserializeJson != null)
            {
                return deserializeJson ?? throw new Exception();
            }

            return null;
        }

        private static bool CustomInsertFromJson(Setting setting, Paths path)
        {
            string customJsonFilename = setting.FileName;
            string customJsonOldContent = setting.OldContent;
            string customJsonNewContent = setting.NewContent;
            string JsonPath = path.CustonJsonPathwjson + "\\" + customJsonFilename;
            string newcontent;

            if (!File.Exists(JsonPath))
            {
                return false;
            }

            StreamReader reader = new StreamReader(JsonPath);
            string oldcontent = reader.ReadToEnd();
            reader.Close();

            newcontent =
                customJsonOldContent != null
                    ? oldcontent.Replace(customJsonOldContent, customJsonNewContent)
                    : customJsonNewContent;

            File.WriteAllText(JsonPath, newcontent);
            return true;
        }
    }
}
