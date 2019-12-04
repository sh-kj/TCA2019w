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

			Console.WriteLine("ゲームスタート");

			Player player = new Player("Okuty", 1, 0, 20, 10, 5);

			while( true )
			{
				Enemy enemy = new Enemy("tsukada", 10, 8, 2, 5);
				Console.WriteLine(enemy.Name + "が現れた！");

				Battle battle = new Battle(player, enemy);
				while( true )
				{
					Console.WriteLine("コマンド？");
					Console.ReadLine();

					battle.AdvanceTurn();

					Console.WriteLine(player.Name + "のHP:" + player.HP);
				}
			}

			

			Console.WriteLine("press return to quit.");
			Console.ReadLine();
		}
	}
}
