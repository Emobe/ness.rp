using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;

namespace MyGame
{
	internal partial class CareerManager
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

		//[ConCmd.Server( "career.addPlayer" )]
		public static void AddPlayerToCareer( int careerId, IClient client )
		{
			Career career = getCareerById( careerId );
			// Check player is not already in career
			if ( career.Players.Contains( client ) )
			{
				Log.Error( "Client is already in career" );
				return;
			}

			if ( career.Players.Count < career.MaxCount)
			{
				Log.Info( $"{client.Name} added to {career.Name}" );
				career.addPlayer( client );

				Pawn pawn = (Pawn)client.Pawn;
				pawn.Career = career;
				//pawn.SetActiveWeapon( new Crossbow() ) ;
			}

		}

		public static void removePlayerFromCareer(int careerId, IClient client )
		{

		}

		private static Career getCareerById( int careerId )
		{
			return Careers[careerId];
		}
	}
}
