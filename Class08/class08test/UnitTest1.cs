using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace class08test {
	[TestClass]
	public class UnitTest1 {
		[TestMethod]
		public void TestMethod1( ) {

			Class08.DamageCalculator damageCalc = new Class08.DamageCalculator( );
			int damage = damageCalc.Calculate( 10, 5 );

			Assert.AreEqual( 5, damage );

			damage = damageCalc.Calculate( 5, 100 );
			Assert.IsTrue( damage > 0 );

		}
		[TestMethod]
		public void CheckNotMinus( ) {
			Class08.DamageCalculator damageCalc = new Class08.DamageCalculator( );

			int damage = damageCalc.Calculate( 5, 100 );
			Assert.IsTrue( damage > 0 );
		}
		[TestMethod]
		public void CheckRandomDamage( ) {
			Class08.DamageCalculator damageCalc = new Class08.DamageCalculator( );

			int damage = damageCalc.CalculateRandom( 10, 14 );
			for( int i = 0; i < 10000; i++ ) {
				Assert.IsTrue( damage > 0 );
			}
			
		}
	}
}
