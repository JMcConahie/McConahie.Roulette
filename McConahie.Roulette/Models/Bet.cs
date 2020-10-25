using System;

namespace McConahie.Roulette.Models
{
    public class Bet
    {
        public Guid Id { get; set; }
        public Classification Class { get; set; }
        public int BaseAmount { get; set; }
        public int Amount { get; set; }
    }
}
