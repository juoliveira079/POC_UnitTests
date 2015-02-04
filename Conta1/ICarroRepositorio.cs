using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta1
{
    public interface ICarroRepositorio
    {
        bool IsPlacaEmUso(string placa);
    }
}
