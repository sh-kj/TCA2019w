using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class06
{
    class Battle
    {
        private Player BattlePlayer;
        private Enemy BattleEnemy;
        
        public Battle(Player player,Enemy enemy)
        {
            BattlePlayer = player;
            BattleEnemy = enemy;
        }

        public bool AdvanceTurn()
        {
            //プレイヤーと敵が殴り合う
            int damage = BattlePlayer.Attack(BattleEnemy);
            Console.WriteLine(BattlePlayer.Name + "の攻撃！" + BattleEnemy.Name + "に" + damage + "のダメージ！");

            if (!BattleEnemy.IsAlive){
                //敵が死亡した
                Console.WriteLine(BattleEnemy.Name + "を倒した！");
                return true;
            }

            //敵がプレイヤーを攻撃
             damage = BattleEnemy.Attack(BattlePlayer);
            Console.WriteLine(BattleEnemy.Name + "の攻撃！" + BattlePlayer.Name + "に" + damage + "のダメージ！");

            if (!BattlePlayer.IsAlive)
            {
                //プレイヤーが死亡した
                Console.WriteLine(BattlePlayer.Name + "は倒れた……");
                return true;
            }
            return false;
        }
    }
}
