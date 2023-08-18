using MyGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;

namespace MyGame
{
	public partial class Career
	{

		public string Name { get; private set; }
		public List<Weapon> AllowedWeapons { get; private set; }
		public int MaxPlayers { get; private set; }
		public List<IClient> Players { get; private set; }

		public int Id { get; private set; }

		public Career(int id, string name, int maxPlayers )
		{
			Name = name;
			AllowedWeapons = new List<Weapon>();
			MaxPlayers = maxPlayers;
			this.Players = new List<IClient>();
		}

		public void addPlayer(IClient client)
		{
			if ( this.Players.Count < MaxPlayers )
			{
				this.Players.Add( client );
			}
		}

		public bool IsWeaponAllowed(Weapon weapon )
		{
			return AllowedWeapons.Contains( weapon );
		}

		public int Count { get { return this.Players.Count;} }
		public int MaxCount {  get { return this.MaxPlayers; } }

	}
}
