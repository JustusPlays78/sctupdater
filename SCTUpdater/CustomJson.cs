using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCTUpdater
{
    internal class CustomJson
    {
        public static Paths CustomJsonProcessPaths;

        public static string Maintainer()
        {
            CustomJsonVariables customJsonNew = getJson();


            return null;
        }

        private static CustomJsonVariables? getJson()
        {
            CustomJsonProcessPaths = Config.ImportPaths();
            StreamReader reader = new StreamReader(CustomJsonProcessPaths.CustomJsonPath + "\\customsettings.json");
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

    }
}
