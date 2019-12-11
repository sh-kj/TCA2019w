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
			parameter1 .Name = "金";
			parameter1 .MaxHP = 10;
			parameter1 .AttackPower = 8;
			parameter1 .DefencePower = 5;
			parameter1 .GainExp = 100;

			EnemyParameter parameter2 = new EnemyParameter( );
			parameter2 .Name = "okuty";
			parameter2 .MaxHP = 1;
			parameter2 .AttackPower = 20;
			parameter2 .DefencePower = 5;
			parameter2 .GainExp = 100;

			EnemyMaster master = new EnemyMaster( );
			master .Parameters = new List<EnemyParameter>( );
			master .Parameters .Add( parameter1 );
			master .Parameters .Add( parameter2 );

			string json = Newtonsoft .Json .JsonConvert .SerializeObject( master );

			Console .WriteLine( json );
			System .IO .File .WriteAllText( @"D:\emeny.json", json );
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
