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
				enemyMaster=Newtonsoft.Json.JsonConvert.DeserializeObject<EnemyMaster>(json);
			}
			catch(Exception e ){
				Console.WriteLine("マスターデータ読み込みに失敗しました："+e.ToString());
			}

			//Console.WriteLine(enemyMaster.Parameters[0].Name+","+ enemyMaster.Parameters[0].MaxHP+","+enemyMaster.Parameters[0].AttackPower);
			
			if(enemyMaster == null){
			EnemyParamenter parameter1 = new EnemyParamenter();
			parameter1.Name = "スラティー";
			parameter1.MaxHP = 5
					;
			parameter1.AttackPower = 8;
			parameter1.DefencePower = 1;
			parameter1.GainExp = 5;
			parameter1.Drop = "ペペローション";

			EnemyParamenter parameter2 = new EnemyParamenter();
			parameter2.Name = "ハゲオク";
			parameter2.MaxHP = 1;
			parameter2.AttackPower = 20;
			parameter2.DefencePower = 5;
			parameter2.GainExp = 100;
			parameter2.Drop = "カエルの右腕";

			EnemyParamenter parameter3 = new EnemyParamenter();
			parameter3.Name = "奥村禿ノ助";
			parameter3.MaxHP = 20;
			parameter3.AttackPower = 10;
			parameter3.DefencePower = 1;
			parameter3.GainExp = 230;
			parameter3.Drop = "育毛剤";



			EnemyMaster master = new EnemyMaster();
			master.Parameters= new List<EnemyParamenter>();
			master.Parameters.Add(parameter1);
			master.Parameters.Add(parameter2);
			master.Parameters.Add(parameter3);
			
			string json = Newtonsoft.Json.JsonConvert.SerializeObject(enemyMaster);
				System.IO.File.WriteAllText(@"D:\enemy.json",json);
				//マスターデータ読み出し失敗。デフォルト値を入れる

			}

			


            Console.WriteLine("GameStart");

				Console.ReadLine();

            Player player = new Player("勇者オキャノーン", 1, 0, 20, 10, 5);

            while(player.IsAlive)
            {
				int randomIndex=DamageCalculator.RandomCalculator.Next(enemyMaster.Parameters.Count);
               
				Enemy enemy = new Enemy(enemyMaster.Parameters[randomIndex]);
                Console.WriteLine(enemy.Name + "が現れた！");

                //battle
                Battle battle = new Battle(player, enemy);
                bool battleIsEnd = false;
                while(!battleIsEnd)
                {
                    Console.WriteLine("コマンド？");
                    Console.ReadLine();

                    battleIsEnd = battle.AdvanceTurn();
                  

                    Console.WriteLine(player.Name + "のHP：" + player.HP);

					
                }
            }

            Console.WriteLine("ゲームオーバー");

		
			Console.ReadLine();
		}
	}
	} 
