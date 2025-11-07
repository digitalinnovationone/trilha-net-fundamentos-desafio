using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine()?.Trim(); // <-- .Trim() remove espaços extras

            if (!string.IsNullOrWhiteSpace(placa))
            {
                veiculos.Add(placa.ToUpper()); // Armazena em maiúsculas para evitar duplicidade
                Console.WriteLine($"✅ Veículo {placa.ToUpper()} adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("❌ Placa inválida. Tente novamente.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine()?.Trim();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                if (int.TryParse(Console.ReadLine(), out int horas))
                {
                    decimal valorTotal = precoInicial + (precoPorHora * horas);

                    // Remove a placa da lista
                    veiculos.Remove(veiculos.First(x => x.ToUpper() == placa.ToUpper()));

                    Console.WriteLine($"🚗 O veículo {placa.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("❌ Valor de horas inválido. Tente novamente.");
                }
            }
            else
            {
                Console.WriteLine("❌ Desculpe, esse veículo não está estacionado aqui.");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("🚙 Veículos estacionados:");
                foreach (string placa in veiculos)
                {
                    Console.WriteLine($"- {placa}");
                }
            }
            else
            {
                Console.WriteLine("⚠️ Não há veículos estacionados.");
            }
        }
    }
}
