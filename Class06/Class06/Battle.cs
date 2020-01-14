
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public bool AdvaneTurn( /*コマンド内容*/ ) {
			//プレイヤー → 敵
			int damege = BattlePlayer.Attack( BattleEnemy );
			Console.WriteLine( BattlePlayer.Name + "の攻撃!\n" +
				BattleEnemy.Name + "に" + damege + "のダメージ!\n" );
			//生存チェック
			if ( !BattleEnemy.IsAlive ) {
				//死んだら	
				Console.WriteLine( BattleEnemy.Name + "を倒した。\n" );
				
				/*
				BattlePlayer.Exp += BattleEnemy.GainExp;
				Console.WriteLine( BattleEnemy.GainExp + "を取得した。"
					+ "経験値が" + BattlePlayer.Level + "になった。" );
				*/
				
				return true;
			}

			//敵 → プレイヤー
			damege = BattleEnemy.Attack( BattlePlayer );
			Console.WriteLine( BattleEnemy.Name + "の攻撃!\n" +
				BattlePlayer.Name + "に" + damege + "のダメージ!\n" );
			//生存チェック
			if ( !BattlePlayer.IsAlive ) {
				//死んだら	
				Console.WriteLine( BattlePlayer.Name + BattleEnemy.ResultLog );
				return true;
			}

			return false;
		}
	}
}
