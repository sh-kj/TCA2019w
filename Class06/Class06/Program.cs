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
			PlayerMaster playerMaster = null;
			try {
				string json = System.IO.File.ReadAllText( @"D:\player.json" );
				playerMaster = Newtonsoft.Json.JsonConvert.DeserializeObject<PlayerMaster>( json );
			}
			catch ( Exception e ) {
				Console.WriteLine( "マスターデータ読み込みに失敗しました：" + e.ToString( ) );
			}
			if ( playerMaster == null ) {
				PlayerParameter parameter1 = new PlayerParameter( );
				parameter1.Level = 1;
				parameter1.NextLevelExp = 0;
				parameter1.MaxHP = 10;
				parameter1.AttackPower = 10;
				parameter1.DefencePower = 5;

				playerMaster = new PlayerMaster();
				playerMaster.Parameters = new List<PlayerParameter>();
				playerMaster.Parameters.Add(parameter1);

				string json = Newtonsoft.Json.JsonConvert.SerializeObject( playerMaster );
				System.IO.File.WriteAllText( @"D:\player.json", json );
			}

			EnemyMaster enemyMaster = null;
			try {
				string json = System.IO.File.ReadAllText( @"D:\enemy.json" );
				enemyMaster  = Newtonsoft.Json.JsonConvert.DeserializeObject<EnemyMaster>  ( json );
			}
			catch ( Exception e ) { 
				Console.WriteLine( "マスターデータ読み込みに失敗しました：" + e.ToString( ) );
			}
			if ( enemyMaster == null ) {
				//マスターデータ読み出しに失敗しているので
				//デフォルト値でマスターデータを作る
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

				EnemyMaster master = new EnemyMaster( );
				master.Parameters = new List< EnemyParameter>( );
				master.Parameters.Add( parameter1 );
				master.Parameters.Add( parameter2 );

				string json = Newtonsoft.Json.JsonConvert.SerializeObject( master );
				System.IO.File.WriteAllText( @"D:\enemy.json", json );
			}

			Console.WriteLine("名前を入力してください");
			string name = Console.ReadLine();

			Console.WriteLine( "ゲームスタート" );

			Player player = new Player( playerMaster.Parameters[ 0 ], playerMaster);

			bool isFirst = true;

			while( player.IsAlive ) {
				int randomIndex = 0;
				if(!isFirst)
				{
					randomIndex = DamageCalculator.RandomCalculator.Next( enemyMaster.Parameters.Count );
				}
				isFirst = false;

				Enemy enemy = new Enemy( enemyMaster.Parameters[ randomIndex ]);
				Console.WriteLine( enemy.Name + "が現れた!" );

				Battle battle = new Battle( player, enemy );
				bool battleIsEnd = false;
				while( !battleIsEnd ) {
					Console.WriteLine( "コマンド？" );
					Console.ReadLine( );

					battleIsEnd = battle.AdvanceTurn( );

					Console.WriteLine( player.Name + "のHP:" + player.HP );
				}

			}

			Console.WriteLine( "ゲームオーバー" );
			Console.ReadLine( );
		}
	}
}
