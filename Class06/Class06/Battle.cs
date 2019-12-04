using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class06
{
    class Battle
    {
        public Player BattlePlayer
        { get; private set;  }

        public Enemy BattleEnemy
        { get; private set; }

        public Battle(Player player, Enemy enamy)
        {
            BattlePlayer = player;
            BattleEnemy = enamy;
        }
        public bool AdvanceTurn(/*コマンド内容*/)
        {
            int damage = BattlePlayer.Attack(BattleEnemy);

            Console.WriteLine(BattlePlayer.Name + "の攻撃!" + BattleEnemy.Name + "に" + damage + "のダメージ!");

            if (!BattleEnemy.IsAlive)//敵の生存チェック
            {
                Console.WriteLine(BattlePlayer.Name + "は倒れた");
                return true;
            }


            damage = BattleEnemy.Attack(BattlePlayer);
            Console.WriteLine(BattleEnemy.Name + "に" + damage + "のダメージ!");
            //プレイヤーの生存チェック
            if(!BattlePlayer.IsAlive)
            {
                Console.WriteLine(BattlePlayer.Name + "は倒れた");
                return true;
            }


 
            return false;
        }

      

    }
}
