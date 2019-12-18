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
			try {
			string json = System.IO.File.ReadAllText( @"D:\enemy.json" );
			enemyMaster = Newtonsoft.Json.JsonConvert.DeserializeObject<EnemyMaster>( json );
				}
			catch ( Exception e ) {
				Console.WriteLine( "マスターデータの読み込みに失敗しました"　 + e.ToString( ) );
				}

			if( enemyMaster == null ) {
				EnemyParameter parameter1 = new EnemyParameter( );
			parameter1 .Name = "okukky";
			parameter1 .MaxHP = 10;
			parameter1 .AttackPower = 8;
			parameter1 .DefencePower = 5;
			parameter1 .GainExp = 50;

			EnemyParameter parameter2 = new EnemyParameter( );
			parameter2 .Name = "金";
			parameter2 .MaxHP = 30;
			parameter2 .AttackPower = 20;
			parameter2 .DefencePower = 5;
			parameter2 .GainExp = 100;

				EnemyParameter parameter3 = new EnemyParameter( );
				parameter2.Name = "かたおきゃ";
				parameter2.MaxHP = 100;
				parameter2.AttackPower = 25;
				parameter2.DefencePower = 25;
				parameter2.GainExp = 10000;

				enemyMaster = new EnemyMaster( );
			enemyMaster .Parameters = new List<EnemyParameter>( );
			enemyMaster .Parameters .Add( parameter1 );
			enemyMaster .Parameters .Add( parameter2 );

			string json = Newtonsoft .Json .JsonConvert .SerializeObject( enemyMaster );

			Console .WriteLine( json );
			System .IO .File .WriteAllText( @"D:\enemy.json", json );
				}

			Console .WriteLine( "ゲームスタート" );

			Player player = new Player( "おきゃの", 1, 0, 60, 50, 20 );

			while ( player.IsAlive
				
				) {
				int randomIndex = DamageCalculator.RandomCalculator.Next(enemyMaster.Parameters.Count);
				Enemy enemy = new Enemy( enemyMaster .Parameters[randomIndex] );
				Console .WriteLine(enemy .Name + "が現れた！" );

				Battle battle = new Battle( player, enemy );

		bool battleIsEnd = false;
				while ( !battleIsEnd ) {
					Console .WriteLine( "コマンド？" );
					Console .ReadLine( );

					battleIsEnd = battle .AdvanceTurn( );

					Console .WriteLine(player .Name + "のHP：" + player .HP );
				}
	Console .WriteLine( "TCAが平和になった" );
				Console .ReadLine( );

			}
		}
}
}
