using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class06 {
	class PlayerMaster {
		public List< PlayerParameter > Parameters;

		public PlayerParameter GetParameterByLevel(int level)
		{
			for ( int i = 0;i < Parameters.Count;i++ ) {
				if(Parameters[i].Level == level)
					{
					return Parameters[i];
				}
			}
			return null;
		}
	}
	class PlayerParameter {
		public int MaxHP;

		public int Level;
		public int NextLevelExp;

		public int AttackPower;
		public int DefencePower;

	}
}
