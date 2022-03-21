using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.BakeryShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] wateInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            double[] flourInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            Queue<double> water = new Queue<double>(wateInput);
            Stack<double> flour = new Stack<double>(flourInput);

            Dictionary<string, int> result = new Dictionary<string, int>();

            result.Add("Croissant", 0);
            result.Add("Muffin", 0);
            result.Add("Baguette", 0);
            result.Add("Bagel", 0);

            while (water.Count > 0 && flour.Count > 0)
            {
                double waterCalc = water.Peek();
                double flourCalc = flour.Peek();

                double total = waterCalc + flourCalc;

                double percentage = (waterCalc * 100) / total;

                if (percentage == 50.0d)
                {
                    result["Croissant"]++;
                    PopAndDequeue(water, flour);
                }
                else if (percentage == 40.0d)
                {
                    result["Muffin"]++;
                    PopAndDequeue(water, flour);
                }
                else if (percentage == 30.0d)
                {
                    result["Baguette"]++;
                    PopAndDequeue(water, flour);
                }
                else if (percentage == 20.0d)
                {
                    result["Bagel"]++;
                    PopAndDequeue(water, flour);
                }
                else
                {
                    if (flourCalc > waterCalc)
                    {
                        double putBackIn = flourCalc - waterCalc;
                        result["Croissant"]++;
                        flour.Pop();
                        flour.Push(putBackIn);
                        water.Dequeue();
                    }
                    else if (flourCalc == waterCalc)
                    { 
                        result["Croissant"]++;
                        PopAndDequeue(water, flour);
                    }
                    else
                    {
                        PopAndDequeue(water, flour);
                    }
                }
            }

            if (result["Croissant"] == 0)
            {
                result.Remove("Croissant");
            }
            if (result["Muffin"] == 0)
            {
                result.Remove("Muffin");
            }
            if (result["Baguette"] == 0)
            {
                result.Remove("Baguette");
            }
            if (result["Bagel"] == 0)
            {
                result.Remove("Bagel");
            }

            result = result.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(k => k.Key, v => v.Value);
            foreach(var item in result)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            if (water.Count > 0)
            {
                //"Water left: { water1}, { water2}, { water3}, (…)"
                Console.WriteLine("Water left: " + string.Join(", ",water));
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            //"Flour left: { flour1}, { flour2}, { flour3}, (…)"

            if (flour.Count > 0)
            {
                //"Water left: { water1}, { water2}, { water3}, (…)"
                Console.WriteLine("Flour left: " + string.Join(", ", flour));
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }

        private static void PopAndDequeue(Queue<double> water, Stack<double> flour)
        {
            water.Dequeue();
            flour.Pop();
        }
    }
}
