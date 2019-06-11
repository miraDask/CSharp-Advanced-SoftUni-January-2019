namespace _06.FolderSize
{
    using System;
    using System.IO;

    public class FolderSize
    {
        public static void Main()
        {
            string[] files = Directory.GetFiles("../../../TestFolder");

            double sum = 0;

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                sum += fileInfo.Length;
            }

            string text = $"{sum / 1024 / 1024}";

            File.WriteAllText("../../../Output.txt",text );
             
        }
    }
}
