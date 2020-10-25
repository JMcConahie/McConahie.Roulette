using System;

namespace McConahie.Roulette.Models
{
    public class Player
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Purse { get; set; }
        public Strategy ActiveStrategy { get; set; }
    }
}
