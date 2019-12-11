using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class06 {
	class HeroesMaster {
		public IList<HeroesParameter> Parameters;
	}
	class HeroesParameter {
		public string Name;
		public int MAXHP;
		public int AttackPower;
		public int DefencePower;
		public int Level;
		public int Exp;
	}
	class EnemyMaster
	{
		public IList<EnemyParameter>Parameters;
	}
	class EnemyParameter 
	{
		public string Name;
		public int MAXHP;
		public int AttackPower;
		public int DefencePower;
		public int GainExp;
	}
}
