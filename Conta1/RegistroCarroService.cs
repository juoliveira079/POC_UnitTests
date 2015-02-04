using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conta1
{
    public class RegistroCarroService
    {
        private readonly ICarroRepositorio _carroRepositorio;

        public RegistroCarroService(ICarroRepositorio carroRepositorio)
        {
            _carroRepositorio = carroRepositorio;
        }

        public void Registrar(Carro carro)
        {
            if (string.IsNullOrEmpty(carro.Placa))
            {
                throw new ArgumentException("Placa deve ser informada.");
            }

            if (carro.Ano < 1990)
            {
                throw new ArgumentException("Ano tem que ser maior ou igual a 1990.");
            }

            if (string.IsNullOrEmpty(carro.Modelo))
            {
                throw new ArgumentException("Modelo deve ser informado.");
            }

            if (_carroRepositorio.IsPlacaEmUso(carro.Placa))
            {
                throw new ArgumentException("Placa já está em uso.");
            }
        }
    }
}
