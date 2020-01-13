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

		public Battle(Player player,Enemy enemy)
		{
			BattlePlayer = player;
			BattleEnemy = enemy;
		}

		public bool AdvanceTurn()
		{

			int damage=BattlePlayer.Attack(BattleEnemy);

			Console.WriteLine(BattlePlayer.Name + "の攻撃！" + BattleEnemy.Name + "に" + damage + "のダメージ!");

			//敵の生存チェック
			if (!BattleEnemy.IsAlive)
			{
				Console.WriteLine(BattleEnemy.Name + "を倒した！");
                //敵が倒したらexpget LevelUp
                BattlePlayer.LevelUP(BattleEnemy);

                Console.WriteLine("Player　Level:" + BattlePlayer.CurrentLevel + ",exp:" + BattlePlayer.CurrentExp);
				return true;
			}

			damage = BattleEnemy.Attack(BattlePlayer);
			Console.WriteLine(BattleEnemy.Name + "の攻撃！" + BattlePlayer.Name + "に" + damage + "のダメージ!");

			//playerの生存チェック
			if (!BattlePlayer.IsAlive)
			{
				Console.WriteLine(BattlePlayer.Name + "は倒した...");
				return true;
			}

			return false;

		}
	}
}
