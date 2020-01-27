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
            int enecou=0;

			Player player = new Player("sena",1,0,10,7,5);

            Console.WriteLine("セナのただの冒険が始まった。。。");

			while (player.IsAlive)
			{
                Console.WriteLine("--------------------------");
                //Console.ReadLine( );
                //ランダム関数
                int index = DamageCalculator.provider.Next( 6 );
                int ene1 = DamageCalculator.provider.Next( 2 );
                int ene2 = DamageCalculator.provider.Next( 5 );
                if (countene%5==0&&countene!=0)
                {
                    if (index==1)
                    {
                        Console.WriteLine("体力の泉で休憩した。HP回復");
                        player.RecoverAll();
                    }else if (index==2)
                    {
                        Console.WriteLine("力の神が力を与えてくれた。Attack+15");
                        player.attackPowerUP(15);

                    }else if (index==3)
                    {
                        Console.WriteLine("守りの神に出会った。Defence+10");
                        player.DefenceUP(20);
                    }
                    else if (index==4)
                    {
                        Console.WriteLine("堕天使に騙されてステータス激減。MaxHP-10 Attack-20 Defence-20");
                        player.PowerDown();
                    }
                    else if (index==5)
                    {
                        Console.WriteLine("体力神に出会った。+MaxHP+50 HP回復");
                        player.MaxHPUP(100);
                        player.RecoverAll();
                    }
                    else if (index==0)
                    {
                        Console.WriteLine("体力の泉で修行してステータスが上がった。MaxHP+10 Attack+5 Defence+3 HP回復");
                        player.MaxHPUP(20);
                        player.attackPowerUP(5);
                        player.DefenceUP(5);
                        player.RecoverAll();
                    }
                }

                //エンカウント
                www++;
                if (www>=4)
                {
                    www = sp;
                    sp++;
                }
                if (sp==0)
                {
                    enecou = ene1;
                }
                else
                {
                    enecou = ene2;
                }
				Enemy enemy = new Enemy(senaSlime.Parameters[enecou]);

				Battle battle = new Battle(player,enemy);

				Console.WriteLine(enemy.Name+"が現れた！");

				bool BattleEND = false;
				while (!BattleEND)
				{

                    /*ターン開始
                    プレーヤーの行動入力（何も受ける情報はない）
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
                    }*/



                    Console.WriteLine("EnterでターンEND");
					Console.ReadLine();
					BattleEND = battle.AdvanceTurn();
                    
				}
                countene++;
			}
            countene--;
			Console.WriteLine("うん、君じゃ無理");
			Console.WriteLine("");
			Console.WriteLine("倒した敵の数"+countene);
			Console.ReadLine();
		}
	}
}
