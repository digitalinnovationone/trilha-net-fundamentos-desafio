using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            Console.WriteLine("Digite a placa (formato LLLNLNN, ex: ABC1D23):");
            string placa = Console.ReadLine().Trim().ToUpper();

            //Implementação extra : Verificar se a placa se encaixa no padrão nacional de modelo de placa
            string padrao = @"^[A-Z]{3}\d[A-Z]\d{2}$";
            bool valida = Regex.IsMatch(placa, padrao);

            if (valida)
            {
                veiculos.Add(placa);
                Console.WriteLine("Placa válida! Adicionada.");
            }
            else
            {
                Console.WriteLine("Placa inválida! Formato esperado: ABC1D23");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            string placaFormatada = veiculos.FirstOrDefault(x => x.ToUpper() == placa.ToUpper());

            // Verifica se o veículo existe
            if (placaFormatada != null)
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = int.Parse(Console.ReadLine());
                decimal valorTotal = (precoPorHora * horas) + precoInicial;

                veiculos.Remove(placaFormatada);

                Console.WriteLine($"O veículo {placa.ToUpper()} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
