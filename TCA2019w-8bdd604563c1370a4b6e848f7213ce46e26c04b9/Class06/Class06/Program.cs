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
			if(System.IO.File.Exists(@"D:￥enemy.json"))
				{
				//マスターデータファイルが存在する
				string json=System.IO.File.ReadAllText(@"D:￥enemy.json");
				enemyMaster=Newtonsoft.Json.JsonConvert.DeserializeObject<EnemyMaster>(json);
			}
			else{
				//存在しない場合、デフォルトの値で作ってjsonを出力
				enemyMaster=new EnemyMaster();
				enemyMaster.Parameters=new List <EnemyParameter>();

				EnemyParameter enemyParameter=new EnemyParameter();
				enemyParameter.Name="メタルスライム";
				enemyParameter.MaxHP=5;
				enemyParameter.AttackPower=10;
				enemyParameter.DefencePower=300;
				enemyParameter.GainEXP=2000;



                enemyMaster.Parameters.Add(enemyParameter);

				string result = Newtonsoft.Json.JsonConvert.SerializeObject(enemyMaster);
				System.IO.File.WriteAllText(@"D:￥enemy.json",result);
			}

			/*string json = System.IO.File.ReadAllText(@"D:￥enemy.json");

			EnemyParameter parameter = Newtonsoft.Json.JsonConvert.DeserializeObject<EnemyParameter>(json);

			Console.WriteLine(parameter.Name+"HP:"+parameter.MaxHP);*/





			/*EnemyParameter parameter=new EnemyParameter();
			parameter.Name="メタルスライム";
			parameter.MaxHP=5;
			parameter.AttackPower=10;
			parameter.DefencePower=300;
			parameter.GainEXP=2000;


			string result=Newtonsoft.Json.JsonConvert.SerializeObject(parameter);

			Console.WriteLine(result);

			System.IO.File.WriteAllText("D:￥enemy.json",result);*/
			//Console.ReadLine();

			//return;

			Player player=new Player("勇者",1,0,20,8,5);

			while (true)
			{
				//エンカウント
				int enemyindex=DamageCalculator.RanbomProvider.Next(enemyMaster.Parameters.Count);
				Enemy enemy = new Enemy(enemyMaster.Parameters[0]);
				Battle battle= new Battle(player,enemy);

				Console.WriteLine(enemy.Name+"が現れた！！");

				bool battleIsEnd=false;
				while (!battleIsEnd)
				{
					//ターン進行
					Console.WriteLine(player.Name+"HP"+player.HP);

					//プレイヤーの行動入力（何も受ける情報がない）
					Console.WriteLine("Enterで1ターン進みます");
					Console.ReadLine();

					//プレイヤーと敵が殴り合う
					battleIsEnd=battle.AdvanceTurn();
				}

				if (!player.IsAlive)
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

	public Battle(Player player, Enemy enemy)
		{
			BattlePlayer=player;
			BattleEnemy=enemy;
		
	}
		public bool AdvanceTurn()
		{
			//プレイヤーが敵を攻撃
			int damage=BattlePlayer.Attack(BattleEnemy);
			//プレイヤーが敵を慰める
			Console.WriteLine(BattlePlayer.Name + "の攻撃！！" + BattleEnemy.Name + "に" + damage + "のダメージ！！");
			if (!BattleEnemy.IsAlive)
			{
				//敵がやられた
				Console.WriteLine(BattleEnemy.Name + "を倒した！！");
                Console.WriteLine();
				return true;
			}
			//敵がプレイヤーを攻撃
			damage=BattleEnemy.Attack(BattlePlayer);
			//敵がプレイヤーを慰める
			Console.WriteLine(BattleEnemy.Name + "の攻撃！！" + BattlePlayer.Name + "に" + damage + "のダメージ！！");
			if(!BattlePlayer.IsAlive)
			{
				//敵がプレイヤーをたおした
				Console.WriteLine(BattlePlayer.Name + "は倒れた．．．．");
				return true;
			}
			return false;
		}
	}
}
