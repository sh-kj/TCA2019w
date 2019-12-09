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
			EnemyMaster senaSlime;

			if ( System.IO.File.Exists(@"D:\enemy.json") )
			{
				string json = System.IO.File.ReadAllText( @"D:\enemy.json" );

				senaSlime = Newtonsoft.Json.JsonConvert.DeserializeObject<EnemyMaster>( json );
			} else {
				senaSlime = new EnemyMaster( );
				senaSlime.Parameters = new List<EnemyParameter>( );

				EnemyParameter senaP = new EnemyParameter( );
				
				senaP.Name = "セナスライム";
				senaP.HP = 10;
				senaP.attackPower = 5;
				senaP.DefencePower = 1;
				senaP.GeinExp = 100;

				senaSlime.Parameters.Add(senaP);

				string yomikomi = Newtonsoft.Json.JsonConvert.SerializeObject( senaSlime );
				System.IO.File.WriteAllText( @"D:\enemy.json", yomikomi );//テキスト書き込み
			}
			

			Player player = new Player("sena",1,0,10,5,5);

			while (player.IsAlive)
			{
				Console.ReadLine( );
				//ランダム関数
				int index = DamageCalculator.provider.Next( senaSlime.Parameters.Count );
				//エンカウント
				Enemy enemy = new Enemy(senaSlime.Parameters[index]);

				Battle battle = new Battle(player,enemy);

				Console.WriteLine(enemy.Name+"が現れた！");

				bool BattleEND = false;
				while (!BattleEND)
				{

					//ターン開始
					//プレーヤーの行動入力（何も受ける情報はない）
					Console.WriteLine("EnterでターンEND");
					Console.ReadLine();
					BattleEND = battle.AdvanceTurn();



				}
			}

			Console.WriteLine("press return to quit.");
			Console.ReadLine();
		}
	}
}
