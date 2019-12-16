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
			DamageCalculator calculator = new DamageCalculator();
			int damage = calculator.Calculate(10, 5);

			Console.WriteLine(damage);
		}
	}



	public class DamageCalculator
	{
		public Random RandomProvider = new Random(DateTime.Now.Millisecond);

		public int Calculate(int AttackPoint, int DefencePoint)
		{ 
			int minDamage = (AttackPoint - DefencePoint / 2) / 4;
			int maxDamage = (AttackPoint - DefencePoint / 2) / 2;

			if (minDamage < 1) minDamage = 1;
			if (maxDamage < 1) maxDamage = 1;

			int damage = RandomProvider.Next(minDamage, maxDamage);

			return damage;

			
		}
	}

}
