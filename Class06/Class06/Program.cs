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
            catch(Exception e)
            {
                Console.WriteLine("マスターデータ読み込みに失敗しますた:" + e.ToString());
            }

            if(enemyMaster == null)
            {
                //マスターデータ読み出しに失敗しているので
                //デフォルト値でマスターデータを作る
                EnemyParameter parameter1 = new EnemyParameter();
                parameter1.Name = "つっちー";
                parameter1.MaxHP = 10;
                parameter1.AttackPower = 8;
                parameter1.DefencePower = 2;
                parameter1.GainExp = 5;

                EnemyParameter parameter2 = new EnemyParameter();
                parameter2.Name = "okuty";
                parameter2.MaxHP = 1;
                parameter2.AttackPower = 20;
                parameter2.DefencePower = 5;
                parameter2.GainExp = 100;

                enemyMaster = new EnemyMaster();
                enemyMaster.Parameters = new List<EnemyParameter>();
                enemyMaster.Parameters.Add(parameter1);
                enemyMaster.Parameters.Add(parameter2);

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(enemyMaster);
                System.IO.File.WriteAllText(@"D:enemy.json", json);
            }
            

			Console.WriteLine("Game Start!!");

			Player player = new Player("中野くん", 1, 0, 20, 30, 10);

			while (player.IsAlive)
			{
                int randomIndex = DamageCalculator.RandomCaluculator.Next(enemyMaster.Parameters.Count);
                Enemy enemy = new Enemy(enemyMaster.Parameters[randomIndex]);
                    
                Console.WriteLine(enemy.Name + "が現れた！");

				//バトル
				Battle battle = new Battle( player, enemy);
				bool battleIsEnd = false;
				while(!battleIsEnd)
				{
					Console.WriteLine("コマンド");
					Console.ReadLine();

					battleIsEnd = battle.AdvanceTurn();

					Console.WriteLine(player.Name + "のHP:" + player.HP);
				}
			}

			Console.WriteLine("Game Over");


			Console.WriteLine("press return to quit.");
			Console.ReadLine();
		}
	}
}
