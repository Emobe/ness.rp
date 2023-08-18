using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;

namespace MyGame
{
	public partial class CareerManager
	{
		public static List<Career> Careers { get; private set; }



		public CareerManager() { 
			Careers = new List<Career>();
		}


		public void createCareer( string name, int maxPlayers )
		{
			int id = Careers.Count;
			Career career = new Career( id, name, maxPlayers );
			Careers.Add( career );
			Log.Info( $"Career {career.Name} added" );
		}

		[ConCmd.Server( "career.addPlayer" )]
		public static void AddPlayerToCareer( int careerId, long steamId )
		{
			Career career = getCareerById( careerId );
			if ( career.MaxPlayers > career.Players.Count )
			{
				foreach ( var client in Game.Clients )
				{
					if ( client.SteamId == steamId )
					{
						career.Players.Add( client );
						Log.Info($"Player added to {Careers[careerId].Name}");
					}
				}
			}
		}

		[ClientRpc]
		public static void careerUpdated()
		{
		}

		private static Career getCareerById( int careerId )
		{
			return Careers[careerId];
		}
	}
}
