using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class06 {
	class EnemyMaster {
		public List<EnemyParameter> Parameters;

	}
	class EnemyParameter {
		public string Name = "NULL";
		public string ResultLog = "NULL";
		public int MaxHP = 0;

		public int AttackPower = 0;
		public int DefencePower = 0;

		public int GainExp = 0;
	}

}
