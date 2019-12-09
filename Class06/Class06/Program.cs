﻿using System;
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
			//string json = System.IO.File.ReadAllText(@"0;\enemy.json");

		//	EnemyProgram parameter = Newtonsoft.Json.JsonConvert.DeserializeObject<EnemyProgram>(json);

			//Console.WriteLine(parameter.Name + ", HP:" + parameter.MaxHP);
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

				enemyMaster.Parameters.Add(enemyParameter);

				string result = Newtonsoft.Json.JsonConvert.SerializeObject(enemyParameter);
				System.IO.File.WriteAllText(@"D:\enemy.json",result);
			}
			//Console.WriteLine(result);
			//Console.ReadLine();

			//System.IO.File.WriteAllText(@"0;\enemy.json".result);

			return;

		Player Player = new Player("勇者", 1, 0, 20, 12, 5);
			while(true) {

				//int enemyIndex = DamageCalculator.RandomProvider.Next(enemyMaster.Paraneters.Count);

				//Enemy enemy = new Enemy(enemyMaster.Parameters[0].Name,
					//enemyMaster.Parameters[0].MaxHP,enemyMaster.Parameters[0].AttackPower,
					//enemyMaster.Parameters[0].DefencePower,enemyMaster.Parameters[0].GainExp)

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