using battle_ship_in_the_oo_way_submarine101.SHIP;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace battle_ship_in_the_oo_way_submarine101.SHIP
{
    public class PlaceShips
    {   
        var InputRow;
        var InputColumn;
        var InputIsHorizontal;
        var UpperInputIsHorizontal;
        var StartRow = InputRow;
        var StartColumn = InputColumn;
        /// <summary>
        /// 1. Input from player - question - do we convert A B C D etc to number? TODO
        /// 2. Checks if this input is free 
        /// 3. Start placing ship depending on input and lenght - suggestion prepared i think will have to change?
        /// 4. check if there is no boundary
        /// 5. check if there is no ship
        /// 6. need to do it for every ship players have
        /// 7. do we need to switch between players or re-run the same function?
        /// </summary>
        public void PlayerInput()
        {   /// gets row and column from player and asks whether horisontal or vertival ///
            Console.Write("Select row:");
            InputRow = Console.ReadLine();
            Console.Write("Select column:");
            InputColumn = Console.ReadLine();
            Console.Write("Ship will be horizontal or vertical? H/V");
            InputIsHorizontal = Console.ReadLine();
            UpperInputIsHorizontal = InputIsHorizontal.ToUpper();
            if (UpperInputIsHorizontal == "H")
            {
                IsHorizontal = true;
            }
            else
            {
                IsHorizontal = false;
            }
        }

        public void PlaceShip()
        { /// checks if square is ok, i made for now IsOpen we can change whatever Maciek named there then starts placing ship ///
            bool IsOpen = true;
            while (IsOpen)
            {///dont know what the list is named so a did ocean for now - here we start switching the lines with ships///
                List<int> Ocean = new List<int>();
                if (IsHorizontal = true)
                {
                    for (int i = 1; i < Ship.lenght; i++)
                    {
                        StartRow++;
                    }
                }
                else
                {
                    for (int i = 1; i < Ship.lenght; i++)
                    {
                        StartColumn++;
                    }
                }
                /// check if there are boundaries, i used 10, i think there will be variable to switch board size?////
                if (StartRow > 10 || StartColumn > 10)
                {
                    IsOpen = true;
                    continue;
                }
                else
                {
                    Console.Write("Cannot put ship here. Enter new coordination.");
                    /// condition to repeat action ///
                }
                ///another check if there is no other ship///
            }
        }
    }
}
