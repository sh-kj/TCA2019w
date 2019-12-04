using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Class06 {
	class Program {

		const int PLAYER_LEVEL = 0;
		const int PLAYER_EXP = 0;
		const int PLAYER_HP = 20;
		const int PLAYER_ATTACK = 10;
		const int PLAYER_DEFEND = 5;

		const int SLIME_HP = 10;
		const int SLIME_ATTACK = 8;
		const int SLIME_DEFEND = 1;
		const int SLIME_GAINEXP = 5;
		
		
		static void Main( string[ ] args ) {

			Console.WriteLine( "ゲームスタート" );
			Player _player = new Player( "Okuty", PLAYER_LEVEL, PLAYER_EXP, PLAYER_HP, PLAYER_ATTACK, PLAYER_DEFEND );

			while ( _player.IsAlive ) {
				Enemy _enemy = new Enemy( "スライム", SLIME_HP, SLIME_ATTACK, SLIME_DEFEND, SLIME_GAINEXP );
				Console.WriteLine( _enemy.Name + "が現れた!" );

				//バトル処理
				Battle battle = new Battle( _player, _enemy );
				bool _battles_end = false;
				while ( !_battles_end ) {
					Console.WriteLine( "コマンド？" );
					Console.ReadLine( );

					_battles_end = battle.AdvaneTurn( );

					if ( !_battles_end ) {
						Console.WriteLine( _player.Name + "のHP" + _player.HP );
					}
				}

			}




			Console.WriteLine( "\nゲームオーバー" );
			Console.ReadLine( );

		}
	}
}
