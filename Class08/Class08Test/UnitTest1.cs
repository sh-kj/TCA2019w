using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Class08Test 
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1( )
		{
			Class08.DamageCalculator damageCalc = new Class08.DamageCalculator( );

			int damage = damageCalc.Calculate( 10, 5 );
			Assert.AreEqual( 5, damage );
		}

		[TestMethod]
		public void CheckNotMinus( )
		{
			Class08.DamageCalculator damageClac = new Class08.DamageCalculator( );

			int damage = damageClac.Calculate( 5, 100 );
			Assert.IsTrue( damage > 0 );
		}

		[TestMethod]
		public void CheckRandomDamege( )
		{
			Class08.DamageCalculator damageCalc = new Class08.DamageCalculator( );

			int damage = damageCalc.CalculateRandom( 10, 14 );

			for( int i = 0;i < 100000;i++ )
			{
				Assert.IsTrue( damage > 0 );
			}
		}
	}
}