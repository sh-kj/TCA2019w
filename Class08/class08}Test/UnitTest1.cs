using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace class08Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Class08.DamageCalculator damageCalc = new Class08.DamageCalculator();

            int damage = damageCalc.Calculate(10, 5);

            Assert.AreEqual(5, damage);
        }

        [TestMethod]
        public void Test2()
        {
            Class08.DamageCalculator damageCalc = new Class08.DamageCalculator();

            int damage = damageCalc.Calculate(5, 100);
            Assert.IsTrue(damage > 0);
        }

        [TestMethod]
        public void CheckRandomDamage()
        {
            Class08.DamageCalculator damageCalc = new Class08.DamageCalculator();

            int damage = damageCalc.CalculateRandom(10, 14);
            //ramdom‚Ìs‰ñ”‚ğ‚â‚é
            for(int i = 0; i < 10000; i++)
            {
                Assert.IsTrue(damage > 0);
            }
        }
    }
}
