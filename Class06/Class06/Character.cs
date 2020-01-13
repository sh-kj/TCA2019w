using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class06
{
	abstract class Character
	{
		public string Name
		{ get; protected set; }

		public int MaxHP
		{ get; protected set; }

		public int HP
		{ get; protected set; }

		public int AttackPower
		{ get; protected set; }

		public int DefencePower
		{ get; protected set; }


        public int CurrentExp
        {
            get;protected set;
        }

        public int CurrentLevel
        {
            get;protected set;
        }

        public int ExpGained
        {
            get;protected set;
        }

		public bool IsAlive
		{ get { return HP > 0; } }


		public int Attack(Character target)
		{
			int damage = DamageCalculator.CalcDamage(this, target);

			target.HP -= damage;
			return damage;
		}

        public void LevelUP(Character target) 
        {
            if (!target.IsAlive)
            {
                int currentExp=0;
                int levelUp=0;
                LevelUpCalculator.LevelUp(this, target,ref currentExp,ref levelUp);
                this.CurrentExp = currentExp;
                this.CurrentLevel = levelUp;
                this.HP = MaxHP;
            }
        }
	}


	class Enemy : Character
	{
		public int GainExp
		{ get; private set; }

		//敵はコンストラクタで全初期パラメータを決める
		public Enemy(string name, int maxHP, int attackPower, int defencePower, int gainExp)
		{
			this.Name = name;
			this.MaxHP = maxHP;
			this.HP = maxHP;
			this.AttackPower = attackPower;
			this.DefencePower = defencePower;
			this.GainExp = gainExp;
		}
	public Enemy(EnemyParameter parameter ) {
		this.Name = parameter.Name;
			this.MaxHP = parameter.MaxHP;
			this.HP = this.MaxHP;
			this.AttackPower = parameter.AttackPower;
			this.DefencePower = parameter.DefencePower;
			this.GainExp = parameter.GainExp;
            this.ExpGained = parameter.GainExp;
	}
	}
	class Player : Character
	{
		public int Level
		{ get; private set; }

		public int Exp
		{ get; private set; }


		public Player(string name, int level, int exp, int maxHP, int attackPower, int defencePower)
		{
			this.Name = name;
			this.Level = level;
            this.Exp = exp;
            this.CurrentLevel = level;
			SetParameter(maxHP, attackPower, defencePower,exp);
			RecoverAll();
		}

		//プレイヤーのパラメータはレベルアップによる変化を考慮して再度セットできるようにしておく
		public void SetParameter(int maxHP, int attackPower, int defencePower,int exp)
		{
			this.MaxHP = maxHP;
			this.AttackPower = attackPower;
			this.DefencePower = defencePower;
            this.CurrentExp = exp;
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
		public static Random RandomCalculator = new Random(DateTime.Now.Millisecond);

		public static int CalcDamage(Character attacker, Character target)
		{
			int minDamage = (attacker.AttackPower - target.DefencePower / 2) / 4;
			int maxDamage = (attacker.AttackPower - target.DefencePower / 2) / 2;

			if (minDamage < 1)
			{
				minDamage = 1;
			}
			if (maxDamage < 1)
			{
				maxDamage = 1;
			}

			int damage = RandomCalculator.Next(minDamage, maxDamage);

			return damage;

			//return attacker.AttackPower - target.DefencePower;
		}
	}

    static class LevelUpCalculator
    {
        public static void LevelUp( Character attacker,Character target,ref int currentExp,ref int levelUp)
        {
            int expUp = attacker.CurrentExp + target.ExpGained;
            //次のLevelUpExp=50*1.2^curentlevelはInt化
            int levelUpExp = Convert.ToInt32(50 * Math.Pow(1.2 ,attacker.CurrentLevel));

            if (expUp > levelUpExp)
            {
                currentExp = expUp - levelUpExp;
                levelUp = attacker.CurrentLevel+1;
            }
            else
            {
                currentExp = expUp;
                levelUp = attacker.CurrentLevel;
            }
        }
    }
}
