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


		public bool IsAlive
		{ get { return HP > 0; } }


		public int Attack(Character target)
		{
			int damage = DamageCalculator.CalcDamage(this, target);

			target.HP -= damage;
			return damage;
		}
	}


	class Enemy : Character
	{
		public int GainExp
		{ get; private set; }
        public int MoneyGold
        { get; private set; }

		//敵はコンストラクタで全初期パラメータを決める
		public Enemy(string name, int maxHP, int attackPower, int defencePower, int gainExp,int gold)
		{
			this.Name = name;
			this.MaxHP = maxHP;
			this.HP = maxHP;
			this.AttackPower = attackPower;
			this.DefencePower = defencePower;
			this.GainExp = gainExp;
            this.MoneyGold = gold;
		}
		public Enemy(EnemyParameter parameter ) {
			this.Name = parameter.Name;
			this.MaxHP =parameter.MaxHP;
			this.HP = parameter.MaxHP;
			this.AttackPower = parameter.AttackPower;
			this.DefencePower = parameter.DefencePower;
			this.GainExp = parameter.GainExp;
            this.MoneyGold = parameter.MoneyGold;
		}
	}
	class Player : Character
	{
		public int Level
		{ get; private set; }

		public int Exp
		{ get; private set; }
        
        public int Money
        { get; set; }

		public Player(string name, int level, int exp, int maxHP, int attackPower, int defencePower, int MaxMp,int money)
		{
			this.Name = name;
			this.Level = level;
			this.Exp = exp;
            this.Money = money;
           
			SetParameter(maxHP, attackPower, defencePower);
			RecoverAll();
		}

		//プレイヤーのパラメータはレベルアップによる変化を考慮して再度セットできるようにしておく
		public void SetParameter(int maxHP, int attackPower, int defencePower)
		{
			this.MaxHP = maxHP;
			this.AttackPower = attackPower;
			this.DefencePower = defencePower;
		}

		//全回復(宿屋)+(協会)
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

			if ( minmumDamege < 1 ) {
				minmumDamege = 1;
			}
			if ( maximumDamage < 1 ) {
				maximumDamage = 1;
			}

			int damege = RandomProvider.Next(minmumDamege, maximumDamage);

			return damege;
		}
	}

}
