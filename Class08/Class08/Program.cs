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
		public int Calculate(int AttackPoint, int DefencePoint)
		{
			int damage = AttackPoint - DefencePoint;
				if ( damage < 1 ) damage = 1;
			return damage;
		}
	}
	public class DamageCaluculater 
	{
		public Random RandomProvider = new Random( DateTime.Now.Millisecond );

		public int Calculate(int Attackpoint, int DefancePoint) 
		{

			//最低ダメージ＝攻撃-守備力÷2 ÷4

			int minimumDamage = ( Attackpoint - DefancePoint / 2 ) / 4;
			int maximumDamage = ( Attackpoint - DefancePoint / 2 ) / 2;

			if ( minimumDamage < 1 )
				minimumDamage = 1;
			if ( maximumDamage < 1 )
				maximumDamage = 1;

			int damage = RandomProvider.Next( minimumDamage, maximumDamage );

			return damage;

		}

	}
}
