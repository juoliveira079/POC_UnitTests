using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste1
{
    [TestClass]
    public class TestesDaCalculadora
    {
        private Calculadora calculadora;

        [TestInitialize]
        public void IniciarTestes()
        {
            var calculadora = new Calculadora();
        }

        [TestCleanup]
        public void FinalizarTestes()
        {
            Debug.WriteLine("Teste finalizado");
        }

        [TestMethod]
        public void Soma_deve_retornar_10_quando_passar_9_e_1()
        {
            // arrange
            var calculadora = new Calculadora();
            // Act
            var retorno= calculadora.Soma(9, 1);
            // Assert
            Assert.AreEqual(10, retorno);
          
        }

        [TestMethod]
        public void Soma_deve_retornar_54_quando_passar_30_e_24()
        {
            // arrange
            var calculadora = new Calculadora();
            // Act
            var retorno = calculadora.Soma(30, 24);
            // Assert
            Assert.AreEqual(54, retorno);

        }
        [TestMethod]
        public void Subtracao_deve_retornar_10_quando_passar_20_e_10()
        {
            // arrange
            var calculadora = new Calculadora();
            // Act
            var retorno = calculadora.Subtracao(20, 10);
            // Assert
            Assert.AreEqual(10, retorno);

        }

        [TestMethod]
        public void Multiplicacao_deve_retornar_25_quando_passar_5_e_5()
        {
            // arrange
            var calculadora = new Calculadora();
            // Act
            var retorno = calculadora.Multiplicacao(5, 5);
            // Assert
            Assert.AreEqual(25, retorno);

        }

        [TestMethod]
        public void Divisao_deve_retornar_10_quando_passar_100_e_10()
        {
            // arrange
            var calculadora = new Calculadora();
            // Act
            var retorno = calculadora.Divisao(100, 10);
            // Assert
            Assert.AreEqual(10, retorno);

        }
    }
}
