using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();
            Stack<string[]> previousCommand = new Stack<string[]>();
            Stack<char> charactersPopped = new Stack<char>();

            for(int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();

                switch (command[0])
                {
                    case "1":
                        result.Append(command[1]);
                        break;
                    case "2":
                        int charToRemove = int.Parse(command[1]);
                        if (charToRemove <= result.Length)
                        {
                            for(int m = 0; m < charToRemove; m++)
                            {
                                charactersPopped.Push(result[result.Length - 1]);
                                result.Remove(result.Length - 1, 1);
                            }
                        }
                        break;
                    case "3":
                        int index = int.Parse(command[1]) - 1;
                        if (index >= 0 && index < result.Length)
                        {
                            Console.WriteLine(result[index]);
                        }
                        break;
                    case "4":
                        string[] lastOrder = previousCommand.Pop();
                        string lastCase = lastOrder[0];
                        string lastContent = lastOrder[1];

                        switch (lastCase)
                        {
                            case "1":
                                int lastCharsToRemove = lastContent.Length;
                                result.Remove(result.Length - lastCharsToRemove, lastCharsToRemove);
                                break;
                            case "2":
                                int bringThisManyBack = int.Parse(lastContent);
                                for(int k = 0; k < bringThisManyBack && charactersPopped.Count > 0; k++)
                                {
                                    result.Append(charactersPopped.Pop());
                                }
                                break;
                        }
                        break;
                    default:
                        break;
                }
                if(command[0]=="1"||command[0]=="2") previousCommand.Push(command);
            }
        }
    }
}
