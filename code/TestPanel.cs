using System;
using Sandbox;
using Sandbox.UI;

public class TestPanel : Panel
{
	public Label MyLabel { get; set; }

	public TestPanel()
	{
		MyLabel = new Label();
		MyLabel.Parent = this;
	}

	public override void Tick()
	{
		MyLabel.Text = $"allo";
	}

	[GameEvent.Client.BuildInput]
	public void ProcessClientInput()
	{
		if(Input.Pressed( "Main" ) ) {
			RemoveClass( "open" );
		}
	}
}
