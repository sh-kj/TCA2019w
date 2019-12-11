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
		public Enemy(EnemyParameter parameter)
		{
			this.Name = parameter.Name;
			this.MaxHP = parameter.MaxHP;
			this.HP = this.MaxHP;
			this.AttackPower = parameter.AttackPower;
			this.DefencePower = parameter.DefencePower;
			this.GainExp = parameter.GainExp;
		}

	}

	class Player : Character
	{
		public int Level
		{ get; private set; }

		public int Exp
		{ get; private set; }

		public int SetExp
		{ get; private set;}

		private int NextExp;

		private PlayerMaster MasterData;

		public Player(string name, int level, int exp, int maxHP, int attackPower, int defencePower, PlayerMaster master)
		{
			this.Name = name;
			this.Level = level;
			this.Exp = exp;
			this.MasterData = master;

			//SetParameter(maxHP, attackPower, defencePower);
			RecoverAll();
		}
		public Player( PlayerParameter parameter, PlayerMaster master ) {
			this.MasterData = master;
			this.Level = parameter.Level;
			this.Exp = 0;
			PlayerParameter newParameter = MasterData.GetParameterByLevel(this.Level);
			SetParameter(newParameter);

			this.HP = this.MaxHP;
		}

		//プレイヤーのパラメータはレベルアップによる変化を考慮して再度セットできるようにしておく
		public void SetParameter(PlayerParameter parameter)
		{
			this.MaxHP = parameter.MaxHP;
			this.AttackPower = parameter.AttackPower;
			this.DefencePower = parameter.DefencePower;
			this.NextExp = parameter.NextLevelExp;

		}

		//全回復(宿屋)
		public void RecoverAll()
		{
			this.HP = MaxHP;
		}

		public void AddExp(int gainExp)
		{
			int exp = NextExp;
			this.Exp += gainExp;
			//レベルアップ判定
			if(this.Exp > exp) 
			{

				Console.WriteLine( this.Name + "はレベルアップした" );
				this.Level += 1;
				Console.WriteLine( this.Name + "のLevel:" + this.Level );
				this.HP = MaxHP;

				PlayerParameter newParameter = MasterData.GetParameterByLevel(this.Level);

				this.SetParameter( newParameter);
				exp += 5;


			}
		}
	}

	//ダメージ計算用クラス
	static class DamageCalculator
	{
		public static Random RandomCalculator = new Random( DateTime.Now.Millisecond );

		public static int CalcDamage(Character attacker, Character target)
		{
			int minDamage = ( attacker.AttackPower - target.DefencePower / 2 ) / 4;
			int maxDamage = ( attacker.AttackPower - target.DefencePower / 2 ) / 2;

			if ( minDamage < 1 )
				minDamage = 1;
			if ( maxDamage < 1 )
				maxDamage = 1;

			int damage = RandomCalculator.Next( minDamage, maxDamage );

			return damage;
			//return attacker.AttackPower - target.DefencePower;
		}
	}

}
