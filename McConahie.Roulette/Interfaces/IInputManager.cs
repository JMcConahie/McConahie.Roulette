using McConahie.Roulette.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace McConahie.Roulette.Interfaces
{
    public interface IInputManager
    {
        Task<List<Bet>> GetBetsAsync();
    }
}
