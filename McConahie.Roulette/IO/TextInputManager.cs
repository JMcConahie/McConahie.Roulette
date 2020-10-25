using McConahie.Roulette.Interfaces;
using McConahie.Roulette.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McConahie.Roulette.IO
{
    public class TextInputManager : IInputManager
    {
        private readonly NameClassifier _nameClassifier;

        public TextInputManager()
        {
            _nameClassifier = new NameClassifier();
        }

        /// <summary>
        /// Bet Format: betName|Amount betName|Amount
        /// </summary>
        /// <returns></returns>
        public async Task<List<Bet>> GetBetsAsync()
        {
            bool betsPlaced = false;
            List<Bet> bets = new List<Bet>();

            while(!betsPlaced)
            {
                await Console.Out.WriteAsync(">");
                string inputValue = await Console.In.ReadLineAsync();
                
                if(!string.IsNullOrWhiteSpace(inputValue))
                {
                    List<string> textBets = inputValue.Split(' ').ToList();
                    foreach(string textBet in textBets)
                    {
                        if(!string.IsNullOrWhiteSpace(textBet))
                        {
                            List<string> textBetPair = textBet.Split('|').ToList();
                            if(textBetPair.Count == 2)
                            {
                                string betName = textBetPair[0];
                                string betAmount = textBetPair[1];

                                Classification betClassification = _nameClassifier.GetClassificationByName(betName);

                                bool validAmountInput = int.TryParse(betAmount, out int amount);

                                if(!validAmountInput)
                                {
                                    await RedTextLineAsync("Invalid Bet Amount.");
                                }
                                else if(betClassification == null)
                                {
                                    await RedTextLineAsync("Unrecognized Bet Outcome Name.");
                                }
                                else
                                {
                                    Bet bet = new Bet()
                                    {
                                        Id = Guid.NewGuid(),
                                        Amount = amount,
                                        BaseAmount = amount,
                                        Class = betClassification
                                    };

                                    bets.Add(bet);
                                }
                            }
                            else
                            {
                                await RedTextLineAsync("Invalid Bet Entry.");
                            }
                        }
                        else
                        {
                            await RedTextLineAsync("Invalid Bet Entry.");
                        }
                    }

                    if(bets.Count > 0)
                    {
                        betsPlaced = true;
                    }
                    else
                    {
                        await YellowTextLineAsync("No valid bets placed. Try Again.");
                    }
                }
                else
                {
                    await RedTextLineAsync("No bets placed.");
                }
            }

            return bets;
        }

        private async Task RedTextLineAsync(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            await Console.Out.WriteLineAsync(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private async Task YellowTextLineAsync(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            await Console.Out.WriteLineAsync(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
