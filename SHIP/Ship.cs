using System;

namespace battle_ship_in_the_oo_way_submarine101.SHIP
{
    public class Ship
    {
        public ShipEnum ShipType;
        public string Name;
        public int Life;
        public bool IsHorizontal;
        //public coordinates
        public bool IsSunk 
        { 
            get 
            {
                return Life == 0;
            }
        }
        public Ship(ShipEnum shipType, int life)
        {
            ShipType = shipType;
            Life = life;
        }
        public void PlaceShipHorizontal()
        {
            throw new NotImplementedException();
        }

        public void PlaceShipVertical()
        {
            throw new NotImplementedException();
        }
    }
}