using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.PLAYER;
using System;
using System.IO;

namespace battle_ship_in_the_oo_way_submarine101
{
    public class MainLogic
    {
        public static Player EnemyPlayer;
        public static Player MainPlayer;

        public static bool IsPlaying()
        {
            if (EnemyPlayer.PlayerShips.Count == 0 || MainPlayer.PlayerShips.Count == 0)
            {
                return false;
            }
            return true;
        }

        public static void Logic()
        {
            CreatePlayersWithBoards(out Player player1,
                                    out Ocean player1Board,
                                    out Ocean emptyPlayer1Board,
                                    out Player player2,
                                    out Ocean player2Board,
                                    out Ocean emptyPlayer2Board);

            do
            {
                PlayerMovement(player1,
                               player2,
                               player1Board,
                               emptyPlayer1Board,
                               player2Board);
                PlayerMovement(player2,
                               player1,
                               player2Board,
                               emptyPlayer2Board,
                               player1Board);
            } while (IsPlaying());
            DoesAnyoneWin(player1, player2);
            Console.WriteLine("Press any button to exit.");
            Console.ReadKey();
            Environment.Exit(1);
        }

        private static void CreatePlayersWithBoards(out Player player1,
                                                    out Ocean player1Board,
                                                    out Ocean emptyPlayer1Board,
                                                    out Player player2,
                                                    out Ocean player2Board,
                                                    out Ocean emptyPlayer2Board)
        {
            UTILS.AsciiArt.Battleship();
            string playerName = Player.PrintMessageToGetInput("PLAYER 1 - Type in your name");
            (player1, player1Board, emptyPlayer1Board) = Player.CreateNewPlayer(playerName);
            MainPlayer = player1;
            playerName = Player.PrintMessageToGetInput("PLAYER 2 - Type in your name or hit ENTER to play with computer");
            (player2, player2Board, emptyPlayer2Board) = Player.CreateNewPlayer(playerName);
            EnemyPlayer = player2;
            Console.Clear();
        }

        private static void DoesAnyoneWin(Player player1, Player player2)
        {
            UTILS.AsciiArt.Battleship();
            if (EnemyPlayer.PlayerShips.Count == 0)
            {
                Console.WriteLine($"\n{player1.Name} wins!\n");
            }
            else
            {
                Console.WriteLine($"\n{player2.Name} wins!\n");
            }
        }

        private static void PlayerMovement(Player mainPlayer,
                                           Player enemyPlayer,
                                           Ocean mainPlayerBoard,
                                           Ocean mainPlayerEmptyBoard,
                                           Ocean enemyPlayerBoard)
        {
            UTILS.AsciiArt.Battleship();
            Console.WriteLine($"This is {mainPlayer.Name} turn.");
            if (mainPlayer.Name != "AI")
            {
                Ocean.PrintBoard(mainPlayerBoard, mainPlayerEmptyBoard);
            }
            mainPlayer.Move(mainPlayerBoard,
                            mainPlayerEmptyBoard,
                            enemyPlayerBoard,
                            enemyPlayer.PlayerShips);
            if (mainPlayer.Name != "AI")
            {
                Console.WriteLine("Press any button to switch players.");
                Console.ReadKey();
            }
            Console.Clear();
        }
    }
}