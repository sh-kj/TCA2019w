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
            
            Player player=new Player("勇者", 1, 0, 20, 12, 5);

            while (true)
            {
                Enemy enemy = new Enemy("スライム", 7, 10, 3, 5);
                Battle battle = new Battle(player, enemy);

                Console.WriteLine(enemy.Name + "が現れた!");

                bool battleIsEnd = false;
                while (!battleIsEnd)
                {
                    Console.WriteLine(player.Name + "HP" + player.HP);

                    Console.WriteLine("Enterでターンが進みます");
                    Console.ReadLine();
                    battleIsEnd = battle.AdvanceTurn();
                }

                if(!player.IsAlive)
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
