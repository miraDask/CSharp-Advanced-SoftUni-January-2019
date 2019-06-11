namespace _05.SliceFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class SliceFile
    {
        public static void Main()
        {
            string sourceFile = "sliceMe.txt";
            string destinationDirectory = "../../../";

            int parts = 4;

            using (var fsReader = new FileStream(sourceFile, FileMode.Open))
            {

                int partLenght = (int)Math.Ceiling((double)fsReader.Length / parts);

                for (int i = 1; i <= parts; i++)
                {
                    string currentPartName = $"{destinationDirectory}Part-{i}.txt";

                    using (var fsWriter = new FileStream(currentPartName, FileMode.Create))
                    {
                        var currentFileSize = 0;

                        while (true)
                        {

                            byte[] buffer = new byte[120];
                            var bytesReaded = fsReader.Read(buffer, 0, buffer.Length);

                            if (bytesReaded == 0)
                            {
                                break;
                            }

                            if (currentFileSize >= partLenght)
                            {
                                break;
                            }

                            currentFileSize += bytesReaded;

                            fsWriter.Write(buffer, 0, bytesReaded);
                            fsWriter.Flush();

                        }
                    }
                }


            }


        }
    }
}
