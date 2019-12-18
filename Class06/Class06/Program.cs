using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Class06 {
	class Program {

		const int PLAYER_LEVEL = 0;
		const int PLAYER_EXP = 0;
		const int PLAYER_HP = 20;
		const int PLAYER_ATTACK = 10;
		const int PLAYER_DEFEND = 3;


		static void Main( string[ ] args ) {

			EnemyMaster enemyMaster = null;
			string json;
			try {
				//JSONファイルからデータの読み込み
				json = System.IO.File.ReadAllText( Environment.CurrentDirectory + @"\config\enemy.json" );
				enemyMaster = Newtonsoft.Json.JsonConvert.DeserializeObject<EnemyMaster>( json );
				//Console.WriteLine(enemyMaster.Parameters[0].Name + ", " + enemyMaster.Parameters[0].MaxHP);
			} catch ( Exception e ) {
				Console.WriteLine( "マスターデータの読み込みに失敗しました、\n" + e.ToString( ) + "\nデータを作成しました。\n" );
			}

			if ( enemyMaster == null ) {
				//マスターデータの読み込みに失敗しているので、デフォルト値でマスターデータを作る。
				//JSONファイルへパラメーターデータの書き込み準備
				EnemyParameter enemy_normal_slime = new EnemyParameter( );
				enemy_normal_slime.Name = "スライム";
				enemy_normal_slime.MaxHP = 4;
				enemy_normal_slime.AttackPower = 2;
				enemy_normal_slime.DefencePower = 1;
				enemy_normal_slime.GainExp = 3;
				enemy_normal_slime.ResultLog = "は倒された。";

				EnemyParameter enemy_king_slime = new EnemyParameter( );
				enemy_king_slime.Name = "キングスライム";
				enemy_king_slime.MaxHP = 15;
				enemy_king_slime.AttackPower = 6;
				enemy_king_slime.DefencePower = 5;
				enemy_king_slime.GainExp = 6;
				enemy_king_slime.ResultLog = "は押しつぶされた。";

				EnemyParameter enemy_client = new EnemyParameter( );
				enemy_client.Name = "頭の悪いクライアント";
				enemy_client.MaxHP = 3;
				enemy_client.AttackPower = 10;
				enemy_client.DefencePower = 10;
				enemy_client.GainExp = 1;
				enemy_client.ResultLog = "は無茶苦茶な要求に耐えられず体力がそこを尽きた…";

				EnemyParameter enemy_miyano = new EnemyParameter( );
				enemy_miyano.Name = "みやの";
				enemy_miyano.MaxHP = 5;
				enemy_miyano.AttackPower = 1;
				enemy_miyano.DefencePower = 2;
				enemy_miyano.GainExp = -5;
				enemy_miyano.ResultLog = "！触らないで下さい…";

				enemyMaster = new EnemyMaster( );
				enemyMaster.Parameters = new List<EnemyParameter>( );
				enemyMaster.Parameters.Add( enemy_normal_slime );
				enemyMaster.Parameters.Add( enemy_king_slime );
				enemyMaster.Parameters.Add( enemy_client );
				enemyMaster.Parameters.Add( enemy_miyano );

				//JSONファイルへパラメーターデータの書き込み
				json = Newtonsoft.Json.JsonConvert.SerializeObject( enemyMaster );
				System.IO.File.WriteAllText( Environment.CurrentDirectory + @"\config\enemy.json", json );

			}

			Console.WriteLine( "ゲームスタート\n" );
			Player _player = new Player( "塚田社長", PLAYER_LEVEL, PLAYER_EXP, PLAYER_HP, PLAYER_ATTACK, PLAYER_DEFEND );

			while ( _player.IsAlive ) {
				int randomIndex = DamageCalculator.RandomCalculator.Next( enemyMaster.Parameters.Count );

				//敵の出力
				Enemy _enemy = new Enemy( enemyMaster.Parameters[ randomIndex ] );
				Console.WriteLine( _enemy.Name + "が現れた!" );

				//バトル処理
				Battle battle = new Battle( _player, _enemy );
				bool _battles_end = false;
				while ( !_battles_end ) {
					Console.WriteLine( "コマンド？" );
					Console.ReadLine( );

					_battles_end = battle.AdvaneTurn( );

					if ( !_battles_end ) {
						Console.WriteLine( _player.Name + "のHP" + _player.HP );
					}
				}
			}

			Console.WriteLine( "\nゲームオーバー" );
			Console.ReadLine( );
		}
	}
}
