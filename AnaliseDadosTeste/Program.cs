using System;

namespace AnaliseDadosTeste {
  class Program {
    static void Main(string[] args) {
      // Solicita ao usuário a quantidade de testes bem-sucedidos:
      int testesBemSucedidos = int.Parse(Console.ReadLine());

      // Solicita ao usuário a quantidade de testes totais:
      int testesTotais = int.Parse(Console.ReadLine());

      // TODO: Implemente as condições para o cálculo da taxa de sucesso:

      decimal taxaSucesso = Convert.ToDecimal(testesBemSucedidos) / Convert.ToDecimal(testesTotais) * 100;

      // TODO: Implemente uma estrutura condicional (if/else) para avaliar a taxa de sucesso e tomar decisões com base nela:

      if (taxaSucesso < 80m) 
      {
        System.Console.WriteLine("A funcionalidade nao esta pronta para lancamento.");
      } 
      else
      {
        System.Console.WriteLine("A funcionalidade esta pronta para lancamento.");
      } 

    }
  }
}