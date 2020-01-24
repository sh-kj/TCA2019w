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
            int countene = 0;
            string str;
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

            int www=0,sp=0;

			Player player = new Player("sena",1,0,10,7,5);

            Console.WriteLine("セナのただの冒険が始まった。。。");

			while (player.IsAlive)
			{
                Console.WriteLine("--------------------------");
                //Console.ReadLine( );
                //ランダム関数
                //int index = DamageCalculator.provider.Next( senaSlime.Parameters.Count );

                //エンカウント
                www++;
                if (www>=3)
                {
                    www = sp;
                    sp++;
                }
				Enemy enemy = new Enemy(senaSlime.Parameters[sp]);

				Battle battle = new Battle(player,enemy);

				Console.WriteLine(enemy.Name+"が現れた！");

				bool BattleEND = false;
				while (!BattleEND)
				{

                    //ターン開始
                    //プレーヤーの行動入力（何も受ける情報はない）
                    Console.WriteLine();
                    Console.WriteLine("1→通常攻撃　2→回復　3→アイテム攻撃");
                    string line = System.Console.ReadLine();
                    string[] stArrayData = line.Split(' ');
                    int[] data = new int[stArrayData.Length];
                    while (data[0] != 1 && data[0] != 2 && data[0] != 3)
                    {
                        if (data[0]!=1&& data[0] != 2&&data[0]!=3)
                        {
                            Console.WriteLine("errorです。もう一度やり直してください。");
                        }
                        line = System.Console.ReadLine();
                        stArrayData = line.Split(' ');
                        data = new int[stArrayData.Length];
                    }
                    Console.WriteLine("EnterでターンEND");
					Console.ReadLine();
					BattleEND = battle.AdvanceTurn();



				}
                countene++;
			}

			Console.WriteLine("うん、君じゃ無理");
			Console.WriteLine("");
			Console.WriteLine("倒した敵の数"+countene);
			Console.ReadLine();
		}
	}
}
