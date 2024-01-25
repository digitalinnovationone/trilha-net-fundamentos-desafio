using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Veiculo> veiculos = new List<Veiculo>();
        

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            Console.WriteLine("Digite a hora de entrada (formato HH:mm):");
            if (DateTime.TryParseExact(Console.ReadLine(), "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime horaEntrada))
            {
                veiculos.Add(new Veiculo(placa.ToUpper(), horaEntrada));
                Console.WriteLine($"Veículo com placa: {placa}, cadastrado com sucesso");
            }
            else
            {
                Console.WriteLine("Por favor, digite um formato de hora válido para a hora de entrada (HH:mm).");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            Veiculo veiculo = veiculos.FirstOrDefault(x => x.Placa.ToUpper().Equals(placa, StringComparison.CurrentCultureIgnoreCase));

            if (veiculo != null)
            {
                Console.WriteLine("Digite a hora de saída (formato HH:mm):");

                if (DateTime.TryParseExact(Console.ReadLine(), "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime horaSaida))
                {
                    if (horaSaida > veiculo.HoraEntrada)
                    {
                        decimal valorTotal = veiculo.CalcularValorTotal(precoInicial, precoPorHora, horaSaida);
                        veiculos.Remove(veiculo);

                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                    }
                    else
                    {
                        Console.WriteLine("A hora de saída deve ser posterior à hora de entrada.");
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, digite um formato de hora válido para a hora de saída (HH:mm).");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo.Placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }

    public class Veiculo
    {
        public string Placa { get; private set; }
        public DateTime HoraEntrada { get; private set; }

        public Veiculo(string placa, DateTime horaEntrada)
        {
            Placa = placa;
            HoraEntrada = horaEntrada;
        }

        public decimal CalcularValorTotal(decimal precoInicial, decimal precoPorHora, DateTime horaSaida)
        {
            int horasEstacionado = (int)Math.Ceiling((horaSaida - HoraEntrada).TotalHours);
            return precoInicial + precoPorHora * horasEstacionado;
        }
    }
}
