using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class06
{
	abstract class Character//クラス作成、C++でいう初期化
	{
		public string Name//名前
		{ get; protected set; }

		public int MaxHP//最大ＨＰ
		{ get; protected set; }

		public int HP//ＨＰ
		{ get; protected set; }

		public int AttackPower//攻撃力
		{ get; protected set; }

		public int DefencePower//防御力
		{ get; protected set; }


		public bool IsAlive//生死判定
		{ get { return HP > 0; } }


		public int Attack(Character target)//ダメージ
		{
			int damage = DamageCalculator.CalcDamage(this, target);//ダメージ計算をダメージ計算クラスから参照

			target.HP -= damage;
			return damage;
		}
	}


	class Enemy : Character//キャラ（敵と主人公共通）
	{
		public int GainExp//経験値
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
		public Enemy(EnemyParameter parameter){
			this.Name = parameter.Name;
			this.MaxHP = parameter.MaxHP;
			this.HP = this.MaxHP;
			this.AttackPower = parameter.AttackPower;
			this.DefencePower = parameter.DefencePower;
			this.GainExp = parameter.GainEXP;
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

		//全回復(宿屋)
		public void RecoverAll()
		{
			this.HP = MaxHP;
		}
	}

	//ダメージ計算用クラス
	static class DamageCalculator
	{
		public static Random RanbomProvider= new Random(DateTime.Now.Millisecond);

		public static int CalcDamage(Character attacker, Character target)
		{
			//最低ＤＡＭＡＧＥ＝(勇者の攻撃力-敵の守備力+2)/4
			//最高ＤＡＭＡＧＥ＝(勇者の攻撃力-敵の守備力+2)/2
			int minimumDamage=(attacker.AttackPower-target.DefencePower/2)/4;
			int maxmumDamage=(attacker.AttackPower-target.DefencePower/2)/2;

			if(minimumDamage<1)
				minimumDamage=1;
			if(maxmumDamage<1)
				maxmumDamage=1;

			int damage=RanbomProvider.Next(minimumDamage,
				maxmumDamage);


			return damage;
		}
	}

}
