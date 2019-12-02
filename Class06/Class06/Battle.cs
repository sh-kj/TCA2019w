using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class06
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
			//プレーヤーターン
			int damage=BattlePlayer.AttackPower;
			Console.WriteLine(BattlePlayer.Name+"の攻撃!");
			Console.WriteLine(BattleEnemy.Name+"に"+damage+"の攻撃!");
			Console.WriteLine(BattleEnemy.HP + "HPから");
			damage = BattlePlayer.Attack(BattleEnemy);
			Console.WriteLine(BattleEnemy.HP + "HPになった");
			//敵の生存確認
			if (!BattleEnemy.IsAlive)
			{
				Console.WriteLine(BattleEnemy.Name+"は倒れた");
				return true;
			}
			//敵のターン
			Console.WriteLine(BattleEnemy.Name + "の攻撃!");
			Console.WriteLine(BattlePlayer.HP+"HPの");
			damage = BattleEnemy.Attack(BattlePlayer);
			Console.WriteLine(BattlePlayer.Name + "に" + damage + "のダメージ!");
			Console.WriteLine(BattlePlayer.HP+"HPになった");
			//プレーヤーの生存確認
			if (!BattlePlayer.IsAlive)
			{
				Console.WriteLine(BattlePlayer.Name + "は倒れた");
				return true;
			}
			return false;
		}

	}
}
