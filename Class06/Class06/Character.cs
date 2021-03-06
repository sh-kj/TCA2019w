﻿using System;
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

		public static int CalcDamage(Character attacker, Character target)
		{
			return attacker.AttackPower - target.DefencePower;
		}
	}

}
