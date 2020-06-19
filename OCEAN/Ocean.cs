using battle_ship_in_the_oo_way_submarine101.SQUARE;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using battle_ship_in_the_oo_way_submarine101.UTILS;

namespace battle_ship_in_the_oo_way_submarine101.OCEAN
{
    public class Ocean
    {
        private string Name;
        static int CoordX;
        static int CoordY;
        public Square[,] ArrayOfSquares = new Square[10, 10];
        
        public Ocean(string name, Square[,] arrayOfSquares)
        {
            if (name != null) Name = name;

            for (CoordX = 0; CoordX < 10; CoordX++)
            {
                for (CoordY = 0; CoordY < 10; CoordY++)
                {
                    arrayOfSquares[CoordX, CoordY] = new Square(CoordX, CoordY);
                }
            }
            this.ArrayOfSquares = arrayOfSquares;

        }

        public static void PrintBoard(Ocean ocean)
        
        {   
            Console.WriteLine("    " + ocean.Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   A  B  C  D  E  F  G  H  I  J");
            Console.ForegroundColor = ConsoleColor.White;
            for (CoordY = 0; CoordY < 10; CoordY++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(CoordY + 1);
                Console.ForegroundColor = ConsoleColor.White;
                if (CoordY != 9)
                {
                    Console.Write(" ");
                }
                Console.ForegroundColor = ConsoleColor.White;
                for (CoordX = 0; CoordX < 10; CoordX++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" " + ocean.ArrayOfSquares[CoordX, CoordY].Sign);
                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.WriteLine();
            }
            Console.Write("\n\n");

            //Console.WriteLine(square.Sign);
        }
        
        //public static void DrawBoard()
        //{
        //    Ocean ocean = new Ocean("a");
        //    Console.WriteLine("          Your Board:                                    Firing Board:");
        //    Console.ForegroundColor = ConsoleColor.Yellow;
        //    Console.Write("  ");
        //    for (int CoordY = 1; CoordY <= 10; CoordY++)
        //    {
        //        Console.Write(" " + CoordY);
        //        Console.Write(" ");
        //    }
        //    Console.Write("                    ");
        //    for (int CoordY = 1; CoordY <= 10; CoordY++)
        //    {
        //        Console.Write(" ");
        //        Console.Write(" " + CoordY);
        //    }
        //    Console.WriteLine();
        //    Console.ForegroundColor = ConsoleColor.White;
        //    for (int CoordX = 1; CoordX <=10; CoordX++)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Yellow;
        //        Console.Write(Utils.NumberToLetter(CoordX)+ " ");
        //        Console.ForegroundColor = ConsoleColor.White;
        //        Console.Write("|");
        //        //my board
        //        for (int CoordY = 1; CoordY <=10; CoordY++)
        //        {
        //            //instead of empty character, there will be more code for square status
        //            Console.Write(arrayOfSquares[CoordX-1, CoordY-1].Sign);
        //            Console.Write("|");
        //        }
        //        Console.Write("                   ");
        //        Console.ForegroundColor = ConsoleColor.Yellow;
        //        Console.Write(Utils.NumberToLetter(CoordX)+ " ");
        //        Console.ForegroundColor = ConsoleColor.White;
        //        Console.Write("|");
        //        //shooting board
        //        for (int CoordY = 1; CoordY <= 10; CoordY++)
        //        {
        //            //instead of empty character there will be mroe code for square status
                   
        //            Console.Write(arrayOfSquares[CoordX-1, CoordY-1].Sign);
                    
        //            Console.Write("|");
        //        }
        //        Console.WriteLine(" ");
        //    }

            
        //}
    
    }
}
