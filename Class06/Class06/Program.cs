using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class06 {
	class Program {
		static void Main( string[ ] args ) {
			Console.WriteLine( "ゲームスタート" );

			Player player = new Player( "勇者", 1, 100, 20, 10, 5 );

			while ( player.IsAlive ) {
				Enemy enemy = new Enemy( "スライム", 10, 8, 2, 5 );
				Console.WriteLine( enemy.Name + "が現れた!" );

				Battle battle = new Battle( player, enemy );
				bool battleEnd = false;
				while ( !battleEnd ) {
					Console.WriteLine( "コマンド?" );
					Console.ReadLine( );

					battleEnd = battle.AdvanceTurn( );

					Console.WriteLine( player.Name + "のHP:" + player.HP );
				}
			}
			Console.WriteLine( "ゲームオーバー" );

			Console.WriteLine( "press return to exit" );
			Console.ReadLine( );
		}
	}
}
