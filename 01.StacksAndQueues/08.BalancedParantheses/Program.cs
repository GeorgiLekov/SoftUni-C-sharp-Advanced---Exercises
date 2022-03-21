using System;
using System.Collections.Generic;

namespace _08.BalancedParantheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();

            Stack<char> openBrackets = new Stack<char>();

            for(int i = 0; i < sequence.Length; i++)
            {
                if(sequence[i]=='{'|| sequence[i] == '('|| sequence[i] == '[')
                {
                    openBrackets.Push(sequence[i]);
                }
                else if(sequence[i] == '}')
                {
                    if ((openBrackets.Count>0) && openBrackets.Peek() == '{')
                    {
                        openBrackets.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (sequence[i] == ')')
                {
                    if ((openBrackets.Count > 0) && openBrackets.Peek() == '(')
                    {
                        openBrackets.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (sequence[i] == ']')
                {
                    if ((openBrackets.Count > 0) && openBrackets.Peek() == '[')
                    {
                        openBrackets.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
            Console.WriteLine("YES");
        }
    }
}
