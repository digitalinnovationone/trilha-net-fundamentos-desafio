using System;

namespace AvaliacaoTestesAutomatizados {
  class Program {
    static void Main(string[] args) {
      // Solicita ao usuário a entrada para o número de testes passados
      Console.Write($"Total de testes passados: ");
      int testesPassados = Convert.ToInt32(Console.ReadLine());

      // Solicita ao usuário a entrada para o número total de testes
      Console.Write($"Total de testes: ");
      int totalTestes = Convert.ToInt32(Console.ReadLine());
      
      // TODO: Calcule a taxa de sucesso e armazená-la na variável taxaSucesso:
      decimal taxaSucesso = Convert.ToDecimal(testesPassados) / Convert.ToDecimal(totalTestes) * 100;

      // Exibe a taxa de sucesso com 2 casas decimais
      Console.WriteLine($"Taxa de sucesso: {taxaSucesso:F2}%");
    }
  }
}