using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesafioFundamentos.Models;


namespace Tests
{
  [TestClass]
  public class EstacionamentoTest
  {
    [TestMethod]
    public void TestAddVeiculo()
    {
      decimal precoInicial = 2;
      decimal precoPorHora = 4;
      string placa = "ebx-2121";
      int horaEntrada = 2;

      Estacionamento estacionar = new Estacionamento(precoInicial, precoPorHora);

      estacionar.AdicionarVeiculo(placa, horaEntrada);

      bool estacionado = estacionar.Veiculos.Any(v => v.Placa == placa.ToUpper());

      Assert.AreEqual(true, estacionado);

    }

    [TestMethod]
    public void TestBuscaVeiculo()
    {
      decimal precoInicial = 2;
      decimal precoPorHora = 4;
      string placa = "ebx-2121";
      int horaEntrada = 2;
      int horaSaida = 8;
      bool estacionado;

      Estacionamento estacionar = new Estacionamento(precoInicial, precoPorHora);

      estacionar.AdicionarVeiculo(placa, horaEntrada);
      

      Veiculo veiculo = estacionar.BuscarVeiculo(placa);

      Assert.AreEqual(placa.ToUpper(), veiculo.Placa);


    }



    [TestMethod]
    public void TestRemoveVeiculo()
    {
      decimal precoInicial = 2;
      decimal precoPorHora = 4;
      string placa = "ebx-2121";
      int horaEntrada = 2;
      int horaSaida = 8;
      bool estacionado;

      Estacionamento estacionar = new Estacionamento(precoInicial, precoPorHora);

      estacionar.AdicionarVeiculo(placa, horaEntrada);
      estacionado = estacionar.Veiculos.Any(v => v.Placa == placa.ToUpper());
      Assert.AreEqual(true, estacionado);

      estacionar.RemoverVeiculo(placa, horaSaida);
      estacionado = estacionar.Veiculos.Any(v => v.Placa == placa.ToUpper());

      Assert.AreEqual(false, estacionado);



    }
  }
}