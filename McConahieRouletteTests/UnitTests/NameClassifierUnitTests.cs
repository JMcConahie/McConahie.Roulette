using McConahie.Roulette;
using McConahie.Roulette.Models;
using NUnit.Framework;

namespace McConahieRouletteTests.UnitTests
{
    [TestFixture]
    [Category("Unit")]
    public class NameClassifierUnitTests
    {
        [Test]
        public void GetClassificationByName_IsThirdDozen()
        {
            var classifier = new NameClassifier();

            var expected = new Classification()
            {
                Name = "THIRD_DOZEN",
                PayoutMultiplier = 3
            };

            Classification actual = classifier.GetClassificationByName("THIRD_DOZEN");

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetClassificationByName_IsBasket()
        {
            var classifier = new NameClassifier();

            var expected = new Classification()
            {
                Name = "BASKET",
                PayoutMultiplier = 7
            };

            Classification actual = classifier.GetClassificationByName("BASKET");

            Assert.AreEqual(expected, actual);
        }
    }
}
