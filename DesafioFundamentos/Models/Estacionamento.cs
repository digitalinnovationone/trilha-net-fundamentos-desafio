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
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(placa))
            {
                veiculos.Add(placa.ToUpper());
                Console.WriteLine($"O veículo com a placa {placa.ToUpper()} foi estacionado com sucesso.");
            }
            else
            {
                Console.WriteLine("Placa inválida. Não foi possível estacionar o veículo.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placaInput = Console.ReadLine();
            
            // Encontra o veículo na lista, ignorando a caixa (maiúsculas/minúsculas)
            string veiculoParaRemover = veiculos.FirstOrDefault(x => x.Equals(placaInput, StringComparison.OrdinalIgnoreCase));

            // Verifica se o veículo existe
            if (veiculoParaRemover != null)
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal              
                int horas = 0;
                decimal valorTotal = 0; 
                
                if (int.TryParse(Console.ReadLine(), out horas))
                {
                    valorTotal = precoInicial + (precoPorHora * horas);
                    
                    // Remover a placa digitada da lista de veículos
                    veiculos.Remove(veiculoParaRemover);

                    Console.WriteLine($"O veículo {veiculoParaRemover} foi removido e o preço total foi de: R$ {valorTotal:N2}");
                }
                else
                {
                    Console.WriteLine("Quantidade de horas inválida. Veículo não removido.");
                }
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
                // Realizar um laço de repetição, exibindo os veículos estacionados
                int contador = 0;
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine($"Vaga {++contador}: {veiculo}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
