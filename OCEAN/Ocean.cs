using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using battle_ship_in_the_oo_way_submarine101.Square;
using DefaultNamespace;


namespace battle_ship_in_the_oo_way_submarine101.OCEAN
{
    public abstract class Ocean
    {
        public Square.Square Sqr = new Square.Square(int row, int column);
        public List<List<Square.Square>> Field;
        public string Name = "";
        public int MapSize = Player.MapSize;
       
        public Ocean()
        {
            int i;
            int j;
            for (i = 0; i < Player.MapSize; i++)
            {
                for (j = 0; j < Player.MapSize; j++)
                {
                    Field.Add(new Sqr(i, j));
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
    }
    public class MyBoard() : Ocean /// MyBoard that inheritate from Ocean ///
    {
        public MyBoard() : base()
        {
            mapSize = Player.MapSize;
            name = "This is your board";
        }
    }
    public class EnemyBoard() : Ocean
    {
        public EnemyBoard() : base()
        {
            mapSize = Player.MapSize;
            name = "This is an enemy board";
        }
    }
    
}
