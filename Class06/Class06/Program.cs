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
			if ( System.IO.File.Exists( @"aiueo" ))
			{
				//マスターデータファイルが存在する
				string json = System.IO.File.ReadAllText( @"aiueo" );
				enemyMaster = Newtonsoft.Json.JsonConvert.DeserializeObject<EnemyMaster>( json );
			}
			else
			{
				//存在しない場合、デフォルトの値で作ってjsonを出力
				enemyMaster = new EnemyMaster( );
				enemyMaster.Parameters = new List<EnemyParameter>( );

				EnemyParameter enemyParameter = new EnemyParameter( );
				enemyParameter.Name = "メタルスライム";
				enemyParameter.MaxHP = 5;
				enemyParameter.AttackPower = 55;
				enemyParameter.DefencePower = 100;
				enemyParameter.GainExp = 2000;

				enemyMaster.Parameters.Add( enemyParameter );

				string result = Newtonsoft.Json.JsonConvert.SerializeObject( enemyMaster );
				System.IO.File.WriteAllText( @"aiueo", result );
			}

			Player player = new Player( "えなりかずき", 100, 0, 210, 12, 8 );

			while ( true )
			{
				//エンカウント
				int enemyIndex = DamageCalculator.RandomProvider.Next( enemyMaster.Parameters.Count );
				Enemy enemy = new Enemy( enemyMaster.Parameters[ enemyIndex ] );

				Battle battle = new Battle( player, enemy );

				Console.WriteLine( enemy.Name + "が現れた！" );

				bool battleIsEnd = false;
				while ( !battleIsEnd )
				{
					//ターン進行
					Console.WriteLine( player.Name + "HP:" + player.HP );

					//プレイヤーの行動入力(何も受ける情報はない)
					Console.WriteLine( "Enterでターンが進みます" );
					Console.ReadLine( );

					//プレイヤーと敵が殴り合う
					battleIsEnd = battle.AdvanceTurn( );
				}

				if ( !player.IsAlive )
				{
					Console.WriteLine( "YOU LOSE" );
					break;
				}
				Console.WriteLine( );
			}

			Console.WriteLine("press return to quit.");
			Console.ReadLine();
		}
	}
}
