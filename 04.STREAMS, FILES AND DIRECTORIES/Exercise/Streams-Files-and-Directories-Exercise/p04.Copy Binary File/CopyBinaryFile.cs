namespace p04.Copy_Binary_File
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        public static void Main()
        {
            string source = "../../../copyMe.png";
            string destinationPath = "../../../output.png";

            using (var fsReader = new FileStream(source, FileMode.Open))
            {
                byte[] buffer = new byte[4096];
                int currentLength = 0;
                using (var fsWriter = new FileStream(destinationPath, FileMode.Create))
                {
                    while (true)
                    {
                        var readedBytes = fsReader.Read(buffer, 0, buffer.Length);
                        
                        if (readedBytes == 0)
                        {
                            break;
                        }

                        currentLength += readedBytes;
                        fsWriter.Write(buffer, 0, readedBytes);
                    }
                }
            }
        }
    }
}
