using Sandbox;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyGame;
public class Admin
{

	static Dictionary<int, IClient> clients = new Dictionary<int, IClient>();
	public Admin()
	{
		Log.Info( "Admin started" );
		Event.Register( this );
	}

	[GameEvent.Server.ClientJoined]
	public void onClientJoin( ClientJoinedEvent e )
	{
		Log.Info( "Added client" );
		clients.Add( e.Client.Id, e.Client );
	}

	[GameEvent.Server.ClientDisconnect]
	public void onClientDisconnect( ClientDisconnectEvent e )
	{
		clients.Remove( e.Client.Id );
	}

	[ConCmd.Server( "Teleport" )]
	public static void Teleport( int clientId )
	{
		Log.Info( "Teleport" );
		Log.Info( clientId );

		clients[clientId].Pawn.Position = Vector3.Zero;
	}

	[ConCmd.Server("Kick")]
	public static void Kill(int clientId)
	{
		clients[clientId].Kick();
	}


}
