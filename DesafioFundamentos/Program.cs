using System;
using DesafioFundamentos.Models;

namespace DesafioFundamentos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o preço inicial:");
            decimal precoInicial = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Digite o preço por hora:");
            decimal precoPorHora = decimal.Parse(Console.ReadLine());

            Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

            bool exibirMenu = true;

            while (exibirMenu)
            {
                Console.WriteLine("\nDigite a sua opção:");
                Console.WriteLine("1 - Cadastrar veículo");
                Console.WriteLine("2 - Remover veículo");
                Console.WriteLine("3 - Listar veículos");
                Console.WriteLine("4 - Encerrar");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        estacionamento.AdicionarVeiculo();
                        break;

                    case "2":
                        estacionamento.RemoverVeiculo();
                        break;

                    case "3":
                        estacionamento.ListarVeiculos();
                        break;

                    case "4":
                        exibirMenu = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
    }
}
