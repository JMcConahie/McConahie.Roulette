using System;
using System.Collections.Generic;

namespace McConahie.Roulette.Models
{
    public class Payout
    {
        public int Amount { get; set; }
        public List<Guid> WinningBets { get; set; }
        public List<Guid> LosingBets { get; set; }
    }
}
