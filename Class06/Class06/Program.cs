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
			EnemyMaster enemyMaster;
			if (System.IO.File.Exists(@"D:\enemy.json"))
			{
				string json = System.IO.File.ReadAllText(@"D:\enemy.json");
				enemyMaster = Newtonsoft.Json.JsonConvert.DeserializeObject<EnemyMaster>(json);
			}
			else
			{
				enemyMaster = new EnemyMaster();
				enemyMaster.Parameters = new List<EnemyParameter>();

				EnemyParameter enemyParameter = new EnemyParameter();
				enemyParameter.Name = "Metal Slime";
				enemyParameter.MaxHP = 6;
				enemyParameter.AttackPower = 10;
				enemyParameter.DefencePower = 300;
				enemyParameter.GainExp = 2000;

				enemyMaster.Parameters.Add(enemyParameter);

				string result = Newtonsoft.Json.JsonConvert.SerializeObject(enemyMaster);

				System.IO.File.WriteAllText(@"D:\enemy.json", result);
			}

			Player player = new Player("player", 1, 0, 20, 12, 5);

			Console.WriteLine("Save The World From Slime!\nPress Enter to Start!");
			Console.ReadLine();

			bool saved = false;

			while (true)
			{
				//encounter
				int enemyIndex = DamageCalculator.Rand.Next(enemyMaster.Parameters.Count);

				Enemy enemy = new Enemy( enemyMaster.Parameters[0]);
				Battle battle = new Battle(player, enemy);

				Console.WriteLine(enemy.Name + " is appeared!");

				while (!saved)
				{
					//turn start
					Console.WriteLine(player.Name + "HP: " +player.HP);
					Console.WriteLine(enemy.Name + "HP: " + enemy.HP);

					//player action(no input is ok)
					Console.WriteLine("Press Enter to Continue");
					Console.ReadLine();
					
					//player hp recovery
					if (player.HP%3==0 && !saved)
					{
						player.Recover1();
						Console.WriteLine("Bonus!!!\nHP Recovered(Small)!!");
						Console.WriteLine(player.Name + "HP: " + player.HP);
						Console.WriteLine();
					}

						if (player.HP == 1 && !saved)
					{
						player.RecoverHalf();
						Console.WriteLine("Bonus!!!\nHP Recovered(Large)!!");
						Console.WriteLine(player.Name + "HP: " + player.HP);
						Console.WriteLine();
					}

						//fight
					saved = battle.AdvanceTurn();


				}

				if (!player.IsAlive)
				{
					Console.WriteLine();
					Console.WriteLine("Game Over!");
					Console.WriteLine();
					break;
				}

				if (saved)
				{
					Console.WriteLine();
					Console.WriteLine("You Saved The World!");
					Console.WriteLine();
					break;
				}
				
			}

			Console.WriteLine("Press Return to Quit");
			Console.ReadLine();
		}
	}
}


