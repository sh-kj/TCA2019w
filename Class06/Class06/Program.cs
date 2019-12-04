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
			Console.WriteLine("game start");

			Player player = new Player("ザコー", 1, 0, 20, 10, 5);

			while(true)
			{
				Enemy enemy = new Enemy("スライム", 10, 8, 2, 5);

				Console.WriteLine(enemy.Name + "が現れた!");

				battle battle = new battle(player,enemy);

				bool battleIsEnd = false;
				while (!battleIsEnd)
				{
					Console.WriteLine("コマンド?");
					Console.ReadLine();

					battleIsEnd = battle.AdvanceTurn();

					Console.WriteLine(player.Name + "のHP" + player.HP);
				}
			}
			Console.WriteLine("press return to quit.");
			Console.ReadLine();
		}
	}
}
