using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class06
{
	class Program
	{
		static void Main(string[] args)
		{
			Player player=new Player("勇者",1,0,20,8,5);

			while (true)
			{
				//エンカウント
				Enemy enemy=new Enemy("スライム",7,7,3,5);
				Battle battle= new Battle(player,enemy);

				Console.WriteLine(enemy.Name+"が現れた！！");

				bool battleIsEnd=false;
				while (!battleIsEnd)
				{
					//ターン進行
					Console.WriteLine(player.Name+"HP"+player.HP);
					//プレイヤーの行動入力（何も受ける情報がない）
					Console.WriteLine("Enterで1ターン進みます");
					Console.ReadLine();

					//プレイヤーと敵が慰め合う
					battleIsEnd=battle.AdvanceTurn();
				}

				if (!player.IsAlive)
				{
					Console.WriteLine("ゲームオーバー");
					break;
				}
				Console.WriteLine();
			}

			Console.WriteLine("press return to quit.");
			Console.ReadLine();
		}
	}


	

	class Battle
	{
		private Player BattlePlayer;
		private Enemy BattleEnemy;

	public Battle(Player player, Enemy enemy)
		{
			BattlePlayer=player;
			BattleEnemy=enemy;
		
	}
		public bool AdvanceTurn()
		{
			//プレイヤーが敵を攻撃
			int damage=BattlePlayer.Attack(BattleEnemy);
			//プレイヤーが敵を慰める
			Console.WriteLine(BattlePlayer.Name + "の攻撃！！" + BattleEnemy.Name + "に" + damage + "のダメージ！！");
			if (!BattleEnemy.IsAlive)
			{
				//敵がやられた
				Console.WriteLine(BattleEnemy.Name + "を倒した！！");
				return true;
			}
			//敵がプレイヤーを攻撃
			damage=BattleEnemy.Attack(BattlePlayer);
			//敵がプレイヤーを慰める
			Console.WriteLine(BattleEnemy.Name + "の攻撃！！" + BattlePlayer.Name + "に" + damage + "のダメージ！！");
			if(!BattlePlayer.IsAlive)
			{
				//敵がプレイヤーをたおした
				Console.WriteLine(BattlePlayer.Name + "は倒れた．．．．");
				return true;
			}
			return true;
		}
	}
}
