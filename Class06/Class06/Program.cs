using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class06 {
	class Program {
		static void Main( string[ ] args ) {

			Console.WriteLine( "game start" );


			Player player = new Player( "hero", 1, 0, 20, 10, 5 );

			while (player.IsAlive ) {
				Enemy enemy = new Enemy( "slime", 10, 8, 2, 5 );
				Console.WriteLine( enemy.Name + "discover!" );
				//battle
				Battle battle = new Battle( player, enemy );
				bool battleIsEnd = false;
				while ( !battleIsEnd ) {
					Console.WriteLine( "comment?" );
					Console.ReadLine( );

					battleIsEnd = battle.AdvanceTurn( );

					Console.WriteLine( player.Name + "'s hp:" + player.HP );
				}
			}

			Console.WriteLine( "game over" );
			Console.WriteLine( "press return to quit" );
		}
	}
}


