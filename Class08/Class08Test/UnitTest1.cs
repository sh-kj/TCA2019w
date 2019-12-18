using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Class08Test {
	[TestClass]
	public class UnitTest1 {
		[TestMethod]
		public void TestMethod01( ) {
			Class08.DamageCalculator damageCalc = new Class08.DamageCalculator( );

			int damege = damageCalc.Calculate( 10, 5 );
			Assert.AreEqual( 5, damege );


		}

		[TestMethod]
		public void TestMethod02( ) {
			Class08.DamageCalculator damageCalc = new Class08.DamageCalculator( );

			int damege = damageCalc.Calculate( 5, 100 );
			Assert.IsTrue( damege > 0 );
		}
		[TestMethod]
		public void CheckRandomDamage( ) {
			Class08.DamageCalculator damageCalc = new Class08.DamageCalculator( );

			int damege = damageCalc.CalculateRandom( 10, 15 );
			
			for ( int i = 0;i < 10000;i++ ) {
				Assert.IsTrue( damege > 0 );
			}
		}
	}
}
