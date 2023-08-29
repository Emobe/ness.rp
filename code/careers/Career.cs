using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;

namespace MyGame
{
	public partial class Career : Entity
	{

		public string Name { get; private set; }
		public List<Weapon> AllowedWeapons { get; private set; }
		public int MaxPlayers { get; private set; }
		[Net]
		public List<IClient> Players { get; private set; }

		public int Id { get; private set; }

		public Career(int id, string name, int maxPlayers )
		{
			Id = id;
			Name = name;
			//AllowedWeapons = new List<Weapon>();
			MaxPlayers = maxPlayers;
			this.Players = new List<IClient>();
		}

		public void addPlayer(IClient client)
		{
			if ( this.Players.Count < MaxPlayers )
			{
				this.Players.Add( client );
				Log.Info( $"{client.Name} added to {this.Name}" );
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
