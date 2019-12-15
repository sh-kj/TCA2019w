using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class08
{
	class Program
	{
		static void Main(string[] args)
		{
			HandsOn01();

			Console.ReadLine();
		}


		private static void HandsOn01()
		{
			int damage = DamageCalculator.Calculate(10, 5);

			Console.WriteLine(damage);
		}
	}



	public class DamageCalculator
	{
		public static int Calculate(int AttackPoint, int DefencePoint)
		{
			return AttackPoint - DefencePoint;
		}
	}
}
