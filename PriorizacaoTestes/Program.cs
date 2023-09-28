using System;

namespace PriorizacaoTestes {
  class Program {
    static void Main(string[] args) {

      string[] testes = new string[3];
      string[] complexidades = {"baixa","media","alta"};

      for (int i = 0; i < 3; i++) {
        testes[i] = Console.ReadLine().ToLower();
      }

      int maiorComplexidadeIndex = EncontrarMaiorComplexidadeIndex(testes, complexidades);
    //   string testePrioritario = $"Teste {maiorComplexidadeIndex + 1}";

      Console.WriteLine($"O teste a ser executado primeiro é o Teste {maiorComplexidadeIndex + 1}.");

      Console.ReadLine();
    }

    static int EncontrarMaiorComplexidadeIndex(string[] testes, string[] complexidades) {
      int maiorIndex = 0;

      for (int i = 1; i < testes.Length; i++) {

        if (Array.IndexOf(complexidades, testes[i]) > Array.IndexOf(complexidades, testes[maiorIndex])) {
          maiorIndex = i;
        }
      }
      return maiorIndex;
    }
  }
}