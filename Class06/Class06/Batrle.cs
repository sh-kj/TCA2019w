using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class06 {
	class Battle {


		public Player BattlePlayer { get; private set; }

		public Enemy BattleEnemy { get; private set; }

		public Battle( Player player, Enemy enemy ) {
			BattlePlayer = player;
			BattleEnemy = enemy;
		}
		public bool AdvanceTurn( ) {
			//player attack enemy
			int damage = BattlePlayer.Attack( BattleEnemy );
			Console.WriteLine( BattlePlayer.Name + "attack!" + BattleEnemy.Name + "to" + damage + "damage" );
			//enemy check live or not?
			if ( !BattleEnemy.IsAlive ) {
				//dead
				Console.WriteLine( BattleEnemy.Name + "was defeated!" );
				return true;
			}
			//enemy attack player
			damage = BattleEnemy.Attack( BattlePlayer );
			Console.WriteLine( BattleEnemy.Name + "attack!" + BattlePlayer.Name + "to" + damage + "damage!" );
			//player check dead or not
			if ( !BattlePlayer.IsAlive ) {
				Console.WriteLine( BattlePlayer.Name + "was killed by enenmy" );
				return true;
			}
			return false;
		}

	}


}