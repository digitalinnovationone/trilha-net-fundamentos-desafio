using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioEstacionamento
{
    class Estacionamento
    {
        public decimal precoInicial { get; set; } = 10;
        public decimal precoPorHora { get; set; } = 5;
        public List<string> veiculos { get; set; } = new List<string>();

        public void AdicionarVeiculo(string placa)
        {
            this.veiculos.Add(placa);
        }

        public decimal RemoverVeiculo(string placa, DateTime dataHoraSaida)
        {
            // Verifica se o veículo está estacionado
            if (!this.veiculos.Contains(placa))
            {
                return 0;
            }

            // Calcula o tempo de permanência do veículo
            DateTime dataHoraEntrada = this.veiculos.Where(v => v == placa).FirstOrDefault();
            TimeSpan tempoPermanencia = dataHoraSaida - dataHoraEntrada;

            // Calcula o valor cobrado
            decimal valorCobrado = this.precoInicial + (tempoPermanencia.TotalHours * this.precoPorHora);

            // Remove o veículo da lista
            this.veiculos.Remove(placa);

            return valorCobrado;
        }

        public void ListarVeiculos()
        {
            if (this.veiculos.Count == 0)
            {
                Console.WriteLine("Não há veículos estacionados");
            }
            else
            {
                foreach (string placa in this.veiculos)
                {
                    Console.WriteLine(placa);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Cria um estacionamento
            Estacionamento estacionamento = new Estacionamento();

            // Menu interativo
            int opcao = 0;
            while (opcao != 4)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Cadastrar veículo");
                Console.WriteLine("2 - Remover veículo");
                Console.WriteLine("3 - Listar veículos");
                Console.WriteLine("4 - Encerrar");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        // Solicita a placa do veículo
                        string placa = Console.ReadLine();

                        // Adiciona o veículo
                        estacionamento.AdicionarVeiculo(placa);
                        break;
                    case 2:
                        // Solicita a placa do veículo
                        string placa = Console.ReadLine();

                        // Solicita a data e hora de saída do veículo
                        DateTime dataHoraSaida = DateTime.Parse(Console.ReadLine());

                        // Remove o veículo e calcula o valor cobrado
                        decimal valorCobrado = estacionamento.RemoverVeiculo(placa, dataHoraSaida);

                        // Exibe o valor cobrado
                        Console.WriteLine("O valor cobrado foi de R$ {0:0.00}", valorCobrado);
                        break;
                    case 3:
                        // Lista os veículos
                        estacionamento.ListarVeiculos();
                        break;
                    case 4:
                        // Encerra o programa
                        break;
                    default:
                        // Opção inválida
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
        }
    }
}
