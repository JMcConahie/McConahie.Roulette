using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace McConahie.Roulette.Interfaces
{
    public interface IOutputManager
    {
        Task DisplayMessageAsync(string message);
        Task DisplayOutcomeAsync(int outcome);
    }
}
