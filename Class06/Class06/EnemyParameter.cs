using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class06
{
	class EnemyMaster
	{
		public List<EnemyParameter> Parameters;
	}
	class EnemyParameter
	{
		public string Name;
		public int MaxHP;

		public int AttackPower;
		public int DefencePower;

		public int GainExp;
	}
}
