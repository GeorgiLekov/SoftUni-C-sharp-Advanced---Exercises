namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            char[] symbols = { '-', ',', '.', '!', '?' };
            StreamReader streamReader = new StreamReader(inputFilePath);
            StringBuilder result = new StringBuilder();
            int count = 0;
            while (true)
            {
                string line = streamReader.ReadLine();

                if (line == null)
                {
                    break;
                }


                if (count % 2 != 0)
                {
                    count++;
                    continue;
                }

                foreach (char symbol in symbols)
                {
                    line = line.Replace(symbol, '@');
                }
                line = string.Join(" ", line.Split().Reverse());
                result.Append(line);

                count++;
            }
            return result.ToString().TrimEnd();
        }
        private static string ReverseWords(string replacedSymbols)
        {
            throw new NotImplementedException();
        }

        private static string ReplaceSymbols(string line)
        {
            throw new NotImplementedException();
        }
    }

}
