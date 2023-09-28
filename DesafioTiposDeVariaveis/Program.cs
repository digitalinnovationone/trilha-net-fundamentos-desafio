using System;

namespace SimulacaoFalhaTeste {
  class Program {
    static void Main(string[] args) {
      
      Console.OutputEncoding = System.Text.Encoding.UTF8;
      Console.Clear();
      
      Console.WriteLine("SSFTS - Sistema de Simulação em Falha de Teste de Software");
      Console.Write("Digite o nome do teste: ");
      string nomeDoTeste = Console.ReadLine();
      
      Console.Write("Descreva o erro encontrado: ");
      string descricaoDoErro = Console.ReadLine();

      Console.WriteLine($"O teste falhou. Descrição: {descricaoDoErro}");      
    }
  }
}