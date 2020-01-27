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
        public Random RandomProvider=new Random(DateTime.Now.Millisecond);
		public int Calculate(int AttackPoint, int DefencePoint)
		{
            int minimumDamage=(AttackPoint-DefencePoint/2)/4;
            int maximumDamage=(AttackPoint-DefencePoint/2)/2;
            
            if(minimumDamage<1)
            {
                minimumDamage=1;
            }
            
            if(maximumDamage<1)
            {
                maximumDamage=1;
            }

            int damage=RandomProvider.Next(minimumDamage,maximumDamage);
                return damage;
		}

		private Random RandomProvider = new Random(DateTime.Now.Millisecond);

		public int CalculateRandom(int AttackPoint, int DefencePoint)
		{
			//最低ダメージ＝（攻撃力 - 敵の守備力÷2）÷4
			//最高ダメージ＝（攻撃力 - 敵の守備力÷2）÷2
			int minimumDamage = (AttackPoint - DefencePoint / 2) / 4;
			int maximumDamage = (AttackPoint - DefencePoint / 2) / 2;

			int damage = RandomProvider.Next(minimumDamage, maximumDamage);

			return damage;
		}
	}
}
