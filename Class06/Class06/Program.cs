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

			if ( System.IO.File.Exists(@"D:\enemy.json") ) {

				//マスターデータファイルが存在する
				string Json=System.IO.File.ReadAllText(@"D:\enemy.json");

				enemyMaster=Newtonsoft.Json.JsonConvert.DeserializeObject<EnemyMaster>(Json);
			} else {

				//存在しない
				enemyMaster=new EnemyMaster();
				enemyMaster.Parameters= new List<EnemyParameter>();

				EnemyParameter enemyParameter=new EnemyParameter();
				enemyParameter=new EnemyParameter();
				enemyParameter.Name="メタルいるま";
				enemyParameter.MaxHP=5;
				enemyParameter.AttackPower=10;
				enemyParameter.DefencePower=300;
				enemyParameter.GainExp=2000;

				enemyMaster.Parameters.Add(enemyParameter);

				string result= Newtonsoft.Json.JsonConvert.SerializeObject(enemyParameter);

				System.IO.File.WriteAllText(@"D:\enemy.json",result);
			}



			string json = System.IO.File.ReadAllText(@"D:\enemy.json");

			EnemyParameter parameter= Newtonsoft.Json.JsonConvert.DeserializeObject<EnemyParameter>(json);

			Console.WriteLine(parameter.Name+",HP:"+parameter.MaxHP);
			/*
			EnemyParameter parameter=new EnemyParameter();
			parameter.Name="メタルいるま";
			parameter.MaxHP=5;
			parameter.AttackPower=10;
			parameter.DefencePower=300;
			parameter.GainExp=2000;
			


			string result= Newtonsoft.Json.JsonConvert.SerializeObject(parameter);

			Console.WriteLine(result);
			

			System.IO.File.WriteAllText(@"D:\enemy.json",result);
			*/


			Console.ReadLine();


			//return;

            Player player = new Player("いるま", 1, 0, 20, 8, 5);


            while (true)
            {
                //エンカウント   
                Enemy enemy = new Enemy(enemy.Name,enemyParameter.MaxHP,enemyParameter.AttackPower,enemyParameter.DefencePower,enemyParameter.GainExp);
				

                Battle battle =new Battle(player, enemy);

                Console.WriteLine(enemy.Name + "が現れた！");

                bool BattleIsEnd = false;
                while (!BattleIsEnd)
                {
                    //ターン進行
                    Console.WriteLine(player.Name + "HP" + player.HP);

                    //プレイヤーの行動入力(何も受ける情報がない)
                    Console.WriteLine("Enterでターンが進みます");
                    Console.ReadLine();

                    //プレゼンと敵が殴り合う
                    BattleIsEnd=battle.AdvanceTurn();
                }

                //プレイヤーがゲームオーバー
                if (!player.IsAlive)
                {
                    Console.WriteLine("ゲームオーバー");
                    break;
                }

                //敵がゲームオーバー
                if (!enemy.IsAlive)
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
    class Battle
    {
        private Player BattlePlayer;
        private Enemy BattleEnemy;

        public Battle(Player player,Enemy enemy)
        {
            BattlePlayer = player;
            BattleEnemy = enemy;
        }
        public bool AdvanceTurn() {

            //プレイヤーと敵が殴り合う
        int damege=BattlePlayer.Attack(BattleEnemy);
            Console.WriteLine(BattlePlayer.Name + "の攻撃!" + BattleEnemy.Name + "に" + damege + "のダメージ!");

            
            if (!BattleEnemy.IsAlive)
            {
                //敵が死んだ
                Console.WriteLine(BattleEnemy.Name + "を倒した!");
                return true;
            }




            //敵がプレイヤーを攻撃
            damege = BattleEnemy.Attack(BattlePlayer);
            Console.WriteLine(BattleEnemy.Name + "の攻撃!" + BattlePlayer.Name + "に" + damege + "のダメージ!");

            if (!BattlePlayer.IsAlive)
            {
                //プレイヤーが死んだ
                Console.WriteLine(BattlePlayer.Name + "を倒した!");
                return true;

            }
            return false;




        }

            

    }
}
