﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
	internal class Player
	{

		public string SteamName { get; private set; }
		public long SteamId { get; private set; }

		public Player(IClient client )
		{
			SteamName = client.Name;
			SteamId = client.SteamId;
		}



	}
}
