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
				string json = System.IO.File.ReadAllText(@"D:\enemy.json");
				enemyMaster = Newtonsoft.Json.JsonConvert.DeserializeObject<EnemyMaster>(json);
			}

			catch (Exception e)
			{
				Console.WriteLine("マスターデータの読み込みに失敗しました。" + e.ToString());
			}

			if (enemyMaster == null)
			{
				//マスターデータの読み込みに失敗しているのでデフォルト値でマスターデータを作る
				EnemyParameter parameter1 = new EnemyParameter();
				parameter1.Name = "スライム";
				parameter1.MaxHP = 10;
				parameter1.AttackPower = 8;
				parameter1.DefencePower = 2;
				parameter1.GainXP = 5;


				EnemyParameter parameter2 = new EnemyParameter();
				parameter2.Name = "プランナー";
				parameter2.MaxHP = 1;
				parameter2.AttackPower = 20;
				parameter2.DefencePower = 5;
				parameter2.GainXP = 100;

				EnemyMaster master = new EnemyMaster();
				master.Parameters = new List<EnemyParameter>();
				master.Parameters.Add(parameter1);
				master.Parameters.Add(parameter2);

				string json = Newtonsoft.Json.JsonConvert.SerializeObject(master);
				System.IO.File.WriteAllText(@"D:\enemy.json", json);
			}

			




			Console.WriteLine("ゲームスタート");
			Player _Daisuke = new Player("大介", 1, 0, 20, 10, 5);
			Player _okuty = new Player("おくてぃ～", 1, 0, 1, 1, 1);

			while (_Daisuke.IsAlive)
			{
				int randomIndex = DamageCalculator.RandomCalculator.Next(enemyMaster.Parameters.Count);

				Enemy enemy = new Enemy(enemyMaster.Parameters[randomIndex]);
				Console.WriteLine(enemy.Name + "が現れた！");

				Battle battle = new Battle( _Daisuke
					, _okuty, enemy);
				bool battleisEnd = false;
				

				while (!battleisEnd)
				{

					Console.WriteLine("コマンド？");
					Console.ReadLine();

					battleisEnd = battle.AdvanceTrum();

					Console.WriteLine(_Daisuke.Name + "のHP：" + _Daisuke.HP);


				}

				Console.ReadLine();
			}
				
		}
	}
}
