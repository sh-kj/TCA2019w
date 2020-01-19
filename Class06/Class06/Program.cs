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
			Player Player = new Player("勇者", 1, 0, 20, 12, 5);

			while (true)
			{
				Enemy Enemy = new Enemy("スライム", 7, 10, 3, 5);
				Battle battle = new Battle(Player, Enemy);

				Console.WriteLine(Enemy.Name + "が現れた！");

				bool battleIsEnd = false;
				while(!battleIsEnd)
				{
					//ターん進行
					Console.WriteLine(Player.Name + "HP" + Player.HP);

					//プレイヤーの行動入力（何も）
					Console.WriteLine("Enterでターンが進みます");
					Console.ReadLine();
					//プレイヤーと殴り合う
					battleIsEnd = battle.AdvanceTurn();
				}
				if (!Player.IsAlive)
				{
					Console.WriteLine("ゲームオーバー");
					break;
				}
				Console.WriteLine();
			}
			Console.WriteLine("てすと");
			Console.WriteLine("press return to quit.");
			Console.ReadLine();
		}
	}
}
