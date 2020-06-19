using System;
using System.Collections.Generic;
using System.Text;

namespace battle_ship_in_the_oo_way_submarine101.UTILS
{
    class Utils
    {
        public static int LetterToNumber(string letter)
        {
            return (letter.ToLower()) switch
            {
                "a" => 0,
                "b" => 1,
                "c" => 2,
                "d" => 3,
                "e" => 4,
                "f" => 5,
                "g" => 6,
                "h" => 7,
                "i" => 8,
                "j" => 9,
                _ => 10,
            };
        }
        public static string NumberToLetter(int number)
        {
            string result = "";
            switch (number)
            {
                case 1:
                    return "A";
                case 2:
                    return "B";
                case 3:
                    return "C";
                case 4:
                    return "D";
                case 5:
                    return "E";
                case 6:
                    return "F";
                case 7:
                    return "G";
                case 8:
                    return "H";
                case 9:
                    return "I";
                case 10:
                    return "J";
                default:
                    break;
            }
            return result;
        }
    }
}
