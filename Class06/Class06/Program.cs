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
			EnemyMaster enemymaster = null;
			try 
			{
				string Enemyjson = System.IO.File.ReadAllText(@"D:\enemy.json");
				enemymaster = Newtonsoft.Json.JsonConvert.DeserializeObject<EnemyMaster>( Enemyjson );
			}
			catch 
			{
				Console.WriteLine("エラー：データがありません");
			}
			if( enemymaster == null) 
			{
				EnemyParameter Slime = new EnemyParameter();
				Slime.Name = "スライム";
				Slime.MAXHP = 3;
				Slime.AttackPower = 5;
				Slime.DefencePower = 5;
				Slime.GainExp = 3;

				EnemyParameter Goblin = new EnemyParameter();
				Goblin.Name = "ゴブリン";
				Goblin.MAXHP = 6;
				Goblin.AttackPower = 10;
				Goblin.DefencePower = 7;
				Goblin.GainExp = 15;

				EnemyMaster EnemyDisplay = new EnemyMaster();
				EnemyDisplay.Parameters = new List<EnemyParameter>();
				EnemyDisplay.Parameters.Add(Slime);
				EnemyDisplay.Parameters.Add(Goblin);


				string Enemyjson = Newtonsoft.Json.JsonConvert.SerializeObject(EnemyDisplay);
				System.IO.File.WriteAllText(@"D:\enemy.json", Enemyjson);
			}

			HeroesMaster heroesmaster = null;
			try 
			{
				string Heroesjson = System.IO.File.ReadAllText(@"D:\heroes.json");
				heroesmaster = Newtonsoft.Json.JsonConvert.DeserializeObject<HeroesMaster>( Heroesjson );
			} 
			catch 
			{
				Console.WriteLine("エラー：データがありません");
			}
			if (heroesmaster == null) {
				HeroesParameter Brave = new HeroesParameter();
				Brave.Name  = "勇者";
				Brave.MAXHP = 20;
				Brave.AttackPower = 10;
				Brave.DefencePower = 5;
				Brave.Level = 1;
				Brave.Exp = 0;

				HeroesParameter Wicth = new HeroesParameter();
				Wicth.Name = "魔法使い";
				Wicth.MAXHP = 20;
				Wicth.AttackPower = 5;
				Wicth.DefencePower = 5;
				Wicth.Level = 1;
				Wicth.Exp = 0;

				HeroesMaster HeroesDisplay = new HeroesMaster();
				HeroesDisplay.Parameters = new List<HeroesParameter>();
				HeroesDisplay.Parameters.Add( Brave );
				HeroesDisplay.Parameters.Add( Wicth );


				string heroesjson = Newtonsoft.Json.JsonConvert.SerializeObject(HeroesDisplay);
				System.IO.File.WriteAllText(@"D:\enemy.json", heroesjson);
			}

			Console.WriteLine( "ゲームスタート" );
			Player Brave = new Player(enemymaster.Parameters[0]);
			while ( Brave.IsAlive )
			{
				int Randamindex = DamageCalculator.RandomCalculator.Next(enemymaster.Parameters.Count);
				Enemy enemy = new Enemy( enemymaster.Parameters[ Randamindex ]);

				Console.WriteLine( enemy.Name + "が現れた！" );

				//バトル
				Battle battle = new Battle( Brave, enemy );
				bool battleIsEnd = false;
				while ( !battleIsEnd )
				{
					Console.WriteLine( "コマンド？" );
					Console.ReadLine( );

					battleIsEnd = battle.AdvanceTurn( );

					Console.WriteLine( Brave.Name + "のHP:" + Brave.HP );
				}
			}


			Console.WriteLine( "ゲームオーバー" );
			Console.ReadLine();
		}
	}
}
