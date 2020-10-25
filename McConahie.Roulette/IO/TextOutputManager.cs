using McConahie.Roulette.Interfaces;
using System;
using System.Threading.Tasks;

namespace McConahie.Roulette.IO
{
    public class TextOutputManager : IOutputManager
    {
        public async Task DisplayMessageAsync(string message)
        {
            await Console.Out.WriteLineAsync(message);
        }

        public async Task DisplayOutcomeAsync(int outcome)
        {
            string displayOutcome = outcome.ToString();
            if(outcome == 37)
            {
                displayOutcome = "00";
            }

            await Console.Out.WriteLineAsync($"Outcome is a {displayOutcome}");
        }
    }
}
