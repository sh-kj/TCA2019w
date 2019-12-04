using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class06
{
	class Battle
	{
		public Player BattlePlayer 
			{ get; private set; }

		public Enemy BattleEnemy
			{ get; private set; }

		public Battle( Player player, Enemy enemy ) {
			BattlePlayer = player;
			BattleEnemy = enemy;
		}

		public bool AdvanceTurn( ) {
			int damage = BattlePlayer.Attack( BattleEnemy );
			Console.WriteLine( BattlePlayer.Name + "の攻撃" +
				BattleEnemy.Name + "に" + damage + "のダメージ" );

			if ( !BattleEnemy.IsAlive ) {
				Console.WriteLine( BattleEnemy.Name + "を倒した!" );

				BattlePlayer.AddExp(BattleEnemy.GainExp);
				return true;
			}

			damage = BattleEnemy.Attack( BattlePlayer );
			Console.WriteLine( BattleEnemy.Name + "の攻撃" +
				BattlePlayer.Name + "に" + damage + "のダメージ" );

			if ( !BattlePlayer.IsAlive ) {
				Console.WriteLine( BattlePlayer.Name + "は倒された..." );
				return true;
			}

			return false;
		}

	}
}
