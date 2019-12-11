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
			EnemyParamenter parameter1 = new EnemyParamenter();
			parameter1.Name = "スラティー";
			parameter1.MaxHP = 10;
			parameter1.AttackPower = 8;
			parameter1.DefencePower = 2;
			parameter1.GainExp = 5;

			EnemyParamenter parameter2 = new EnemyParamenter();
			parameter2.Name = "ハゲオク";
			parameter2.MaxHP = 1;
			parameter2.AttackPower = 20;
			parameter2.DefencePower = 5;
			parameter2.GainExp = 100;

			EnemyMaster master = new EnemyMaster();
			master.Parameters= new List<EnemyParamenter>();
			master.Parameters.Add(parameter1);
			master.Parameters.Add(parameter2);
			
			{

			//Console.WriteLine(enemyMaster.Parameters[0].Name+","+ enemyMaster.Parameters[0].MaxHP+","+enemyMaster.Parameters[0].AttackPower);
			}
			if(enemyMaster == null){
				//マスターデータ読み出し失敗。デフォルト値を入れる

			}

			Console.ReadLine();
			return;

			
			

			
			



            Console.WriteLine("GameStart");

            Player player = new Player("勇者オキャノーン", 1, 0, 20, 10, 5);

            while(player.IsAlive)
            {
				int randomIndex=DamageCalculator
                Enemy enemy = new Enemy("okuty", 10, 8, 2, 5);
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
	} }
