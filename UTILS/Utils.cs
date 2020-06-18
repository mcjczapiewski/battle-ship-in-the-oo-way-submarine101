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
    }
}
