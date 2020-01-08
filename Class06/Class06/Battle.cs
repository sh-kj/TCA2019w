﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class06
{
    class Battle
    {
        public Player BattlePlayer 
            { get; private set; }

        public Enemy BattleEnemy 
            { get; private set; }

        public Battle(Player player, Enemy enemy)
        {
            BattlePlayer = player;
            BattleEnemy = enemy;
        }

        public bool AdvanceTurn(/*コマンド内容*/)
        {
            //プレイヤーから敵への攻撃
            int damage = BattlePlayer.Attack(BattleEnemy);
            Console.WriteLine(BattlePlayer.Name + "の攻撃" + BattleEnemy.Name + "に" + damage + "のダメージ！");

            //敵の生存チェック
            if (!BattleEnemy.IsAlive)
            {
                //敵が死んだ場合
                Console.WriteLine(BattleEnemy.Name + "を倒した！！" + "\n" + BattleEnemy.Name + "から経験値を得た:" + BattleEnemy.GainExp);
                return true;
            }
           
            //敵からプレイヤーへの攻撃
            damage = BattleEnemy.Attack(BattlePlayer);
            Console.WriteLine(BattleEnemy.Name + "の攻撃！" + BattlePlayer.Name + "に" + damage + "のダメージ！");

            //プレイヤーの生存チェック
            if(!BattlePlayer.IsAlive)
            {
                Console.WriteLine(BattlePlayer.Name + "は倒れた...");
                return true;
            }

            return false;
        }

    }
}
