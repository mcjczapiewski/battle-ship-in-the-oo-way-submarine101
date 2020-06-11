
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
        private string Name;
        private int Row = 10;
        private int Column = 10;


        public void Ocean1(string name, int row, int column)
            {
                Square[,] field = new Square[Row,Column];
                this.Name = name;
                this.Row = row;
                this.Column = column;
                var result = field;
                

                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Column; j++)
                    {
                        field[i, j] = new Square(i,j);
                    }
                }
                
            }
        
        public string StringPrinter(char c, int count)
        {
            return (c * count).ToString();
        }

        public class PrintOcean: Ocean
        
        {
            public void Print(int length, int height, string name)
            {
                List<string> alphabet = new List<string>();
                Console.WriteLine();
                Console.WriteLine("   A B C D E F G H I J ");
                for (int i = 0; i < Row; i++)
                {
                    for (int j = 0; j < Column; j++)
                    {
                        Console.Write(Ship.Name);
            }
        }

    }
}

