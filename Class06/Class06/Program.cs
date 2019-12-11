using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class06 {
	class Program { 

		static void Main( string[ ] args ) {
			EnemyMaster enemyMaster = null;
			
			try { 
			string json = System.IO.File.ReadAllText( @"C:\Users\Ryooo\Documents\GitHub\TCA2019w\Class06\enemy.json" );
			enemyMaster = Newtonsoft.Json.JsonConvert.DeserializeObject<EnemyMaster>( json );
			} catch ( Exception e ) {
				Console.WriteLine( "マスターデータの読み込みに失敗しました:" + e.ToString( ) );
			}

			if ( enemyMaster == null ) {
				/*マスターデータの読み込みに失敗しているので
				  デフォルト値でマスターデータを作る*/
				EnemyParameter parameter1 = new EnemyParameter( );
				parameter1.Name = "スライム";
				parameter1.MaxHP = 10;
				parameter1.AttackPower = 8;
				parameter1.DefencePower = 2;
				parameter1.GainExp = 5;

				EnemyParameter parameter2 = new EnemyParameter( );
				parameter2.Name = "おくてぃ～";
				parameter2.MaxHP = 1;
				parameter2.AttackPower = 20;
				parameter2.DefencePower = 5;
				parameter2.GainExp = 100;

				enemyMaster = new EnemyMaster( );
				enemyMaster.Parameters = new List<EnemyParameter>( );
				enemyMaster.Parameters.Add( parameter1 );
				enemyMaster.Parameters.Add( parameter2 );

				string json = Newtonsoft.Json.JsonConvert.SerializeObject( enemyMaster );
				System.IO.File.WriteAllText( @"C:\Users\Ryooo\Documents\GitHub\TCA2019w\Class06\enemy.json", json );

			}

			/*Console.WriteLine( enemyMaster.Parameters[ 0 ].Name + ", " +
				enemyMaster.Parameters[ 0 ].MaxHP + ", " + enemyMaster.Parameters[ 0 ].AttackPower + 
				", " + enemyMaster.Parameters[ 0 ].DefencePower );

			Console.ReadLine( );
			return;

			EnemyParameter parameter1 = new EnemyParameter( );
			parameter1.Name = "スライム";
			parameter1.MaxHP = 10;
			parameter1.AttackPower = 8;
			parameter1.DefencePower = 2;
			parameter1.GainExp = 5;

			EnemyParameter parameter2 = new EnemyParameter( );
			parameter2.Name = "おくてぃ～";
			parameter2.MaxHP = 1;
			parameter2.AttackPower = 20;
			parameter2.DefencePower = 5;
			parameter2.GainExp = 100;

			enemyMaster master = new enemyMaster( );
			master.Parameters = new List<EnemyParameter>( );
			master.Parameters.Add( parameter1 );
			master.Parameters.Add( parameter2 );

			string json = Newtonsoft.Json.JsonConvert.SerializeObject( master );

			Console.WriteLine( json );
			System.IO.File.WriteAllText( @"C:\Users\Ryooo\Documents\GitHub\TCA2019w\Class06\enemy.json", json );

			Console.ReadLine( );
			return;*/

			Console.WriteLine( "ゲームスタート" );

			Player player = new Player( "勇者", 1, 0, 20, 10, 5 );

			while ( player.IsAlive ) {
				int randomIndex = DamageCalculator.RandomCalculator.Next
					( enemyMaster.Parameters.Count );

				Enemy enemy = new Enemy( enemyMaster.Parameters[ randomIndex ] );
				
				Console.WriteLine( enemy.Name + "が現れた!" );

				Battle battle = new Battle( player, enemy );
				bool battleEnd = false;
				while ( !battleEnd ) {
					Console.WriteLine( "コマンド?" );
					Console.ReadLine( );

					battleEnd = battle.AdvanceTurn( );

					Console.WriteLine( player.Name + "のHP:" + player.HP );
				}
			}
			Console.WriteLine( "ゲームオーバー" );

			Console.WriteLine( "press return to exit" );
			Console.ReadLine( );
		}
	}
}
