using DesafioFundamentos.util;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private readonly decimal precoInicial = 0;
        private readonly decimal precoPorHora = 0;
        private readonly List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placaVeiculo = Console.ReadLine().ToUpper();
            
            // verifica se é uma placa válida
            if (StringUtils.IsPlacaValida(placaVeiculo))
            {
                this.veiculos.Add(placaVeiculo);
                Console.WriteLine($"Veículo {placaVeiculo} adicionado com sucesso");
            } else
            {
                Console.WriteLine($"Você digitou uma placa inválida!");
                Console.WriteLine($"Formatos Aceitaveis:");
                Console.WriteLine($"ABC1D23");
                Console.WriteLine($"ABC1234");
            }

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Contains(placa))
            {
                
                int horas;
                string userInput;
                bool isInteger;
                
                // Pergunta ao usuário até ele digitar uma quantidade de horas válida
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                do
                {
                    userInput = Console.ReadLine();
                    
                    // verificar se é uma quantidade não negativa
                    isInteger = StringUtils.IsNonNegativeInteger(userInput);

                    if (!isInteger)
                    {
                        Console.WriteLine("O Valor informado é inválido!");
                        Console.WriteLine("Digite uma quantidade de horas válida:");
                    }

                } while (!isInteger);

                horas = int.Parse(userInput);

                decimal valorTotal = precoInicial + (precoPorHora * horas); 

                this.veiculos.Remove(placa);

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
                foreach (var veiculo in veiculos)
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
