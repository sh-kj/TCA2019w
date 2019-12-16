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

            //DamageCalculator RandomProvider = new DamageCalculator();
			Console.WriteLine(damage);
		}
	}



    public class DamageCalculator
    {
        public int Calculate(int AttackPoint, int DefencePoint)
        {
            int damage = AttackPoint - DefencePoint;
            //最低保証1
            if (damage < 1) damage = 1;

            return damage;
        }




        public class DamageCalculater {

           
             public Random RandomProvider=new Random(DateTime. Now.Millisecond);



            public int Calculater(int AttackPoint, int DefencePoint)
            {


                int minimumDamage = (AttackPoint - DefencePoint / 2) / 4;
                int maxnimumDamage = (AttackPoint - DefencePoint / 2) / 2;

                if (minimumDamage < 1) minimumDamage = 1;
                if (maxnimumDamage < 1) maxnimumDamage = 1;

                int damage = RandomProvider.Next(minimumDamage, maxnimumDamage);

                return damage;
            }
        }
    }

    
    
}
