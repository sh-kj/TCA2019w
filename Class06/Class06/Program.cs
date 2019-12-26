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
			if(System.IO.File.Exists(@"D:\enemy.json"))
			{
				string json = System.IO.File.ReadAllText(@"D:\enemy.json");
				enemyMaster = Newtonsoft.Json.JsonConvert.DeserializeObject<EnemyMaster>(json);
				
			}
			else 
			{
				enemyMaster = new EnemyMaster();
				enemyMaster.Parameters = new List<EnemyProgram>();


				EnemyProgram enemyParameter = new EnemyProgram();

				enemyParameter.Name = "メタルスライム";
				enemyParameter.MaxHP = 5;
				enemyParameter.AttackPower = 10;
				enemyParameter.DefencePower = 300;
				enemyParameter.GainExp = 2000;
				enemyParameter.Name = "ホイミスライム";
				enemyParameter.MaxHP = 8;
				enemyParameter.AttackPower = 10;
				enemyParameter.DefencePower = 3;
				enemyParameter.GainExp = 20;

				enemyMaster.Parameters.Add(enemyParameter);

				string result = Newtonsoft.Json.JsonConvert.SerializeObject(enemyParameter);
				System.IO.File.WriteAllText(@"D:\enemy.json",result);
			}
			//return;

		Player Player = new Player("勇者", 1, 0, 20, 12, 5);
			while(true) {

				//Enemy Enemy = new Enemy("スライム",7,7,3,5);
				int enemyIndex = DamageCalculator.RandomProvider.Next( enemyMaster.Parameters.Count );
				Enemy Enemy = new Enemy( enemyMaster.Parameters[ enemyIndex ] );

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
				//Console.WriteLine();
			}
		
			Console.WriteLine("press return to quit.");
			Console.ReadLine();
		}
	}
}