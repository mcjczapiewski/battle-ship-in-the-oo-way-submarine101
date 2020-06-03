using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static DefaultNamespace.Square;

namespace battle_ship_in_the_oo_way_submarine101.OCEAN
{
    public abstract class Ocean
    {
        public OccupationType OccupationType { get; set; }
        public Coordinates Coordinates { get; set;}
        public int length;
        public int hight;
        public string name;
        public List<int> borders;

        public Ocean(int length, int hight, string name, List<int> borders)
        {
            this.length = length;
            this.hight = hight;
            this.name = "setMyName";
            this.borders = borders;
        }

        public string StringPrinter(char c, int count)
        {
            return (c * count).ToString();
        }
        
        public void PrintOcean(int length, int hight, string name)
        {
            Console.WriteLine(string.Format());
        }

        public void PlaceShips
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        
        public class MyBoard() : Ocean /// MyBoard that inheritate from Ocean ///
    {
        public MyBoard(int length, int hight, string name, List<int> borders) : base(length, hight, name, borders)
        {
            length = 5;
            hight = 5;
            name = "This is your board";
        }
    }

    public class EnemyBoard() : Ocean
    {
        public EnemyBoard(int length, int hight, string name, List<int> borders) : base(length, hight, name, borders)
        {
            length = 5;
            hight = 5;
            name = "This is an enemy board";
        }
    }
    
}
