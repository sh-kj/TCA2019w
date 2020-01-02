using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class06
{
    abstract class Character
    {
        public string Name { get; protected set; }

        public int MaxHP { get; protected set; }

        public int HP { get; protected set; }

        public int AttackPower { get; protected set; }

        public int DefencePower { get; protected set; }

        public int MP { get; protected set; }

        public int MaGicAttack { get; protected set; }


        public bool IsAlive { get { return HP > 0; } }


        public int Attack(Character target)
        {
            int damage = DamageCalculator.CalcDamage(this, target);

            target.HP -= damage;
            return damage;
        }

        public int MaGic(Character sent)
        {
            int down = DamegeMagic.MagicDamege(this, sent);

            sent.HP -= down;
            return down;
        }

        public int MaGicPoint(Character point)
        {
            point.MP -= 10;
            return 0;
        }
    }


    class Enemy : Character
    {
        public int GainExp { get; private set; }

        //敵はコンストラクタで全初期パラメータを決める
        public Enemy(string name, int maxHP, int attackPower, int defencePower, int mp,  int gainExp)
        {
            this.Name = name;
            this.MaxHP = maxHP;
            this.HP = maxHP;
            this.AttackPower = attackPower;
            this.DefencePower = defencePower;
          
            this.GainExp = gainExp;
        }
        public Enemy(EnemyParameter parameter)
        {
            this.Name = parameter.Name;
            this.MaxHP = parameter.MaxHP;
            this.HP = parameter.MaxHP;
            this.AttackPower = parameter.AttackPower;
            this.DefencePower = parameter.DefencePower;
            

            this.GainExp = parameter.GainExp;
        }
    }
    class Player : Character
    {
        public int Level { get; private set; }

        public int Exp { get; private set; }

        public Player(string name, int level, int exp, int maxHP, int attackPower, int defencePower, int MaGicAttack, int maxmp)
        {
            this.Name = name;
            this.Level = level;
            this.Exp = exp;

            SetParameter(maxHP, attackPower, defencePower, MaGicAttack, maxmp);
            RecoverAll();
        }

        //プレイヤーのパラメータはレベルアップによる変化を考慮して再度セットできるようにしておく
        public void SetParameter(int maxHP, int attackPower, int defencePower, int maGicAttack, int maxmp)
        {
            this.MaxHP = maxHP;
            this.AttackPower = attackPower;
            this.DefencePower = defencePower;
            this.MaGicAttack = maGicAttack;
            this.MP = maxmp;
        }

        //全回復(宿屋)
        public void RecoverAll()
        {
            this.HP = MaxHP;
        }
    }

    //ダメージ計算用クラス
    static class DamageCalculator
    {
        public static Random RandomProvider = new Random(DateTime.Now.Millisecond);
        public static int CalcDamage(Character attacker, Character target)
        {
            //最低ダメージ＝（勇者の攻撃力 - 敵の守備力÷2）÷4
            //最高ダメージ＝（勇者の攻撃力 - 敵の守備力÷2）÷2
            int minmumDamege = (attacker.AttackPower - target.DefencePower / 2) / 4;
            int maximumDamage = (attacker.AttackPower - target.DefencePower / 2) / 2;

            if (minmumDamege < 1)
            {
                minmumDamege = 1;
            }
            if (maximumDamage < 12)
            {
                maximumDamage = 6;
            }

            int damege = RandomProvider.Next(minmumDamege, maximumDamage);

            return damege;
        }
    }
    
    static class DamegeMagic
    {
        private static Random randomMagic = new Random(DateTime.Now.Millisecond);

        public static Random RandomMagic { get => randomMagic; set => randomMagic = value; }

        public static int MagicDamege(Character attackermagic,Character target)
        {
            int miniMagicDamege = (attackermagic.MaGicAttack - target.DefencePower/2)/2;
            int maxMagicDamege = (attackermagic.MaGicAttack - target.DefencePower/1)/2 ;

            if (miniMagicDamege<2)
            {
                miniMagicDamege = 2;
            }
            if (maxMagicDamege<20)
            {
                maxMagicDamege = 18;
            }
            int down = RandomMagic.Next(miniMagicDamege, maxMagicDamege);

            return down;
               
        }

        
    }

}