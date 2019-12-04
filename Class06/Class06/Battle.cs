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
			{ get;private set; }
		public Enemy BattleEnemy 
			{ get; private set; }
		public Battle (Player player,Enemy enemy)
		{
			BattlePlayer = player;
			BattleEnemy = enemy;
			
		}
		public bool AdvanceTurn()
		{
			int damage = BattlePlayer.Attack(BattleEnemy);
			Console.WriteLine(BattlePlayer.Name + "attack"+
			BattleEnemy.Name + "ni" + damage+"shagnhai");

			if (!BattleEnemy.IsAlive)
			{
				Console.WriteLine(BattleEnemy.Name + "ss");
				return true;

			}

			 damage = BattleEnemy.Attack(BattlePlayer);
			Console.WriteLine(BattleEnemy.Name + "attack" +
			BattlePlayer.Name + "ni" + damage + "shagnhai");
			if (!BattleEnemy.IsAlive)
			{
				Console.WriteLine(BattlePlayer.Name + "ss");
				return true;

			}
			return false;
		}
	}
}
