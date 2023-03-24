using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCTUpdater
{
    public class   Profile
    {
        public string Name { get; init; }
        public string Path { get; init; }
    }
    internal class ReadProfileFiles
    {
        public static List<Profile> GetProfiles()
        {
            List<Profile> ReturnList = new List<Profile>();

            var ProfileFiles = Directory.GetFiles(SCTPath.Path, "*.prf");

            if (ProfileFiles.Length > 0)
            {
                foreach (var File in ProfileFiles)
                {
                    string FileName = Path.GetFileNameWithoutExtension(File);
                    string FilePath = Path.GetFullPath(File);

                    Profile Profile = new Profile
                    {
                        Name = FileName,
                        Path = FilePath,
                    };

                    ReturnList.Add(Profile);
                }
            }

            return ReturnList;
        }
    }
}
