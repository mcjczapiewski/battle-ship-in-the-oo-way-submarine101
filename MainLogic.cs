using System;
using System.Diagnostics;
using System.IO;
using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.PLAYER;
using battle_ship_in_the_oo_way_submarine101;

namespace battle_ship_in_the_oo_way_submarine101
{
    public class MainLogic
    {

        public static void Logic()
        {
            AsciiArt();
            Console.WriteLine("PLAYER 1");
            (var player1, var player1Board, var emptyPlayer1Board) = Player.CreateNewPlayer();
            Console.WriteLine("PLAYER 2");
            (var player2, var player2Board, var emptyPlayer2Board) = Player.CreateNewPlayer();
            Console.Clear();
            //Player currentPlayer = player1;

            do
            {
                AsciiArt();
                Console.WriteLine($"This is {player1.Name} turn.");
                Ocean.PrintBoard(player1Board, emptyPlayer2Board);
                player1.Move(player1Board,
                                  emptyPlayer2Board,
                                  player2Board);
                Console.WriteLine("Press any button to switch players.");
                Console.ReadKey();
                Console.Clear();
                AsciiArt();
                Console.WriteLine($"This is {player2.Name} turn.");
                Ocean.PrintBoard(player2Board, emptyPlayer1Board);
                player2.Move(player2Board,
                                  emptyPlayer1Board,
                                  player1Board);
                Console.WriteLine("Press any button to switch players.");
                Console.ReadKey();
                Console.Clear();
            } while (IsPlaying());

            Environment.Exit(0);
        }

        public static bool IsPlaying()
        {
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                return true;
            }

            return false;
        }

        public static void AsciiArt()
        {
            try
            {
                // Open the text file using a stream reader.
                using StreamReader sr =
                    new StreamReader("NewFile1.txt");
                // Read the stream to a string, and write the string to the console.
                Console.ForegroundColor = ConsoleColor.Green;
                String line = sr.ReadToEnd();
                Console.WriteLine(line);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
