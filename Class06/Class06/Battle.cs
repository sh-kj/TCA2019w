using System;

namespace Class06
{
    
    class Battle
    {
        private Player battlePlayer;
        private Enemy battleEnemy;

        public Battle(Player player, Enemy enemy)
        {
            battlePlayer = player;
            battleEnemy = enemy;
        }
        public bool AdvanceTurn()
        {
            //プレイヤーが敵を攻撃
            int damege = battlePlayer.Attack(battleEnemy);
            Console.WriteLine(battlePlayer.Name + "の攻撃!" +battleEnemy.Name + "に" + damege + "のダメージ!");

           
            int down = battlePlayer.MaGic(battleEnemy);
            Console.WriteLine(battlePlayer.Name+"の魔法攻撃!"+battleEnemy.Name+"に"+ down + "のダメージ！\n");

            //敵が生きているかどうか
            if (!battleEnemy.IsAlive)
            {
                Console.WriteLine(battleEnemy.Name + "を倒した！");
               
                return true;
            }

            //敵がプレイヤーを攻撃
            damege = battleEnemy.Attack(battlePlayer);
            Console.WriteLine(battleEnemy.Name + "の攻撃!" +
            battlePlayer.Name + "に" + damege + "のダメージ!\n");

            //プレイヤーが生きているかどうか
            if (!battlePlayer.IsAlive)
            {
                
                Console.WriteLine(battlePlayer.Name + "は倒れた..");
                //Console.WriteLine(battlePlayer.MaxHP + "回復!");
                return true;
            }
            return false;
        }
    }
}