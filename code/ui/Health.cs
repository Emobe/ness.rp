using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.ui
{
	public class Health : Panel
	{
		public Label Label;

		public Health()
		{
			Label = Add.Label( "100", "value" );

		}

		public override void Tick()
		{
			var player = Game.LocalPawn;
			Label.Text = $"{player.Health.CeilToInt()}";
		}
	}
}
