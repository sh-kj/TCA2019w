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
		public string Name;
		public int HP;

		public int attackPower;
		public int DefencePower;

		public int GeinExp;
	}
}
