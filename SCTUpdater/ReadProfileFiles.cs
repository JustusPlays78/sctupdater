using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCTUpdater
{
    public class Profile
    {
        public string Name { get; init; }
        public string Path { get; init; }
    }

    internal class ReadProfileFiles
    {
        public static List<Profile> GetProfiles()
        {
            List<Profile> returnList = new List<Profile>();

            var profileFiles = Directory.GetFiles(SCTPath.Path, "*.prf").ToList();

            if (profileFiles.Count == 0)
            {
                return Enumerable.Empty<Profile>().ToList();
            }

            profileFiles.ForEach(
                x =>
                    returnList.Add(
                        new Profile()
                        {
                            Name = Path.GetFileNameWithoutExtension(x),
                            Path = Path.GetFullPath(x)
                        }
                    )
            );

            //foreach (var file in profileFiles)
            //{
            //    string fileName = Path.GetFileNameWithoutExtension(file);
            //    string filePath = Path.GetFullPath(file);

            //    Profile Profile = new Profile
            //    {
            //        Name = fileName,
            //        Path = filePath,
            //    };

            //    returnList.Add(Profile);
            //}

            return returnList;
        }
    }
}
