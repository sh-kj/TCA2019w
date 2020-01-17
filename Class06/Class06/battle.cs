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

		public Battle(Player player, Enemy enemy)
		{
			BattlePlayer = player;
			BattleEnemy = enemy;
		}

		public bool AdvanceTurn()
		{

			//player attack enemy
			int damage = BattlePlayer.Attack(BattleEnemy);
			Console.WriteLine(BattlePlayer.Name + " is attacking " +BattleEnemy.Name+" with "+damage+" damage!");

			//enemy died
			if (!BattleEnemy.IsAlive)
			{
				Console.WriteLine(BattleEnemy.Name + " is dead!");
				return true;
			}

			//enemy attack player
			damage = BattleEnemy.Attack(BattlePlayer);
			Console.WriteLine(BattleEnemy.Name + " is attacking " + BattlePlayer.Name + " with " + damage + " damage!");

			//Player died
			if (!BattlePlayer.IsAlive)
			{
				Console.WriteLine(BattlePlayer.Name + " is dead...");
				return true;
			}

			return false;
		}
	}
}
