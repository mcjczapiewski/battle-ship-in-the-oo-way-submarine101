using System;
using battle_ship_in_the_oo_way_submarine101.OCEAN;
using battle_ship_in_the_oo_way_submarine101.SQUARE;

namespace battle_ship_in_the_oo_way_submarine101.SHIP
{
    public class Ship
    {
<<<<<<< HEAD

=======
>>>>>>> c324326ea5332dbbe3797a85cf600b001a0dcde8
        public string Name;
        public int Life;
        public int CoordX;
        public int CoordY;
<<<<<<< HEAD

=======
>>>>>>> c324326ea5332dbbe3797a85cf600b001a0dcde8
        public bool IsSunk
        {
            get
            {
                return Life == 0;
            }
        }
<<<<<<< HEAD

        public Ship(ShipEnum shipType, int life)

        {
            
=======
        public Ship(string name, int life)
        {
            this.Name = name;
>>>>>>> c324326ea5332dbbe3797a85cf600b001a0dcde8
            this.Life = life;
        }
        //instances of ships and their corresponding lifes
        //Ship Ship1 = new Ship("Destroyer", 2);
        //Ship Ship2 = new Ship("Cruiser", 3);
        //Ship Ship3 = new Ship("Submarine", 3);
        //Ship Ship4 = new Ship("Battleship", 4);
        //Ship Ship5 = new Ship("Carrier", 5);

        public static void PlaceShipHorizontal(int coordX, int coordY, int life)
        {
<<<<<<< HEAD
            var maxY = coordY + newShip.Life;

            for (var i = coordY; i < maxY; i++)
                //check if coordinates is valid
                //check if there is no other ship?
                Square.UpdateOccupationToShip(coordX, i);
        }
=======
            Square square = Ocean.arrayOfSquares[coordX, coordY];
            int maxY = coordY + life;
            if (square.IsItFree == true)
            {
                for (int i = coordY; i < maxY; i++)

                    //check if coordinates is valid
>>>>>>> c324326ea5332dbbe3797a85cf600b001a0dcde8

                    Square.UpdateOccupationToShip(i, coordY);
            }
            else
            {
                Console.Write("Cant place there is ship");
            }
        }
        public static void PlaceShipVertical(int coordX, int coordY, int life)
        {
<<<<<<< HEAD
            var maxX = coordX + newShip.Life;

            for (var i = coordX; i < maxX; i++)
                //check if coordinates is valid
                //check if there is no other ship?
                Square.UpdateOccupationToShip(i, coordY);
        }

        public static void PlaceShipHorizontal(int coordX, int coordY, int life)
        {
            Square square = Ocean.arrayOfSquares[coordX, coordY];
            int maxY = coordY + life;
            if (square.IsItFree == true)
            {
                for (int i = coordY; i < maxY; i++)

                    //check if coordinates is valid

                    Square.UpdateOccupationToShip(coordX, i);
            }
            else
            {
                Console.Write("Cant place there is ship");
            }
        }
        public static void PlaceShipVertical(int coordX, int coordY, int life)
        {
            Square square = Ocean.arrayOfSquares[coordX, coordY];
            int maxX = coordX + life;
            if (square.IsItFree == true)
            {
                for (int i = coordX; i < maxX; i++)
                    //check if coordinates is valid
                    Square.UpdateOccupationToShip(i, coordY);
            }
            else
            {
                Console.Write("Cant place there is ship");
            }
        }
        public static void PlaceShip(int coordX, int coordY, int life, bool Horizontal)
        {
            if (Horizontal == true)

            {
                PlaceShipHorizontal(coordX, coordY, life);
            }
            else
            {
                PlaceShipVertical(coordX, coordY, life);
            }
        }

=======
            Square square = Ocean.arrayOfSquares[coordX, coordY];
            int maxX = coordX + life;
            if (square.IsItFree == true)
            {
                for (int i = coordX; i < maxX; i++)
                    //check if coordinates is valid
                    Square.UpdateOccupationToShip(coordX, i);
            }
            else
            {
                Console.Write("Cant place there is ship");
            }
        }
        public static void PlaceShip(int coordX, int coordY, int life, bool Horizontal)
        {
            if (Horizontal == true)
            {
                PlaceShipHorizontal(coordX, coordY, life);
            }
            else
            {
                PlaceShipVertical(coordX, coordY, life);
            }
        }

>>>>>>> c324326ea5332dbbe3797a85cf600b001a0dcde8
    }
}