using System;
using System.IO;
using battle_ship_in_the_oo_way_submarine101.OCEAN;

namespace battle_ship_in_the_oo_way_submarine101
{
    public class MainLogic
    {
        Ocean EnemyBoard = new Ocean("Enemy Board");
        Ocean MyBoard = new Ocean("My board");
        Ocean EmptyMyBoard = new Ocean("Empty My Board");
        Ocean EmptyEnemyBoard = new Ocean("Empty My Board");

        public static void Logic()
        {
            void switchPlayer(int player)
            {
                if (player == 1)
                {
                    Ocean.PrintBoard(MyBoard);
                    Ocean.PrintBoard(EmptyEnemyBoard);
                }
                else if (player == 2)
                {
                    Ocean.PrintBoard(EnemyBoard);
                    Ocean.PrintBoard(EmptyMyBoard);
                }
            }
        }


        public static void Test()
        {
            try
            {
                // Open the text file using a stream reader.
                using (StreamReader sr =
                    new StreamReader("/home/pat/homework/c#/battle-ship-in-the-oo-way-submarine101/NewFile1.txt"))
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
