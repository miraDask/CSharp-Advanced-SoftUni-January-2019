namespace p05.Directory_Traversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DirectoryTraversal
    {
        public static void Main()
        {
            string path = Console.ReadLine();
            string pathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt";

            string[] files = Directory.GetFiles(path);

            Dictionary<string, List<FileInfo>> filesInfo = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                var info = new FileInfo(file);
                var extension = info.Extension;

                if (!filesInfo.ContainsKey(extension))
                {
                    filesInfo[extension] = new List<FileInfo>();
                }

                filesInfo[extension].Add(info);

            }

            using (var writer = new StreamWriter(pathToDesktop))
            {
                foreach (var fileKvp in filesInfo.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                {
                    var extension = fileKvp.Key;
                    var info = fileKvp.Value;

                    writer.WriteLine(extension);

                    foreach (var file in info.OrderBy(x => x.Length))
                    {
                        string name = file.Name;
                        double size = (double)file.Length / 1024;

                        writer.WriteLine($"--{name} - {size:F3}kb");
                    }
                }
            }
        }
    }
}
