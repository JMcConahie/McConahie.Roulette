using McConahie.Roulette;
using McConahie.Roulette.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace McConahieRouletteTests.UnitTests
{
    [TestFixture]
    [Category("Unit")]
    public class ResultClassifierUnitTests
    {
        [Test]
        public void ClassifyResults_IsTopColumn()
        {
            ResultClassifier classifier = new ResultClassifier();

            var expected = new Classification()
            {
                Name = "TOP_COLUMN",
                PayoutMultiplier = 3
            };

            List<Classification> actual = classifier.ClassifyResult(3);

            Assert.IsTrue(actual.Contains(expected));

            actual = classifier.ClassifyResult(18);

            Assert.IsTrue(actual.Contains(expected));

            actual = classifier.ClassifyResult(0);

            Assert.IsFalse(actual.Contains(expected));

            actual = classifier.ClassifyResult(37);

            Assert.IsFalse(actual.Contains(expected));
        }

        [Test]
        public void ClassifyResults_IsMiddleColumn()
        {
            ResultClassifier classifier = new ResultClassifier();

            var expected = new Classification()
            {
                Name = "MIDDLE_COLUMN",
                PayoutMultiplier = 3
            };

            List<Classification> actual = classifier.ClassifyResult(8);

            Assert.IsTrue(actual.Contains(expected));

            actual = classifier.ClassifyResult(35);

            Assert.IsTrue(actual.Contains(expected));
        }

        [Test]
        public void ClassifyResults_IsBottomColumn()
        {
            ResultClassifier classifier = new ResultClassifier();

            var expected = new Classification()
            {
                Name = "BOTTOM_COLUMN",
                PayoutMultiplier = 3
            };

            List<Classification> actual = classifier.ClassifyResult(16);

            Assert.IsTrue(actual.Contains(expected));

            actual = classifier.ClassifyResult(34);

            Assert.IsTrue(actual.Contains(expected));
        }

        [Test]
        public void ClassifyResults_IsRed()
        {
            ResultClassifier classifier = new ResultClassifier();

            var expected = new Classification()
            {
                Name = "RED",
                PayoutMultiplier = 2
            };

            List<Classification> actual = classifier.ClassifyResult(16);

            Assert.IsTrue(actual.Contains(expected));

            actual = classifier.ClassifyResult(34);

            Assert.IsTrue(actual.Contains(expected));
        }

        [Test]
        public void ClassifyResults_IsBlack()
        {
            ResultClassifier classifier = new ResultClassifier();

            var expected = new Classification()
            {
                Name = "BLACK",
                PayoutMultiplier = 2
            };

            List<Classification> actual = classifier.ClassifyResult(11);

            Assert.IsTrue(actual.Contains(expected));

            actual = classifier.ClassifyResult(33);

            Assert.IsTrue(actual.Contains(expected));
        }

        [Test]
        public void ClassifyResults_IsFirstDozen()
        {
            ResultClassifier classifier = new ResultClassifier();

            var expected = new Classification()
            {
                Name = "FIRST_DOZEN",
                PayoutMultiplier = 3
            };

            List<Classification> actual = classifier.ClassifyResult(11);

            Assert.IsTrue(actual.Contains(expected));

            actual = classifier.ClassifyResult(1);

            Assert.IsTrue(actual.Contains(expected));

            actual = classifier.ClassifyResult(37);

            Assert.IsFalse(actual.Contains(expected));

            actual = classifier.ClassifyResult(0);

            Assert.IsFalse(actual.Contains(expected));
        }

        [Test]
        public void ClassifyResults_IsSecondDozen()
        {
            ResultClassifier classifier = new ResultClassifier();

            var expected = new Classification()
            {
                Name = "SECOND_DOZEN",
                PayoutMultiplier = 3
            };

            List<Classification> actual = classifier.ClassifyResult(13);

            Assert.IsTrue(actual.Contains(expected));

            actual = classifier.ClassifyResult(24);

            Assert.IsTrue(actual.Contains(expected));

            actual = classifier.ClassifyResult(11);

            Assert.IsFalse(actual.Contains(expected));

            actual = classifier.ClassifyResult(36);

            Assert.IsFalse(actual.Contains(expected));
        }

        [Test]
        public void ClassifyResults_IsThirdDozen()
        {
            ResultClassifier classifier = new ResultClassifier();

            var expected = new Classification()
            {
                Name = "THIRD_DOZEN",
                PayoutMultiplier = 3
            }; 

            List<Classification> actual = classifier.ClassifyResult(30);

            Assert.IsTrue(actual.Contains(expected));

            actual = classifier.ClassifyResult(35);

            Assert.IsTrue(actual.Contains(expected));

            actual = classifier.ClassifyResult(0);

            Assert.IsFalse(actual.Contains(expected));

            actual = classifier.ClassifyResult(24);

            Assert.IsFalse(actual.Contains(expected));
        }

        [Test]
        public void ClassifyResults_IsSplit14_17()
        {
            ResultClassifier classifier = new ResultClassifier();

            var expected = new Classification()
            {
                Name = "SPLIT_14_17",
                PayoutMultiplier = 18
            };

            List<Classification> actual = classifier.ClassifyResult(14);

            Assert.IsTrue(actual.Contains(expected));

            actual = classifier.ClassifyResult(17);

            Assert.IsTrue(actual.Contains(expected));
        }

        [Test]
        public void ClassifyResults_IsSplit1_4()
        {
            ResultClassifier classifier = new ResultClassifier();

            var expected = new Classification()
            {
                Name = "SPLIT_1_4",
                PayoutMultiplier = 18
            };

            List<Classification> actual = classifier.ClassifyResult(1);

            Assert.IsTrue(actual.Contains(expected));

            actual = classifier.ClassifyResult(4);

            Assert.IsTrue(actual.Contains(expected));
        }

        [Test]
        public void ClassifyResults_IsSplit33_36()
        {
            ResultClassifier classifier = new ResultClassifier();

            var expected = new Classification()
            {
                Name = "SPLIT_33_36",
                PayoutMultiplier = 18
            };

            List<Classification> actual = classifier.ClassifyResult(33);

            Assert.IsTrue(actual.Contains(expected));

            actual = classifier.ClassifyResult(36);

            Assert.IsTrue(actual.Contains(expected));
        }

        [Test]
        public void ClassifyResults_IsSplit00_0()
        {
            ResultClassifier classifier = new ResultClassifier();

            var expected = new Classification()
            {
                Name = "SPLIT_00_0",
                PayoutMultiplier = 18
            };

            List<Classification> actual = classifier.ClassifyResult(0);

            Assert.IsTrue(actual.Contains(expected));

            actual = classifier.ClassifyResult(37);

            Assert.IsTrue(actual.Contains(expected));
        }

        [Test]
        public void ClassifyResults_00_NoNullsReturned()
        {
            ResultClassifier classifier = new ResultClassifier();

            List<Classification> classifications = classifier.ClassifyResult(37);

            foreach(var classification in classifications)
            {
                Assert.IsNotNull(classification);
            }
        }

        [Test]
        public void ClassifyResults_20_AllSplitsReturned()
        {
            ResultClassifier classifier = new ResultClassifier();

            var expectedResults = new List<Classification>()
            {
                new Classification()
                {
                    Name = "20",
                    PayoutMultiplier = 36
                },
                new Classification()
                {
                    Name = "SPLIT_21_20",
                    PayoutMultiplier = 18
                },
                new Classification()
                {
                    Name = "SPLIT_17_20",
                    PayoutMultiplier = 18
                },
                new Classification()
                {
                    Name = "SPLIT_20_23",
                    PayoutMultiplier = 18
                },
                new Classification()
                {
                    Name = "SPLIT_20_19",
                    PayoutMultiplier = 18
                },
                new Classification()
                {
                    Name = "MIDDLE_COLUMN",
                    PayoutMultiplier = 3
                },
                new Classification()
                {
                    Name = "STREET_19",
                    PayoutMultiplier = 12
                },
                new Classification()
                {
                    Name = "DOUBLE_STREET_16_19",
                    PayoutMultiplier = 6
                },
                new Classification()
                {
                    Name = "DOUBLE_STREET_19_22",
                    PayoutMultiplier = 6
                },
                new Classification()
                {
                    Name = "BLACK",
                    PayoutMultiplier = 2
                },
                new Classification()
                {
                    Name = "SECOND_DOZEN",
                    PayoutMultiplier = 3
                },
                new Classification()
                {
                    Name = "HIGH",
                    PayoutMultiplier = 2
                },
                new Classification()
                {
                    Name = "EVEN",
                    PayoutMultiplier = 2
                },
                new Classification()
                {
                    Name = "CORNER_18_21_17_20",
                    PayoutMultiplier = 9
                },
                new Classification()
                {
                    Name = "CORNER_17_20_16_19",
                    PayoutMultiplier = 9
                },
                new Classification()
                {
                    Name = "CORNER_21_24_20_23",
                    PayoutMultiplier = 9
                },
                new Classification()
                {
                    Name = "CORNER_20_23_19_22",
                    PayoutMultiplier = 9
                }
            };

            List<Classification> actual = classifier.ClassifyResult(20);

            foreach(Classification expectedResult in expectedResults)
            {
                Assert.IsTrue(actual.Contains(expectedResult), $"Expected result {expectedResult.Name} not found in actual results");
            }
            
            Assert.AreEqual(expectedResults.Count, actual.Count);
        }

        [Test]
        public void ClassifyResults_IsSplit28_AllSplitsReturned()
        {
            ResultClassifier classifier = new ResultClassifier();

            var expected1 = new Classification()
            {
                Name = "SPLIT_29_28",
                PayoutMultiplier = 18
            };

            var expected2 = new Classification()
            {
                Name = "SPLIT_25_28",
                PayoutMultiplier = 18
            };

            var expected3 = new Classification()
            {
                Name = "SPLIT_28_31",
                PayoutMultiplier = 18
            };

            List<Classification> actual = classifier.ClassifyResult(28);

            Assert.IsTrue(actual.Contains(expected1));
            Assert.IsTrue(actual.Contains(expected2));
            Assert.IsTrue(actual.Contains(expected3));
        }

        [Test]
        public void ClassifyResults_IsSplit36_AllSplitsReturned()
        {
            ResultClassifier classifier = new ResultClassifier();

            var expected1 = new Classification()
            {
                Name = "SPLIT_33_36",
                PayoutMultiplier = 18
            };

            var expected2 = new Classification()
            {
                Name = "SPLIT_36_35",
                PayoutMultiplier = 18
            };

            List<Classification> actual = classifier.ClassifyResult(36);

            Assert.IsTrue(actual.Contains(expected1));
            Assert.IsTrue(actual.Contains(expected2));
        }
    }
}
