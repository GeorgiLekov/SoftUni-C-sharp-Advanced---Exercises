namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main(string[] args)
        {
            string inputPath = Console.ReadLine();
            string outputPath = Console.ReadLine();

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath);
            }

            string[] filesPath = Directory.GetFiles(inputPath);

            foreach(var filePath in filesPath)
            {
                string fileName = outputPath + "/" + Path.GetFileName(filePath);
                File.Copy(filePath, outputPath);
            }
        }
    }
}
