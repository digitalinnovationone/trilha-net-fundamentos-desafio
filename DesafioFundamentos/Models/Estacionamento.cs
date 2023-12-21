using System.Globalization;

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
            // Solicita ao usuário digitar uma placa (ReadLine) e adiciona na lista "veiculos"
            Console.Write("Digite a placa do veículo para estacionar no formato (ABC-1234): ");
            string placaVeiculo = Console.ReadLine().ToUpper();
            
            // Se placa válida e ainda não existe, adiciona na lista
            if(ValidaPlaca(placaVeiculo))
            {
                if(veiculos.IndexOf(placaVeiculo) == -1)
                {
                    veiculos.Add(placaVeiculo);
                }
                else
                {
                    Console.WriteLine("Desculpe, essa placa já foi cadastrada.");
                }
            }
        }

        public void RemoverVeiculo()
        {
            Console.Write("Digite a placa do veículo para remover: ");

            // Solicita ao usuário digitar a placa e armazena na variável placa
            string placaVeiculo = Console.ReadLine().ToUpper();

            // Se placa válida, remove da lista
            if(ValidaPlaca(placaVeiculo))
            {
                // Verifica se o veículo existe
                if (veiculos.Any(x => x.ToUpper() == placaVeiculo.ToUpper()))
                {
                    Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");

                    // Solicita ao usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                    // Calcula o valor total do estacionamento
                    string periodoEstacionado = Console.ReadLine();

                    if (int.TryParse(periodoEstacionado, out int outInt))
                    {
                        string valorTotal = (precoInicial + (precoPorHora * outInt)).ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"));
                        // Remove a placa digitada da lista de veículos
                        veiculos.Remove(placaVeiculo);
                        Console.WriteLine($"O veículo {placaVeiculo} foi removido e o preço total foi de {valorTotal}");
                    }
                    else
                    {
                        Console.WriteLine("Desculpe, valor inválido. Por favor, repita a operação.");   
                    }
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
                }
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                for(int v = 0; v < veiculos.Count; v++)
                {
                    Console.WriteLine(veiculos[v]);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        // Valida se a placa está no formato ABC-1234
        private static bool ValidaPlaca(string placaVeiculo)
        {
            bool placaValida = true;

            if(placaVeiculo.Length == 8)
            {
                for(int i = 0; i < 8; i++)
                {
                    if(i < 3 && placaValida)
                    {
                        placaValida = (int)placaVeiculo[i] >= 65 && (int)placaVeiculo[i] <= 90;
                    }
                    if(i == 3 && placaValida)
                    {
                        placaValida = placaVeiculo[3].ToString() == "-";
                    }
                    if(i > 3 && placaValida)
                    {
                        placaValida = (int)placaVeiculo[i] >= 48 && (int)placaVeiculo[i] <= 57;
                    }
                }
            }
            else
            {
                placaValida = false;
            }

            if(!placaValida)
            {
                Console.WriteLine($"A placa \"{placaVeiculo}\" é inválida. Tente novamente.");
            }

            return placaValida;
        }
    }
}
