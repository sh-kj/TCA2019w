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
		{
			get; private set;
		}

		public Enemy BattleEnemy 
		{
			get; private set;
		}

		public Battle(Player player,Enemy enemy)
		{
			BattlePlayer = player;
			BattleEnemy = enemy;
		}

		public bool AdvanceTurn(/*コマンド内容*/)
		{
			int damage =  BattlePlayer.Attack(BattleEnemy);　　　　　//プレイヤーの攻撃
			Console.WriteLine(BattlePlayer.Name + "の攻撃！！" + BattleEnemy.Name + "に" + damage + "のダメージ！");

			if (!BattleEnemy.IsAlive)       //敵の生存チェック
			{
				Console.WriteLine(BattleEnemy.Name + "を倒した！");       //敵が死んだ
				return true;
			}

			damage = BattleEnemy.Attack(BattlePlayer);       //敵の攻撃
			Console.WriteLine(BattleEnemy.Name + "の攻撃" + BattlePlayer.Name + "に" + damage + "のダメージ！");

			if (!BattlePlayer.IsAlive)     //プレイヤーの生存チェック
			{
				Console.WriteLine(BattlePlayer.Name + "は倒れたww");
				return true;
			}

			return false;
		}
	}
}
