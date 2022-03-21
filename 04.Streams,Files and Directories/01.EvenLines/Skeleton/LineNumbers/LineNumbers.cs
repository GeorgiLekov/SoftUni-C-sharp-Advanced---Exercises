namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\text.txt";
            string outputPath = @"..\..\..\output.txt";

            ProcessLines(inputPath, outputPath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder result = new StringBuilder();
            string[] lines = File.ReadAllLines(inputFilePath);

            for(int i = 0; i < lines.Length; i++)
            {
                int countOfLetters = lines[i].Count(char.IsLetter);
                int countOfMarks = lines[i].Count(x => char.IsPunctuation(x));
                result.Append($"Line {i+1}: {lines[i]} ({countOfLetters})({countOfMarks})\n");
            }
            File.WriteAllText(outputFilePath, result.ToString().TrimEnd());
        }
    }
}
