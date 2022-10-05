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
      bool estacionado;

      Estacionamento estacionar = new Estacionamento(precoInicial, precoPorHora);

      estacionar.AdicionarVeiculo(placa, horaEntrada);

      Veiculo veiculo = estacionar.BuscarVeiculo(placa);
      Veiculo veiculo2 = estacionar.BuscarVeiculo("ELX-2121");

      Assert.AreEqual(placa.ToUpper(), veiculo.Placa);
      Assert.AreEqual(null, veiculo2);

    }



    [TestMethod]
    public void TestRemoveVeiculo()
    {
      decimal precoInicial = 2;
      decimal precoPorHora = 4;
      string placa = "EBX-2121";
      int horaSaida = 8;
      bool estacionado;

      Estacionamento estacionar = new Estacionamento(precoInicial, precoPorHora);

      Veiculo veiculo = new Veiculo(placa, 2);
      estacionar.Veiculos.Add(veiculo);

      estacionar.RemoverVeiculo(veiculo, horaSaida);

      estacionado = estacionar.Veiculos.Any(v => v.Placa == placa.ToUpper());
      Assert.AreEqual(false, estacionado);

    }

    [TestMethod]
    public void TestGeraPagamento()
    {
      decimal precoInicial = 2;
      decimal precoPorHora = 4;
      string placa = "EBX-2121";

      Estacionamento estacionar = new Estacionamento(precoInicial, precoPorHora);

      Veiculo veiculo = new Veiculo(placa, 2);

      Decimal total = estacionar.GeraPagamento(veiculo, 6);

      Assert.AreEqual(36, total);

    }

     [TestMethod]
    public void TestCalculaHorasEstacionado()
    {
      decimal precoInicial = 2;
      decimal precoPorHora = 4;
      string placa = "EBX-2121";

      Estacionamento estacionar = new Estacionamento(precoInicial, precoPorHora);

      Veiculo veiculo = new Veiculo(placa, 2);
      veiculo.AddSaida(8);

      int totalHoras = estacionar.CalculaHoras(veiculo);

      Assert.AreEqual(6, totalHoras);

    }
  }
}