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
            EnemyMaster enemyMaster;
            if (System.IO.File.Exists(@"D:\enemy.json"))
            {
                string json = System.IO.File.ReadAllText(@"D:\enemy.json");
                enemyMaster = Newtonsoft.Json.JsonConvert.DeserializeObject<EnemyMaster>(json);
            }
            else
            {
                enemyMaster = new EnemyMaster();
                enemyMaster.Parameters = new List<EnemyParameter>();
                EnemyParameter enemyParameter = new EnemyParameter();
                enemyParameter.Name = "スライム";
                enemyParameter.MaxHP = 5;
                enemyParameter.AttackPower = 12;
                enemyParameter.DefencePower = 6;
                enemyParameter.GainExp = 2000;

                enemyMaster.Parameters.Add(enemyParameter);

                string result = Newtonsoft.Json.JsonConvert.SerializeObject(enemyMaster);
                System.IO.File.WriteAllText(@"D:\enemy.json", result);
            }

            //名前、レベル、経験値、体力、攻撃力、防御力、魔法攻撃力、魔力
            Player Player = new Player("いるま", 1, 0, 20, 12, 5, 20,30);

            while (true)
            {
                //エンカウント
                int enemyIndex = DamageCalculator.RandomProvider.Next(enemyMaster.Parameters.Count);
                Enemy Enemy = new Enemy(enemyMaster.Parameters[enemyIndex]);
                Battle battle = new Battle(Player, Enemy);

                Console.WriteLine(Enemy.Name + "が現れた！\n");

                bool battleIsEnd = false;
                while (!battleIsEnd)
                {
                    //ターん進行
                    Console.WriteLine(Player.Name + "のステータス");
                    Console.WriteLine("レベル" + Player.Level);
                    Console.WriteLine("HP" + Player.HP);
                    Console.WriteLine("MP" + Player.MP);
                    Console.WriteLine("最大攻撃力" + Player.AttackPower);
                    Console.WriteLine("防御力" + Player.DefencePower);
                    Console.WriteLine("最大魔法攻撃力" + Player.MaGicAttack);

                    //プレイヤーの行動入力
                    Console.WriteLine("Enterでターン進行");
                    Console.ReadLine();

                    //プレイヤーと殴り合う
                    battleIsEnd = battle.AdvanceTurn();
                }
                if (!Player.IsAlive)
                {
                   
                    //Console.WriteLine("いるまがエリクシールを使って蘇った!");
                    Console.ReadLine();
                    //Console.WriteLine("ゲームオーバー");
                    break;
                }
                if (!Enemy.IsAlive)
                {
                    Console.WriteLine(Enemy.Name + "がやられた");


                }
                Console.WriteLine();
            }
            
            Console.WriteLine(".........立てないっス");
            Console.ReadLine();
        }
    }
}