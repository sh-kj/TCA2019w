using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Class06
{
	class Battle
	{
		private Player battlePlayer;
		private Enemy battleEnemy;
		private Sa Selfabuse;

		public Battle(Player player, Enemy enemy, Sa sa)
		{
			battlePlayer = player;
			battleEnemy = enemy;
			Selfabuse = sa;
		}


		public bool AdvanceTurn()
		{
			
			//必殺確認
			if(battlePlayer.SPcheck)
			{
				Console.WriteLine("尊師に力がみなぎる!");
				int damageSP = battlePlayer.SPAttack(battleEnemy);
				Console.WriteLine( "尊師・ジ・エンド!!" + battleEnemy.Name + "に" + damageSP + "のダメージ!");
				Console.WriteLine("一撃必殺!!!\n");
				int sadamage = Selfabuse.Attack(battlePlayer);
				Console.WriteLine("尊師は攻撃の反動でダメージを受けた\n");

				return true;
			}else{
				Console.WriteLine("必殺技はまだ使えない…\n");
				
				}


			//プレイヤー攻撃
			int damege = battlePlayer.Attack(battleEnemy);
			Console.WriteLine(battlePlayer.Name + "の攻撃!!\n" + battleEnemy.Name + "に" + damege + "のダメージ!\n");
			
			//敵
			if (!battleEnemy.IsAlive)
			{
				Console.WriteLine(battleEnemy.Name + "を倒した！\n");
				return true;
			}

			//敵がプレイヤーを攻撃
			damege = battleEnemy.Attack(battlePlayer);
			Console.WriteLine(battleEnemy.Name + "の攻撃!!\n" + battlePlayer.Name + "に" + damege + "のダメージ!\n");

			//プレイヤーが生きているかどうか
			if (!battlePlayer.IsAlive)
			{
				Console.WriteLine(battlePlayer.Name + "は力尽きた");
				return false;
			}
			return false;
		}
	}
}