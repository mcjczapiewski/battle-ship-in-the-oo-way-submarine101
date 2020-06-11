using System;
using System.Collections.Generic;
using System.Text;

namespace battle_ship_in_the_oo_way_submarine101
{
    class OutputScreen
    {
        public static void ShowIntroScreen()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("#######################################");
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("        Welcome to Batttleship!      ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("#");
            Console.WriteLine("#######################################");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
        }

        public static void Header()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("#######################################");
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("             Batttleship!            ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("#");
            Console.WriteLine("#######################################");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
        }
    }
}
