using McConahie.Roulette;
using NUnit.Framework;

namespace McConahieRouletteTests.UnitTests
{
    [TestFixture]
    [Category("Unit")]
    public class RandomNumberGeneratorUnitTests
    {
        [Test]
        public void GetRandomNumber_UpperBoundOf38_ResultIsValid10X()
        {
            // Arrange
            var randomNumberGenerator = new RandomNumberGenerator();

            for(int i = 0; i < 10; i++)
            {
                // Act
                int outcome = randomNumberGenerator.GetRandomNumber(38);

                // Assert
                Assert.GreaterOrEqual(outcome, 0);
                Assert.LessOrEqual(outcome, 37);
            }
        }
    }
}
