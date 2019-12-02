using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class06
{
	class Program
	{
		class Battle
		{
			private Player BattlePlayer;
			private Enemy BattleEnemy;

			public Battle(Player player,Enemy enemy)
			{
				BattlePlayer = player;
				BattleEnemy = enemy;
			}

			public bool AdvanceTurn( )
			{
				//プレイヤーが敵を攻撃
				int damage = BattlePlayer. Attack(BattleEnemy);
				Console.WriteLine(BattlePlayer.Name + "の攻撃!" + BattleEnemy.Name + "に" + damage + "のダメージ!");

				if( !BattleEnemy.IsAlive )
				{
					//敵が死んだ
					Console.WriteLine(BattleEnemy.Name + "を倒した!");
					return true;
				}

				//敵がプレイヤーを攻撃
				damage = BattleEnemy.Attack(BattlePlayer);
				Console.WriteLine(BattleEnemy.Name + "の攻撃!" + BattlePlayer.Name + "に" + damage + "のダメージ!");

				if( !BattlePlayer.IsAlive )
				{
					//プレイヤーが死んだ
					Console.WriteLine(BattlePlayer.Name + "は倒れた...");
					return true;
				}
				return false;
			}
			
		}
		static void Main(string[] args)
		{

			Player player = new Player("勇者", 1, 0, 20, 8, 5);

			while ( true )
			{
				//エンカウント
				Enemy enemy = new Enemy("スライム", 7, 7, 3, 5);
				Battle battle = new Battle(player , enemy);

				bool battleIsEnd = false;
				while(!battleIsEnd)
				{
					//ターン進行
					//プレイヤーと敵が殴り合う
					battle.AdvanceTurn( );
				}
		
			}


			Console.WriteLine("press return to quit.");
			Console.ReadLine();
		}
	}
}
