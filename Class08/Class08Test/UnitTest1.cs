using NUnit.Framework;

namespace Tests {
	public class Tests 
	{
		private Class08.DamageCalculator damagecalculator;

		[SetUp]
		public void Setup( ) 
		{
			damagecalculator = new Class08.DamageCalculator();
		}

		[Test]
		public void Test1( ) {
			for (int i=0;i<10000;i++ )
			{
			int damage = damagecalculator.Calculate( 10,5 );
			Assert.That(damage,Is.LessThan(100) );

			}
		}
		public void Test2( ) 
		{
			for(int i=0;i<1000;i++ )
			{

			int damage = damagecalculator.Calculate( 1, 10 );
			Assert.That( damage, Is.GreaterThan( 0 ) );


			}

		}
	}
}