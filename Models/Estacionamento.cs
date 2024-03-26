using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDIO_NET_Estacionamento.Models
{
    internal class Estacionamento
    {

        private decimal precoInicio = 0;
        private decimal precoHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicio, decimal precoHora)
        {
            this.precoInicio = precoInicio;
            this.precoHora = precoHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            String? placa = Console.ReadLine();
            veiculos.Add(placa);
        }



        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo a ser removido:");
            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                int horas = 0;
                decimal valorTotal = 0;

                Console.WriteLine("Quantas horas ficou estacionado?");

                horas = Convert.ToInt32(Console.ReadLine());
                valorTotal = precoInicio + (precoHora * horas);

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine($"Veiculo não localizado. Verifique se a placa: {placa} está correta!");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                veiculos.ForEach(v => Console.WriteLine(v));
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }

        }
    }

}
