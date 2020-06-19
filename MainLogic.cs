using System;
using System.IO;

namespace battle_ship_in_the_oo_way_submarine101
{
    public class MainLogic
    {

        public static void Test()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader("/home/pat/homework/c#/battle-ship-in-the-oo-way-submarine101/NewFile1.txt"))
                {
                    // Read the stream to a string, and write the string to the console.
                    Console.ForegroundColor = ConsoleColor.Green;
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}