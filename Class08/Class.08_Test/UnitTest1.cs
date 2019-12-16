using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private Class08.DamageCalculator damegecalculater;
        [SetUp]
        public void Setup()
        {
            damegecalculater = new Class08.DamageCalculator();
           // Class08.DamageCalculator damegecalculater=new Class08.DamageCalculator();
        }

        [Test]
        public void Test1()
        {

            //シンプルなテストコード

            for (int i = 0;i < 10000;i++)
            {


                int damege = damegecalculater.Calculate(10, 5);

                Assert.That(damege, Is.LessThan(100));
            }
            //Assert.Pass();
        }

     


    }
}