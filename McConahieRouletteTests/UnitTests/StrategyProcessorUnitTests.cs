using McConahie.Roulette;
using McConahie.Roulette.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace McConahieRouletteTests.UnitTests
{
    [TestFixture]
    [Category("Unit")]
    public class StrategyProcessorUnitTests
    {
        public Classification _topColumnClassification = new Classification()
        {
            Name = "TOP_COLUMN",
            PayoutMultiplier = 3
        };

        public Classification _33Classification = new Classification()
        {
            Name = "33",
            PayoutMultiplier = 36
        };

        public RandomNumberGenerator _generator = new RandomNumberGenerator();

        public Strategy GetTopStrategy()
        {
            Strategy strategy = new Strategy
            {
                Bets = new List<Bet>()
                {
                    new Bet()
                    {
                        Class = _topColumnClassification,
                        Amount = 10
                    }
                }
            };

            return strategy;
        }

        public Strategy GetSingleNumberStrategy()
        {
            Strategy strategy = new Strategy
            {
                Bets = new List<Bet>()
                {
                    new Bet()
                    {
                        Class = _33Classification,
                        Amount = 10
                    }
                }
            };

            return strategy;
        }

        [Test]
        public void GetPayout_BetHits_PaysOut()
        {
            StrategyProcessor dealer = new StrategyProcessor();
            Strategy strategy = GetTopStrategy();
            int expectedPayoutAmount = 10 * 3;

            Payout actualPayout = dealer.GetPayout(strategy, 3);

            Assert.AreEqual(expectedPayoutAmount, actualPayout.Amount);
        }

        [Test]
        public void GetPayout_BetDoesntHit_DoesntPayOut()
        {
            StrategyProcessor dealer = new StrategyProcessor();
            Strategy strategy = GetTopStrategy();
            int expectedPayoutAmount = 0;

            Payout actualPayout = dealer.GetPayout(strategy, 1);

            Assert.AreEqual(expectedPayoutAmount, actualPayout.Amount);
        }

        [Test]
        public void GetPayout_SingleNumberStrategyBetHits_PaysOut()
        {
            StrategyProcessor dealer = new StrategyProcessor();
            Strategy strategy = GetSingleNumberStrategy();
            int expectedPayoutAmount = 10 * 36;

            Payout actualPayout = dealer.GetPayout(strategy, 33);

            Assert.AreEqual(expectedPayoutAmount, actualPayout.Amount);
        }

        [Test]
        public void GetCost_TopStrategy_CostReturned()
        {
            StrategyProcessor dealer = new StrategyProcessor();
            Strategy strategy = GetTopStrategy();
            int expectedCost = 10;

            int actualCost = dealer.GetCost(strategy);

            Assert.AreEqual(expectedCost, actualCost);
        }
    }
}
