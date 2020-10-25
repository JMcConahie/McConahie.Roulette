using McConahie.Roulette.Models;
using System;
using System.Collections.Generic;

namespace McConahie.Roulette
{
    public class StrategyProcessor
    {
        private ResultClassifier _classifier = new ResultClassifier();

        public Payout GetPayout(Strategy strategy, int outcome)
        {
            Payout payout = new Payout()
            {
                WinningBets = new List<Guid>(),
                LosingBets = new List<Guid>()
            };

            List<Classification> classifications = _classifier.ClassifyResult(outcome);

            foreach (Bet bet in strategy.Bets)
            {
                if (classifications.Contains(bet.Class))
                {
                    payout.Amount += (bet.Amount * bet.Class.PayoutMultiplier);
                    payout.WinningBets.Add(bet.Id);
                }
                else
                {
                    payout.LosingBets.Add(bet.Id);
                }
            }

            return payout;
        }

        public int GetCost(Strategy strategy)
        {
            int totalCost = 0;

            foreach(Bet bet in strategy.Bets)
            {
                totalCost += bet.Amount;
            }

            return totalCost;
        }
    }
}
