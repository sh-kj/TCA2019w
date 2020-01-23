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
			if ( System.IO.File.Exists( @"D:\enemy.json" ) ) {
				string json = System.IO.File.ReadAllText( @"D:\enemy.json" );
				enemyMaster = Newtonsoft.Json.JsonConvert.DeserializeObject<EnemyMaster>( json );
			} else {
				enemyMaster = new EnemyMaster();
				enemyMaster.Parameters = new List<EnemyParameter>( );
				EnemyParameter enemyParameter = new EnemyParameter( );
				enemyParameter.Name = "メタルスライム";
				enemyParameter.MaxHP = 5;
				enemyParameter.AttackPower = 10;
				enemyParameter.DefencePower = 300;
				enemyParameter.GainExp = 2000;

				enemyMaster.Parameters.Add( enemyParameter );

				string result = Newtonsoft.Json.JsonConvert.SerializeObject( enemyMaster );
				System.IO.File.WriteAllText( @"D:\enemy.json", result );
			}

			Player Player = new Player("勇者", 1, 0, 20, 80,10 ,30,10);

			while (true)
			{
				//エンカウント
				int enemyIndex = DamageCalculator.RandomProvider.Next( enemyMaster.Parameters.Count );
				Enemy Enemy = new Enemy(enemyMaster.Parameters[enemyIndex]);
				Battle battle = new Battle(Player, Enemy);

				Console.WriteLine(Enemy.Name + "が現れた！");
                Console.WriteLine();
				bool battleIsEnd = false;
				while(!battleIsEnd)
				{
                    //ターん進行
                    Console.WriteLine("lv" +Player.Level);
					Console.WriteLine(Player.Name + "HP" + Player.HP);

					//プレイヤーの行動入力（何も）
					Console.WriteLine("Enterでターンが進みます");
                    Console.ReadLine();
                  
                        //プレイヤーと殴り合う
                        battleIsEnd = battle.AdvanceTurn();
				}
				if (!Player.IsAlive)
				{
					Console.WriteLine("あなたは倒れてしまった");
                    Player.Money = Player.Money - 500;
                    Console.WriteLine("Goldを500失った");
                    if (Player.Money < 0)
                    {
                        Player.Money = 0;
                    }
                    Console.WriteLine("現在" + Player.Money + "Gold所持");
                    Console.WriteLine();
                    Player.RecoverAll();
                    if (Player.Money<=0)
                    {
                        Console.WriteLine("Goldをすべて失った。");
                        Console.WriteLine("G  A  M  E  O  V  E  R");
                        break;
                    }
				}
				Console.WriteLine();
			}
			Console.WriteLine("press return to quit.");
			Console.ReadLine();
		}
	}
}
