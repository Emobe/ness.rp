using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.admin
{
	internal class User
	{

		private static Dictionary<long, User> Users;

		public string SteamID { get; set; }
		public string UUID { get; set; }

		void Load()
		{
		}

		void Add(IClient client )
		{
			Users.Add( client.SteamId, new User() );
		}

		[GameEvent.Server.ClientJoined]
		public void ClientJoined(ClientJoinedEvent e){
			Add( e.Client );
		}
	}
}
