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
			EnemyMaster enemyMaster = null;
			try
			{

				string json = System.IO.File.ReadAllText(@"D:\Enemy.json");
				enemyMaster =
					Newtonsoft.Json.JsonConvert.DeserializeObject<EnemyMaster>(json);
			}
			catch (Exception e)
			{
				//Console.WriteLine("名前"+enemyMaster.Parameters[0].Name + "," +"\nHP"+ enemyMaster.Parameters[0].MaxHP+","+"\n防御力"+enemyMaster.Parameters[0].DefencePower);
				Console.WriteLine("マスターデータ読み込みに失敗しました:" + e.ToString());
			}
			if (enemyMaster == null)
			{
				//マスターデータ読み出しに失敗しているので
				//デフォルト値でマスターデータを作る
				EnemyParameter Parameter1 = new EnemyParameter();
				Parameter1.Name = "スライム";
				Parameter1.MaxHP = 10;
				Parameter1.AttackPower = 8;
				Parameter1.DefencePower = 2;
				Parameter1.GainExp = 5;

				EnemyParameter Parameter2 = new EnemyParameter();
				Parameter2.Name = "おくてぃー";
				Parameter2.MaxHP = 1;
				Parameter2.AttackPower = 20;
				Parameter2.DefencePower = 5;
				Parameter2.GainExp = 100;

				EnemyMaster master = new EnemyMaster();
				master.Parameters = new List<EnemyParameter>();
				master.Parameters.Add(Parameter1);
				master.Parameters.Add(Parameter2);

				string json = Newtonsoft.Json.JsonConvert.SerializeObject(master);

					Console.WriteLine(json);
					System.IO.File.WriteAllText(@"D:\Enemy.json", json);
			}


			

			Console.WriteLine("ゲームスタート");
			Player player = new Player("勇者", 1, 0, 20, 10, 5);

			while (player.IsAlive)
			{
				int randomIndex = DamageCalculator.RandomCalculator.Next(enemyMaster.Parameters.Count);
				Enemy enemy = new Enemy(enemyMaster.Parameters[randomIndex]);

				Console.WriteLine(enemy.Name + "が現れた!");

				Battle battle = new Battle(player, enemy);
				bool battleIsEnd = false;
				while (!battleIsEnd)
				{
					Console.WriteLine("コマンド?");
					Console.ReadLine();

					battleIsEnd = battle.AdvanceTurn();


					Console.WriteLine(player.Name + "のHP:" + player.HP);
				}
			}
			Console.WriteLine("ゲームオーバー");
			Console.WriteLine("press return to quit");
			Console.ReadLine();


		}
	}
		}
