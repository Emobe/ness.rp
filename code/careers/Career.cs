using MyGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
	internal class Career
	{

		public string Name { get; private set; }
		public List<Weapon> AllowedWeapons { get; private set; }
		public int MaxPlayers { get; private set; }
		public List<Player> Players { get; private set; }

		public Career(string name, int maxPlayers )
		{
			Name = name;
			AllowedWeapons = new List<Weapon>();
			MaxPlayers = maxPlayers;
		}

		public void addPlayer(Player player)
		{
			if ( this.Players.Count < MaxPlayers )
			{
				this.Players.Add( player );
			}
		}

		public bool IsWeaponAllowed(Weapon weapon )
		{
			return AllowedWeapons.Contains( weapon );
		}

	}
}
