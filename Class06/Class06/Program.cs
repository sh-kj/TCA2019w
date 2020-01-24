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

			Player Player = new Player("尊師", 9999, 0, 150, 80, 15 );

			Enemy Enemy = new Enemy("警察", 800, 30, 20, 0 ); 

			Sa Sa = new Sa("尊師は反動を受けた", 20);

			while (true)
			{
				
				
				Battle battle = new Battle(Player, Enemy, Sa);

				Console.WriteLine(Enemy.Name + "が現れた！");

				Console.WriteLine();
				bool battleIsEnd = false;
				while (!battleIsEnd)
				{
					//ターン
					Console.WriteLine("lv\n" + Player.Level);
					Console.WriteLine(Player.Name + "HP\n" + Player.HP);

					//プレイヤーの行動
					Console.WriteLine("PressEnter");
					Console.ReadLine();
					
					battleIsEnd = battle.AdvanceTurn();
					Console.ReadLine();

					
					battleIsEnd = battle.AdvanceTurn();
				}
				if (!Player.IsAlive)
				{

					Console.WriteLine("逮捕!死刑!ゲームオーバー");
					break;
						
				}
				
			}

			Console.WriteLine("press return to quit.");
			Console.ReadLine();
		}
	}
}
