using battle_ship_in_the_oo_way_submarine101.SQUARE;
using System;

namespace battle_ship_in_the_oo_way_submarine101.OCEAN
{
    public class Ocean
    {
        public Square[,] ArrayOfSquares = new Square[10, 10];
        private static readonly string space = new string(' ', 15);
        private static int CoordX;
        private static int CoordY;
        private readonly string Name;

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
            Console.WriteLine("    " + ocean.Name + space + space + space + secondOcean.Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   A  B  C  D  E  F  G  H  I  J"
                              + space
                              + "    A  B  C  D  E  F  G  H  I  J");
            Console.ResetColor();
            for (CoordY = 0; CoordY < 10; CoordY++)
            {
                PrintBoardLegendInYellow((CoordY + 1).ToString());
                PrintOcean(ocean);
                PrintBoardLegendInYellow(space + (CoordY + 1).ToString());
                PrintOcean(secondOcean);
                Console.WriteLine();
            }
            Console.Write("\n\n");
        }

        private static void PrintBoardLegendInYellow(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message);
            Console.ResetColor();
            if (CoordY != 9)
            {
                Console.Write(" ");
            }
        }

        private static void PrintOcean(Ocean oceanToPrint)
        {
            for (CoordX = 0; CoordX < 10; CoordX++)
            {
                Console.Write(" "
                              + oceanToPrint.ArrayOfSquares[CoordX, CoordY].Sign);
            }
        }
    }
}