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

			Player player = new Player("player", 1, 0, 20, 12, 5);

			Console.WriteLine("Press Enter to Start!");
			Console.ReadLine();

			while (true)
			{
				//encounter
				Enemy enemy = new Enemy("slime", 7, 10, 3, 5);
				Battle battle = new Battle(player, enemy);

				Console.WriteLine(enemy.Name + " is appeared!");

				bool battleIsEnd = false;
				while (!battleIsEnd)
				{
					//turn start
					Console.WriteLine(player.Name + "HP: " +player.HP);

					//player action(no input is ok)
					Console.WriteLine("Press Enter to Continue");
					Console.ReadLine();

					//fight
					battleIsEnd = battle.AdvanceTurn();


				}
				if (!player.IsAlive)
				{
					Console.WriteLine("Game Over!");
					break;
				}

				Console.WriteLine();
			}

			Console.WriteLine("Press Return to Quit.");
			Console.ReadLine();
		}
	}
}


