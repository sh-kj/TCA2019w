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
			Enemymaster enemyMaster = null;
			try {
				string json = System.IO.File.ReadAllText( @"D:\enemy.json" );
				enemyMaster = Newtonsoft.Json.JsonConvert.DeserializeObject<Enemymaster>( json );
			} catch ( Exception e ) {

				Console.WriteLine( "マスタード読み込めません" + e.ToString() );
			}
			if (enemyMaster == null ) { 

			EnemyParameter parameter1 = new EnemyParameter( );
			parameter1.Name = "tsukada";
			parameter1.MaxHP = 10;
			parameter1.AttackPower = 8;
			parameter1.DefencePower = 2;
			parameter1.GainExp = 5;

			EnemyParameter parameter2 = new EnemyParameter( );
			parameter2.Name = "tsukada分身";
			parameter2.MaxHP = 1;
			parameter2.AttackPower = 20;
			parameter2.DefencePower = 5;
			parameter2.GainExp = 100;

			Enemymaster master = new Enemymaster( );
			enemyMaster.Patameters = new List<EnemyParameter>( );
			enemyMaster.Patameters.Add( parameter1 );
			enemyMaster.Patameters.Add( parameter2 );

			string json = Newtonsoft.Json.JsonConvert.SerializeObject( master );
			Console.WriteLine( json );
			System.IO.File.WriteAllText( @"D:\enemy.json", json );
			}




			/*Console.ReadLine( );
			return;*/

			Console.WriteLine("ゲームスタート");

			Player player = new Player("Okuty", 1, 0, 20, 10, 5);

			while( player.IsAlive )
			{
				int randomIndex = DamageCalculator.RandomCaculator.Next( enemyMaster.Patameters.Count );

				Enemy enemy = new Enemy(enemyMaster.Patameters[randomIndex]);
				Console.WriteLine(enemy.Name + "が現れた！");

				Battle battle = new Battle(player, enemy);
				bool battleIsEnd = false;
				while( !battleIsEnd )
				{
					Console.WriteLine("コマンド？");
					Console.ReadLine();

					battleIsEnd = battle.AdvanceTurn();

					Console.WriteLine(player.Name + "のHP:" + player.HP);
				}
			}

			Console.WriteLine("ゲームオーバー");

			//Console.WriteLine("press return to quit.");
			Console.ReadLine();
		}
	}
}
