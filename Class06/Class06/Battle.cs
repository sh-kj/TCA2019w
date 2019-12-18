
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

		public Player BattlePlayer2
			{ get; private set; }

		public Enemy BattleEnemy
			{ get; private set; }

		public Battle(Player player1, Player player2, Enemy enemy)
		{
			BattlePlayer = player1;
			BattlePlayer2 = player2;
			BattleEnemy = enemy;
		}

		bool okutyDead = false;

		public bool AdvanceTrum(/*コマンド内容*/)
		{
			

			int damage = BattlePlayer.Attack(BattleEnemy);
			int damage2 = BattlePlayer2.Attack(BattleEnemy);

			Console.WriteLine(BattlePlayer.Name + "の攻撃！" + BattleEnemy.Name + "に" + damage + "のダメージ！");

			if(okutyDead == false ) {
				Console.WriteLine(BattlePlayer2.Name + "の攻撃！" + BattleEnemy.Name + "に" + damage2 + "のダメージ！");
			}

			if (!BattleEnemy.IsAlive)
			{
				Console.WriteLine(BattleEnemy.Name + "を倒した！");
				return true;
			}

			int random = DamageCalculator.RandomCalculator.Next(10);

			if(random % 10 != 0){
				damage = BattleEnemy.Attack(BattlePlayer);
				Console.WriteLine(BattleEnemy.Name + "の攻撃！" +
				BattlePlayer.Name + "に" + damage + "のダメージ！");
			}else{
				damage = BattleEnemy.Attack(BattlePlayer2);
				Console.WriteLine(BattleEnemy.Name + "の攻撃！" +
				BattlePlayer2.Name + "に" + damage + "のダメージ！");
			}

			if (!BattlePlayer.IsAlive)
			{
				Console.WriteLine(BattlePlayer.Name + "は倒れた…");
				return true;
			}

			if(!BattlePlayer2.IsAlive)
			{
				if ( okutyDead == false ) {

					Console .WriteLine(BattlePlayer2.Name + "はやっと倒れた！！！");
					Console .WriteLine(BattleEnemy.Name + "は喜んで去っていった！");
					okutyDead = true;
				}
				return false;
			}

			return false;
		}
	}
}
