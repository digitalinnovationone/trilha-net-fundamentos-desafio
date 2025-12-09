using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafiofundamentos.Models
{
    public class Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
        private readonly decimal precoInicial = precoInicial;
        private readonly decimal precoPorHora = precoPorHora;
        private readonly List<string> veiculos = [];

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            
            string? nomePlaca = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nomePlaca))
            {
                Console.WriteLine("Entrada inválida! O valor não pode ser vazio ou apenas espaços.");
                return;
            }

            veiculos.Add(nomePlaca);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string? nomePlaca = Console.ReadLine();
            // string placaUpperCase = nomePlaca!.ToUpper();
            // string placaUpperCase = (nomePlaca ?? "").ToUpper();

            if (string.IsNullOrWhiteSpace(nomePlaca))
            {
                Console.WriteLine("Entrada inválida! O valor não pode ser vazio ou apenas espaços.");
                return;
            }

            if (veiculos.Any(x => x.Equals(nomePlaca, StringComparison.CurrentCultureIgnoreCase)))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horaEstacionado = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = (precoInicial + precoPorHora) * horaEstacionado;

                veiculos.Remove(nomePlaca);

                Console.WriteLine($"O veículo {nomePlaca} foi removido e o preço total foi de: R$ {valorTotal}");
                return;
            }

            Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
        }

        public void ListarVeiculos()
        {
            if (veiculos.Count != 0)
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (var item in veiculos)
                {
                    Console.WriteLine(item);
                }
                return;
            }
            Console.WriteLine("Não há veículos estacionados.");
        }
    }

}