using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine(battlePlayer.Name + "の攻撃" +
            battleEnemy.Name + "に" + damege + "のダメージ!");
            //敵が生きているかどうか
            if (!battleEnemy.IsAlive)
            {
                Console.WriteLine(battleEnemy.Name + "を倒した！");
                return true;
            }

            //敵がプレイヤーを攻撃
            damege = battleEnemy.Attack(battlePlayer);
            Console.WriteLine(battleEnemy.Name + "の攻撃" +
            battlePlayer.Name + "に" + damege + "のダメージ!");
            //プレイヤーが生きているかどうか
            if (!battlePlayer.IsAlive)
            {
                Console.WriteLine(battlePlayer.Name + "は倒れた..");
                return true;
            }
            return false;
        }
    }
}