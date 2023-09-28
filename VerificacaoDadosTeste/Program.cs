using System;

namespace VerificacaoDadosTeste {
  class Program {
    static void Main(string[] args) {
      // Aqui é solicitado ao usuário que insira o ID do teste:
      int idTeste;

      if (int.TryParse(Console.ReadLine(), out idTeste)) {
        // Solicita ao usuário que insira a descrição do teste:
        string descricaoTeste = Console.ReadLine();

        // Verifica se o ID do teste é válido e a descrição está dentro dos limites:
        if (idTeste > 0 && descricaoTeste.Length <= 50) {
          Console.WriteLine("ID de teste valido.\nDescricao valida.");
        } else {
          Console.WriteLine("ID de teste invalido ou\ndescricao muito longa.");
        }
      } else {
        Console.WriteLine("ID de teste invalido.");
      }
    }
  }
}