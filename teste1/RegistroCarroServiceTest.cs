using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conta1;
using Moq;
namespace teste1
{
    [TestClass]
    public class RegistroCarroServiceTest
    {

        private RegistroCarroService _registroCarroService;

        [TestInitialize]
        public void IniciarTestes()
        {
            var mock = new Mock<ICarroRepositorio>();

            // Definição de cenários ficticios.
            mock.Setup(x => x.IsPlacaEmUso("EMU-1111")).Returns(true);
            mock.Setup(x => x.IsPlacaEmUso("NAO-1111")).Returns(false);

            _registroCarroService = new RegistroCarroService(mock.Object);
        }

        [TestCleanup]
        public void FinalizarTestes()
        {
            Debug.WriteLine("Teste finalizado");
        }

        [TestMethod]
        public void Placa_nao_foi_informada()
        {
            var carro = new Carro
            {
                Placa = null,
                Modelo = "Brava",
                Ano = 1990
            };

            try
            {
                _registroCarroService.Registrar(carro);
            } 
            catch(Exception e)
            {
                Assert.AreEqual(e.Message, "Placa deve ser informada.");
            }
        }

        [TestMethod]
        public void Placa_informada_jah_registrada()
        {
            var carro = new Carro
                {
                    Placa = "EMU-1111",
                    Modelo = "Brava",
                    Ano = 1999
                };

            try
            {
                _registroCarroService.Registrar(carro);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Placa já está em uso.");
            }
        }

        public void Ano_menor_que_1990()
        {
            var carro = new Carro
            {
                Placa = "NAO-1111",
                Modelo = "Brava",
                Ano = 1989
            };

            try { 
                _registroCarroService.Registrar(carro);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Ano tem que ser maior ou igual a 1990.");
            }
        }


        [TestMethod]
        public void Modelo_nao_foi_informado()
        {
            var carro = new Carro
            {
                Placa = "NAO-1111",
                Modelo = null,
                Ano = 1990
            };

            try
            {
                _registroCarroService.Registrar(carro);
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "Modelo deve ser informado.");
            }
        }

        [TestMethod]
        public void Carro_valido_para_registrar()
        {
            var carro = new Carro
            {
                Placa = "NAO-1111",
                Modelo = "Brava",
                Ano = 1990
            };

            _registroCarroService.Registrar(carro);
        }
    }
}
