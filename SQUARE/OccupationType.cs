using System;
using System.Security.Cryptography.X509Certificates;
using battle_ship_in_the_oo_way_submarine101;

namespace battle_ship_in_the_oo_way_submarine101.SQUARE
{
    public class OccupationType
    {
        public static void OccupationSwitch()
        {
            string WhatIsThere = "Battleship";
            switch (WhatIsThere)
            {
                case "Battleship":
                    occupationType = "B";
                    break;
                case Cruiser:
                    "C";
                    break;
                case Carrier:
                    "R";
                    break;
                case Destroyer:
                    "D";
                    break;
                case Submarine:
                    "S";
                    break;
                case Empty:
                    "e";
                    break;
                case Hit:
                    "X";
                    break;
                case Miss:
                    "O";
            }
        }
    }
    // public enum OccupationType
    // {
    //     Battleship = 'B',
    //     Cruiser = 'C',
    //     Carrier = 'R',
    //     Destroyer = 'D',
    //     Submarine = 'S',
    //     Empty = 'e',
    //     Hit = 'X',
    //     Miss = 'O',
    // }
    
    // public class OccupationType
    // {
    //     public char Battleship = 'B';
    //     public char Cruiser = 'C';
    //     public char Carrier = 'R';
    //     public char Destroyer = 'D';
    //     public char Submarine = 'S';
    //     public char Empty = 'e';
    //     public char Hit = 'X';
    //     public char Miss = 'O';
    // }
}


