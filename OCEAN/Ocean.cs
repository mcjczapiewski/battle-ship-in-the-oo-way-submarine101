using battle_ship_in_the_oo_way_submarine101.SQUARE;
using System;

namespace battle_ship_in_the_oo_way_submarine101.OCEAN
{
    public class Ocean
    {
        private string Name;
        private static int CoordX;
        private static int CoordY;
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

        public static void PrintBoard(Ocean ocean, Ocean secondOcean)

        {
            string space = new string(' ', 15);
            Console.WriteLine("    " + ocean.Name + space + space + secondOcean.Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   A  B  C  D  E  F  G  H  I  J"
                              + space
                              + "    A  B  C  D  E  F  G  H  I  J");
            Console.ForegroundColor = ConsoleColor.White;
            for (CoordY = 0; CoordY < 10; CoordY++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write((CoordY + 1));
                Console.ForegroundColor = ConsoleColor.White;
                if (CoordY != 9)
                {
                    Console.Write(" ");
                }
                Console.ForegroundColor = ConsoleColor.White;
                for (CoordX = 0; CoordX < 10; CoordX++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" "
                                  + ocean.ArrayOfSquares[CoordX, CoordY].Sign);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(space + (CoordY + 1));
                if (CoordY != 9)
                {
                    Console.Write(" ");
                }
                Console.ResetColor();
                for (CoordX = 0; CoordX < 10; CoordX++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" "
                                  + secondOcean.ArrayOfSquares[CoordX, CoordY].Sign);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
            Console.Write("\n\n");
        }
    }
}