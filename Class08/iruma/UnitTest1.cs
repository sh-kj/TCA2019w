using NUnit.Framework;

namespace Tests
{
    public class Tests
    {

        private Class08.DamageCalculator damageCalculator;

        [SetUp]
        public void Setup()
        {
            damageCalculator=new Class08.DamageCalculator();
        }

        [Test]
        public void Test1()
        {
            for (int i = 0; i < 100000; i++)
            {
                 int damage=damageCalculator.Calculate(10,5);
                            Assert.That(damage,Is.LessThan(100));
            }
           
        }

        [Test]
        public void Test2()
        {
            for (int i = 0; i < 100000; i++)
            {
                int damage=damageCalculator.Calculate(1,10);

                            Assert.That(damage,Is.GreaterThan(0));
            }
            
        }
    }
}