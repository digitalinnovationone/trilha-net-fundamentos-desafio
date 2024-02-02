using System.Text.RegularExpressions;
using DesafioFundamentos.Models;
using Repository;

namespace Services
{
    public class VeiculoService
    {
        public static void AdicionarVeiculo()
        {
            Console.Clear();
            Console.Write("Digite a placa do veículo para estacionar ( ex: DSA1S24 ): ");
            string placa = Console.ReadLine().ToUpper().Replace("-", "");
            Console.Clear();

            if (ValidarPlaca(placa))
            {
                if (VeiculoRepositorio.ExisteVeiculoPorPlaca(placa))
                {
                    Console.WriteLine("┌───────────────────────────────────────────────────┐");
                    Console.WriteLine($"│ Veículo de Placa Nº: {placa}, já está estacionado │");
                    Console.WriteLine("└───────────────────────────────────────────────────┘");
                    return;
                }

                Veiculo veiculo = new(placa);
                VeiculoRepositorio.AdicionarVeiculo(veiculo);
                Console.WriteLine("┌──────────────────────────────────────────────────────────────┐");
                Console.WriteLine($"│ O Veículo de placa Nº {placa}, foi estacionado com sucesso!! │");
                Console.WriteLine("└──────────────────────────────────────────────────────────────┘");
            }
            else
            {
                Console.WriteLine("O número da placa informada não é válida!");
            }
        }

        public static void ListarTodosOsVeiculos()
        {
            Console.Clear();
            List<Veiculo> veiculos = VeiculoRepositorio.ListarTodosVeiculos();

            if (veiculos.Count != 0)
            {
                Console.WriteLine("┌───────────────────────────────────────────────────────┐");
                Console.WriteLine("                  VEÍCULOS ESTACIONADOS                  ");
                
                for (int i = 0; i < veiculos.Count; i++)
                {
                   Console.WriteLine("┌───────────────────────────────────────────────────────┐");
                   Console.WriteLine($"│  {i + 1} - O Veículo de Placa Nº: {veiculos[i]} está estacionado! │");
                   Console.WriteLine("└───────────────────────────────────────────────────────┘");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public static void ListarVeiculoPorPlaca()
        {
            Console.Clear();
            Console.Write("Digite a placa do veículo estacionado ( ex: DSA1S24 ): ");
            string placa = Console.ReadLine().ToUpper().Replace("-", "");
            Console.Clear();

            if (placa.Length > 7 || placa.Length < 7)
            {
                Console.Clear();
                Console.WriteLine("A placa informada NÃO é válida!");
                return;
            }

            if (VeiculoRepositorio.ExisteVeiculoPorPlaca(placa))
            {
                Console.WriteLine("┌───────────────────────────────────────────────┐");
                Console.WriteLine($"│ Veículo de Placa Nº: {placa} está estacionado │");
                Console.WriteLine("└───────────────────────────────────────────────┘");
            }
            else
            {
                Console.WriteLine($"O veículo informado NÃO está cadastrado em nosso sistema!");
            }
        }

        public static void EditarVeiculo()
        {
            Console.Clear();
            Console.Write("Digite a placa do veículo ( ex: DSA1S24 ): ");
            string placa = Console.ReadLine().ToUpper().Replace("-", "");
            Veiculo veiculo = VeiculoRepositorio.ListarUmVeiculo(placa);
            Console.Clear();

            Console.Write("Digite a placa correta do veículo para editar ( ex: DSA1S24 ): ");
            string placaCorreta = Console.ReadLine().ToUpper().Replace("-", "");
            Console.Clear();

            if (ValidarPlaca(placaCorreta))
            {
                if (placaCorreta == placa)
                {
                    Console.WriteLine("A placa informada não pode ser igual a placa anterior!");

                } else if (veiculo != null)                 
                {
                    veiculo.Placa = placaCorreta;
                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine($"│ O veículo de placa Nº {placa}, foi atualizado para a placa Nº {placaCorreta} │");
                    Console.WriteLine("└───────────────────────────────────────────────────────────────────────┘");
                    
                } else
                {
                    Console.WriteLine("A placa informada não é válida!");
                }
            }
            else
            {
                Console.WriteLine("O número da placa informada não é válida!");
            }
        }

        public static void RemoverVeiculo()
        {
            Console.Clear();
            Console.Write("Digite a placa do veículo para remover ( ex: DSA1S24 ): ");
            string placa = Console.ReadLine().ToUpper().Replace("-", "");
            Console.Clear();

            Estacionamento estacionamento = new(precoInicial: 20.50M, precoPorHora: 2.50M);

            var veiculo = VeiculoRepositorio.ListarUmVeiculo(placa);

            if (veiculo != null)
            {
                Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado (no formato hh:mm): ");
                string[] partesHorasMin = Console.ReadLine().Split(':');
                Console.Clear();

                if (partesHorasMin.Length == 2 && 
                int.TryParse(partesHorasMin[0], out int horas) && 
                int.TryParse(partesHorasMin[1], out int minutos) && 
                horas >= 0 && minutos >= 0 && 
                minutos < 60)
                {
                    int toleranciaMin = 15;
                    decimal valorTotalGastoEstacionado;
                    if(minutos > toleranciaMin)
                    {
                        valorTotalGastoEstacionado = estacionamento.CalculaPrecoInicialMaisPrecoPorHora(horas) + estacionamento.PrecoPorHora;
                    }
                    else
                    {
                        valorTotalGastoEstacionado = estacionamento.CalculaPrecoInicialMaisPrecoPorHora(horas);
                    }

                    VeiculoRepositorio.DeletarVeiculo(placa);
                    Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine($"│ O veículo de Placa Nº: {placa}, foi removido e o preço total foi de {valorTotalGastoEstacionado.ToString("C2")} │");
                    Console.WriteLine("└──────────────────────────────────────────────────────────────────────────────┘");
                }
                else
                {
                    Console.WriteLine("Formato inválido. Por favor, digite as horas no formato hh:mm.");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        private static bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa)) { return false; }

            if (placa.Length > 7 || placa.Length < 7) { return false; }

            if (char.IsLetter(placa, 4))
            {
                Regex padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                return padraoMercosul.IsMatch(placa);
            }
            else
            {
                Regex padraoNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
                return padraoNormal.IsMatch(placa);
            }
        }
    }
}
