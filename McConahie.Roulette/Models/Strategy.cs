using System.Collections.Generic;

namespace McConahie.Roulette.Models
{
    public class Strategy
    {
        public List<Bet> Bets { get; set; }
        public bool IsMartingale { get; set; }
    }
}
