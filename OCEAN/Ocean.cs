using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Resources;
using System.Security.Cryptography.X509Certificates;
using battle_ship_in_the_oo_way_submarine101.SHIP;
using battle_ship_in_the_oo_way_submarine101.SQUARE;

namespace battle_ship_in_the_oo_way_submarine101.OCEAN

{
    public class Ocean
    {
        public const int XSize = 10;
        public const int YSize = 10;


        static string NumberToLetter(int number)
        {
            string result = "";
            switch (number)
            {
                case 1:
                    result = "A";
                    break;
                case 2:
                    result = "B";
                    break;
                case 3:
                    result = "C";
                    break;
                case 4:
                    result = "D";
                    break;
                case 5:
                    result = "E";
                    break;
                case 6:
                    result = "F";
                    break;
                case 7:
                    result = "G";
                    break;
                case 8:
                    result = "H";
                    break;
                case 9:
                    result = "I";
                    break;
                case 10:
                    result = "J";
                    break;
                default:
                    break;
            }
            return result;
        }
        public static void DrawBoard()
        {
            Console.WriteLine("Your Board:                              Firing Board:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("  ");
            for (int y = 1; y <= 10; y++)
            {
                Console.Write(y);
                Console.Write(" ");
            }
            Console.Write("                   ");
            for (int y = 1; y <= 10; y++)
            {
                Console.Write(" ");
                Console.Write(y);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            for (int x = 1; x <=10; x++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(NumberToLetter(x));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|");
                //my board
                for (int y = 1; y <=10; y++)
                {
                    //instead of empty character, there will be more code for square status
                    Console.Write(" ");
                    Console.Write("|");
                }
                Console.Write("                   ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(NumberToLetter(x));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("|");
                //shooting board
                for (int y = 1; y <= 10; y++)
                {
                    //instead of empty character there will be mroe code for square status
                    Console.Write(" ");
                    Console.Write("|");
                }
                Console.WriteLine(" ");
            }

        }
    }
}

