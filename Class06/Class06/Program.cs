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


			Console.WriteLine("gamestart");
			Player player = new Player("youxia", 1, 0, 20, 10, 5);
			while (true)
			{
				Enemy enemy = new Enemy("sraim", 10, 8, 2, 5);
				Console.WriteLine(enemy.Name + "gareta");

				Battle battle = new Battle(player, enemy);
				bool battleIsEnd = false;
				while (true)
				{
					Console.WriteLine("komanto");
					Console.ReadLine();

					battleIsEnd = battle.AdvanceTurn();

					battle.AdvanceTurn();
					Console.WriteLine(player.Name + "deHP" + player.HP);
				}
			}
			Console.WriteLine(player.Name + "deHP" + player.HP);
			Console.WriteLine("press return to quit.");
			Console.ReadLine();
		}
	}
}
