using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static DefaultNamespace.Square;

namespace battle_ship_in_the_oo_way_submarine101.OCEAN
{
    public abstract class Ocean
    {
        public int length, hight;
        public string name;

        public Ocean(int length, int hight, string name)
        {
            this.length = length;
            this.hight = hight;
            this.name = "setMyName";
        } 
    public class MyBoard() : Ocean /// MyBoard that inheritate from Ocean///
    {
        public MyBoard(int length, int hight, string name) : base(length, hight, name)
        {
            length = 5;
            hight = 5;
            name = "This is your board";
        }
    }

    public class EnemyBoard() : Ocean
    {
        public EnemyBoard(int length, int hight, string name) : base(length, hight, name)
        {
            length = 5;
            hight = 5;
            name = "This is an enemy board";
        }
    }
} 