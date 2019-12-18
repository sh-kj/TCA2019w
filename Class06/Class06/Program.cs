using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class06 {
	class Program {
		static void Main( string[ ] args ) {
			
			EnemyMaster enemyMaster=null;
			try{
			string json=System.IO.File.ReadAllText(@"D:\enemy.json");
			 enemyMaster=Newtonsoft.Json.JsonConvert.DeserializeObject<EnemyMaster>(json);
			}
			catch(Exception e){
				Console.WriteLine("masterdata cannot read:"+e.ToString());
			}
			if(enemyMaster==null)
			{
				//master data reading failed
				//defort your master data.
			EnemyParameter parameter1 = new EnemyParameter( );
			parameter1.Name = " slime ";
			parameter1.MaxHP = 10;
			parameter1.AttackPower = 8;
			parameter1.DefencePower = 2;
			parameter1.GainExp = 5;
			
			EnemyParameter parameter2 = new EnemyParameter( );
			parameter2.Name = " okuty ";
			parameter2.MaxHP = 1;
			parameter2.AttackPower = 20;
			parameter2.DefencePower = 5;
			parameter2.GainExp = 100;

			enemyMaster = new EnemyMaster( );
			enemyMaster.Parameter = new List<EnemyParameter>( );
			enemyMaster.Parameter.Add( parameter1 );
			enemyMaster.Parameter.Add( parameter2 );

			string json = Newtonsoft.Json.JsonConvert.SerializeObject( enemyMaster );

			Console.WriteLine( json );
			System.IO.File.WriteAllText( @"D:\enemy.json", json );

			Console.ReadLine( );
			return;
			}



			//Console.WriteLine( enemyMaster.Parameter[0].Name+ "," + enemyMaster.Parameter[0].MaxHP);

			//Console.ReadLine();
			//return;


			///*
			
			//*/

			Console.WriteLine( "game start" );


			Player player = new Player( "hero", 1, 0, 20, 10, 5 );

			while (player.IsAlive ) {
				Enemy enemy = new Enemy( enemyMaster.Parameter[0].Name,enemyMaster.Parameter[0].MaxHP,enemyMaster.Parameter[0].AttackPower,enemyMaster.Parameter[0].DefencePower,enemyMaster.Parameter[0].GainExp );

				Console.WriteLine( enemy.Name + " discover! " );

				//battle
				Battle battle = new Battle( player, enemy );
				bool battleIsEnd = false;
				while ( !battleIsEnd ) {
					Console.WriteLine( " comment? " );
					Console.ReadLine( );

					battleIsEnd = battle.AdvanceTurn( );

					Console.WriteLine( player.Name + "'s hp:" + player.HP );
				}
			}

			Console.WriteLine( "game over" );
			Console.WriteLine( "press return to quit" );
		}
	}
}


