using McConahie.Roulette.Interfaces;
using McConahie.Roulette.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace McConahie.Roulette.Games
{
    public class ClassicRoulette
    {
        private readonly List<Player> _players;
        private readonly IInputManager _inputManager;
        private readonly IOutputManager _outputManager;
        private readonly StrategyProcessor _strategyProcessor;
        private readonly StrategyManager _strategyManager;
        private CancellationToken _cancellationToken;
        private readonly RouletteWheel _rouletteWheel;
        private readonly NumberStore _numberStore;

        public ClassicRoulette(List<Player> players, IInputManager inputManager, IOutputManager outputManager, CancellationToken cancellationToken)
        {
            _players = players;
            _inputManager = inputManager;
            _outputManager = outputManager;
            _strategyProcessor = new StrategyProcessor();
            _strategyManager = new StrategyManager(_players);
            _cancellationToken = cancellationToken;
            _rouletteWheel = new RouletteWheel();
            _numberStore = new NumberStore();
        }

        public async Task PlayGameAsync()
        {
            await _outputManager.DisplayMessageAsync("Welcome to Classic Roulette! Place a bet in this format: outcome|amountToBet");

            while(!_cancellationToken.IsCancellationRequested)
            {
                await PlaceYourBetsAsync();
                await PlayRoundAsync();
                await AwardPayoutsAsync();
            }
        }

        private async Task PlaceYourBetsAsync()
        {
            foreach(Player player in _players)
            {
                await _outputManager.DisplayMessageAsync($"{player.Name}, place your bets! Your purse size is: {player.Purse}");
                List<Bet> bets = await _inputManager.GetBetsAsync();

                player.ActiveStrategy = new Strategy()
                {
                    Bets = bets
                };
            }

            await _outputManager.DisplayMessageAsync($"No more bets!");

            List<Player> playersUnableToPay = _strategyManager.PayFromPurses();

            foreach(Player player in playersUnableToPay)
            {
                await _outputManager.DisplayMessageAsync($"{player.Name} has insufficient funds. Clearing associated bets.");
            }
        }

        private async Task PlayRoundAsync()
        {
            int outcome = _rouletteWheel.Spin();
            await _outputManager.DisplayOutcomeAsync(outcome);

            _numberStore.AddResult(outcome);
        }

        private async Task AwardPayoutsAsync()
        {
            int lastResult = _numberStore.LastResult;

            foreach(Player player in _players)
            {
                Payout payout = _strategyProcessor.GetPayout(player.ActiveStrategy, lastResult);

                if (payout.Amount > 0)
                {
                    await _outputManager.DisplayMessageAsync($"{player.Name} wins {payout.Amount}");
                }
                else
                {
                    await _outputManager.DisplayMessageAsync($"{player.Name} loses!");
                }
            }

            _strategyManager.ProcessPayouts(lastResult);
        }
    }
}
