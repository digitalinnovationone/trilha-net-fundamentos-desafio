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
        private string NormalizarPlaca(string placa)
        {
            return placa;
        }


        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {

            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            placa = NormalizarPlaca(placa);

            veiculos.Add(placa);

            Console.WriteLine("Veículo estacionado com sucesso!");

            Console.WriteLine($"Total de veículos: {veiculos.Count}");

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");


            string placa = Console.ReadLine();

            placa = NormalizarPlaca(placa);

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");


                int horas = int.Parse(Console.ReadLine());


                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa);



                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
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
                foreach (string placa in veiculos)
                {
                    Console.WriteLine($"-{placa}");

                }


            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

    }
}

