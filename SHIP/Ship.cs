using battle_ship_in_the_oo_way_submarine101.SQUARE;
using System;
using System.Security.Cryptography;
using battle_ship_in_the_oo_way_submarine101.OCEAN;
using System.Linq;

namespace battle_ship_in_the_oo_way_submarine101.SHIP
{
    public class Ship
    {
        public Ships Ships;
        public string Name;
        public int Life;
        public int Shots;
        public char OccupationType;
        public Coordinates[] OceanPositions;

        public bool IsSink
        {
            get
            {
                return Shots >= Life;
            }
        }

        public Ship(Ships ships, int lifes)
        {
            Ships = ships;
            Life = lifes;
            OceanPositions = new Coordinates[lifes];
        }
        public GameStatus ShootingShip(Coordinates position)
        {
            if (OceanPositions.Contains(position))
            {
                Life--;
                if (Life == 0)
                {
                    return GameStatus.HitAndSunk;
                }
                return GameStatus.Hit;
            }
            return GameStatus.Miss;
        }
    }
}