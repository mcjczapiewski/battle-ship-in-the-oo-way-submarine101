namespace battle_ship_in_the_oo_way_submarine101.UTILS
{
    internal class Utils
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
            return number switch
            {
                1 => "A",
                2 => "B",
                3 => "C",
                4 => "D",
                5 => "E",
                6 => "F",
                7 => "G",
                8 => "H",
                9 => "I",
                10 => "J",
                _ => "A",
            };
        }
    }
}