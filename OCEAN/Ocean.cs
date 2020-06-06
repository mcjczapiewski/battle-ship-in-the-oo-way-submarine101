
using System;
using System.Collections.Generic;
using battle_ship_in_the_oo_way_submarine101.SQUARE;

namespace battle_ship_in_the_oo_way_submarine101.OCEAN

{
    public class Ocean
    {

            public Array Field;
            public string Name;
            public int MapSize;
            
           
            public Ocean(Array field, string name, int mapSize)
            {
                Field = field;
                Name = name;
                MapSize = mapSize;
                
                

                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < MapSize; j++)
                    {
                        Field[i, j] = new Square(i,j);
                    }
                }
            }
        
            public string StringPrinter(char c, int count)
            {
                return (c * count).ToString();
            }
        
        public void PrintOcean(int length, int height, string name)
        {
            List<string> alphabet = new List<string>();
            Console.WriteLine();
            Console.WriteLine("   A B C D E F G H I J ");
            foreach (var fld in Field)
            {
                Console.Write(Sqr.SignOnMap);
            }
            
        }
        
    //
    //     public static List<Square> Squares { get; set; }
    //
    //     public Ocean()
    //     {
    //         // int[,] Squares = new int[10, 10];
    //
    //         Squares = new List<Square>();
    //         for (int i = 1; i <= 10; i++)
    //         {
    //             for (int j = 1; j <= 10; j++)
    //             {
    //                 Squares.Add(new Square(i, j));
    //             }
    //         }
    //     }
    //
    //     public static void OutputBoards()
    //     {
    //         // Console.WriteLine(Player.Name);
    //         Console.WriteLine("Own Board:                          Firing Board:");
    //         for (int row = 1; row <= 10; row++)
    //
    //         {
    //             for (int ownColumn = 1; ownColumn <= 10; ownColumn++)
    //             {
    //                 Console.Write(Ocean.Squares.At(row, ownColumn).Status + " ");
    //             }
    //
    //             Console.Write("                ");
    //             for (int firingColumn = 1; firingColumn <= 10; firingColumn++)
    //             {
    //                 Console.Write(EnemyBoard.Squares.At(row, firingColumn).Status + " ");
    //             }
    //
    //             Console.WriteLine(Environment.NewLine);
    //         }
    //
    //         Console.WriteLine(Environment.NewLine);
    //     }
    // }
}

