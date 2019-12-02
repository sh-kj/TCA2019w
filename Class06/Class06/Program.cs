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
			while(true) {
				Enemy Enemy = new Enemy("スライム",7,7,3,5);
				Battle Battle = new Battle(Player,Enemy);

				Console.WriteLine(Enemy.Name + "が現れた!");

				bool battleIsEnd = false;
				while(!battleIsEnd)
				{
					Console.WriteLine(Player.Name + "HP:" + Player.HP);

					Console.WriteLine("Enterでターンが進みます");
					Console.ReadLine();

					battleIsEnd = Battle.AdvanceTurn();
				}

				if(!Player.IsAlive)
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
}