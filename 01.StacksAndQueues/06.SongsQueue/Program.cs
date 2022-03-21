using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputSongs = Console.ReadLine().Split(", ").ToArray();

            Queue<string> songs = new Queue<string>(inputSongs);

            while (songs.Count > 0)
            {
                string[] command = Console.ReadLine().Split().ToArray();

                switch (command[0]) 
                {
                    case "Add":
                        string newSong = string.Empty;

                        for (int i = 1; i < command.Length; i++)
                        {
                            newSong += command[i];
                            if (!(i + 1 == command.Length))
                            {
                                newSong += " ";
                            }
                        }

                        if (!songs.Contains(newSong))
                        {
                            songs.Enqueue(newSong);
                        }
                        else
                        {
                            Console.WriteLine($"{newSong} is already contained!");
                        }
                        break;

                    case "Play":
                        songs.Dequeue();
                        break;

                    case "Show":
                        Console.WriteLine(string.Join(", ",songs));
                        break;
                }
            }

            Console.WriteLine("No more songs!");

        }
    }
}
