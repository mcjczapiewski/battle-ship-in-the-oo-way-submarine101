using System;
using battle_ship_in_the_oo_way_submarine101;

namespace battle_ship_in_the_oo_way_submarine101.SHIP
{
	public class Destroyer : Ship
	{
		public Destroyer(string name, int length, int shots, char occupationType, bool isSink) : base(name, length, shots, occupationType, isSink)
		{
		}
	}
}
