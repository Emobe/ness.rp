using System.Collections.Generic;

namespace Sandbox
{
	internal class CareerManager
	{
		List<Career> careers;

		public CareerManager() { 
			careers = new List<Career>();
		}

		public void AddCareer(Career career )
		{
			careers.Add( career );
		}

		public bool AddPlayerToCareer(Career career, Player player) { 
			if(career.MaxPlayers < career.Players.Count )
			{
				career.Players.Add(player);
				return true;
			}
			return false;
		}
	}
}
