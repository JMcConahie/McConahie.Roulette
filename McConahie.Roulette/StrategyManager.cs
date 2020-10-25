using McConahie.Roulette.Models;
using System.Collections.Generic;

namespace McConahie.Roulette
{
    public class StrategyManager
    {
        private List<Player> _players;
        private StrategyProcessor _strategyProcessor;

        public StrategyManager(List<Player> players)
        {
            _players = players;
            _strategyProcessor = new StrategyProcessor();
        }

        public void ProcessPayouts(int outcome)
        {
            foreach(Player player in _players)
            {
                Payout payout = _strategyProcessor.GetPayout(player.ActiveStrategy, outcome);
                player.Purse += payout.Amount;

                if (player.ActiveStrategy.IsMartingale)
                {
                    foreach (Bet bet in player.ActiveStrategy.Bets)
                    {
                        if (payout.Amount < 1)
                        {
                            bet.Amount *= 2;
                        }
                        else
                        {
                            bet.Amount = bet.BaseAmount;
                        }
                    }
                }
            }
        }

        public List<Player> PayFromPurses()
        {
            var playersUnableToPay = new List<Player>();

            foreach(Player player in _players)
            {
                int amount = _strategyProcessor.GetCost(player.ActiveStrategy);

                if (amount > player.Purse)
                {
                    player.ActiveStrategy.Bets = new List<Bet>();
                    playersUnableToPay.Add(player);
                }
                else
                {
                    player.Purse -= amount;
                }
            }

            return playersUnableToPay;
        }
    }
}
