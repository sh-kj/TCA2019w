using System;
using System .Collections .Generic;
using System .Linq;
using System .Text;
using System .Threading .Tasks;

namespace Class06 {
	class Battle {
		public Player BattlePlayer {
			get; private set; 
		}

		public Enemy BattleEnemy {
			get; private set;
		}

		public Battle( Player player, Enemy enemy ) {
			BattlePlayer = player;
			BattleEnemy = enemy;
		}

		public bool AdvanceTurn( ) {
			//プレイヤー→敵へ攻撃
			int damage = BattlePlayer.Attack( BattleEnemy );
			Console.WriteLine( BattlePlayer.Name + "の攻撃!" + 
				BattleEnemy.Name + "に" + damage + "のダメージ" );

			//敵の生存チェック
			if ( !BattleEnemy.IsAlive ) {
				//敵が死んだ
				Console.WriteLine( BattleEnemy.Name + "を倒した" );

				BattlePlayer.AddExp(BattleEnemy.GainExp);

                //レベルアップ処理
                //if (BattlePlayer.Experience) {
                //    Console.WriteLine(BattlePlayer.Name + "はレベルアップをした！！");
                //}

                //回復処理
                //Console.WriteLine( BattlePlayer.Name + "は七つの習慣を使った" );
				//Console.WriteLine( BattlePlayer.Name + "HPはMaxになった" );
                
                return true;
			}

			//敵→プレイヤーへ攻撃
			damage = BattleEnemy.Attack( BattlePlayer );
			Console.WriteLine( BattleEnemy.Name + "の攻撃!" + 
				BattlePlayer.Name + "に" + damage + "のダメージ" );

			if ( !BattlePlayer.IsAlive ) {
				Console.WriteLine( BattlePlayer.Name + "を倒した!" );
				return true;
			}

			return false;
		}
	}
}
