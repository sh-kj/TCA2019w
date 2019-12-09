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

			Console.WriteLine("Press Enter to Start!");

			while (true)
			{
				//encounter
				int enemyIndex = DamageCalculator.Rand.Next(enemyMaster.Parameters.Count);

				Enemy enemy = new Enemy( enemyMaster.Parameters[0]);
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


