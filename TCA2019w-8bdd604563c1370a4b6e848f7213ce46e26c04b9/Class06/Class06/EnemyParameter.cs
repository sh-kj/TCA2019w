using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Class06 {
	class EnemyMaster{
		public List<EnemyParameter>
			Parameters;
	}
	class EnemyParameter {
		public string Name;
		public int MaxHP;

		public int AttackPower;
		public int DefencePower;

		public int GainEXP;
	}
    class Enemy:Character//敵のクラス
    {
        public int GainExp
        { get; private set; }

        public Enemy(string name, int maxHP,int attackPower,int defencePower)
        {
            this.Name = name;
            this.MaxHP = maxHP;
            this.HP = maxHP;
            this.AttackPower = attackPower;
            this.DefencePower = defencePower;
            this.GainExp = GainExp;
        }
        public Enemy(EnemyParameter parameter )
        {
            this.Name = parameter.Name;
            this.MaxHP = parameter.MaxHP;
            this.HP = this.MaxHP;
            this.AttackPower = parameter.AttackPower;
            this.DefencePower = parameter.DefencePower;
            this.GainExp = parameter.GainEXP;
        }

    }

}
