using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.PLAYER;
using battle_ship_in_the_oo_way_submarine101.SHIP;
using battle_ship_in_the_oo_way_submarine101.SQUARE;

namespace battle_ship_in_the_oo_way_submarine101.SQUARE
{
    public class Square
    { // można wyrzucić - na potrzeby testu ponizszy blok kodu
        
        private int CoordX;
        private int CoordY;
        public char Sign;

        public Square(int coordX, int coordY, char sign='W')
        {
            this.Sign = sign;
            this.CoordX = coordX;
            this.CoordY = coordY;
        }

        
    }
}