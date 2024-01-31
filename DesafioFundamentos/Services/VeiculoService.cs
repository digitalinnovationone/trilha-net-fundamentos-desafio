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
            Console.Write("Digite a placa do veículo para estacionar: ");
            string placa = Console.ReadLine().ToUpper().Replace("-", "");

            if (ValidarPlaca(placa))
            {
                if (VeiculoRepositorio.ExisteVeiculoPorPlaca(placa))
                {
                    Console.WriteLine($"Veículo de Placa Nº: {placa} já está estacionado.");
                    return;
                }

                Veiculo veiculo = new()
                {
                    Placa = placa,
                };
                VeiculoRepositorio.AdicionarVeiculo(veiculo);

                Console.WriteLine($"A placa informada é válida! \nVeículo de placa Nº {placa}, foi estacionado com sucesso!!");
            }
            else
            {
                Console.WriteLine("O número da placa informada não é válida!");
            }

            Console.ReadKey();
            Console.Clear();
        }

        public static void ListarTodosOsVeiculos()
        {
            Console.Clear();
            var veiculos = VeiculoRepositorio.ListarTodosVeiculos();

            if (veiculos.Count != 0)
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"Vaga {i + 1} - Veículo de Placa Nº: {veiculos[i]} está estacionado!");
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
            Console.Write("Digite a placa do veículo estacionado: ");
            string placa = Console.ReadLine().ToUpper().Replace("-", "");

            if (placa.Length > 7 || placa.Length < 7)
            {
                Console.Clear();
                Console.WriteLine("A placa informada NÃO é válida!");
                return;
            }

            if (VeiculoRepositorio.ExisteVeiculoPorPlaca(placa))
            {
                Console.WriteLine($"Veículo de Placa Nº: {placa} está estacionado.");
            }
            else
            {
                Console.WriteLine($"O veículo informado NÃO está cadastrado em nosso sistema!");
            }
        }

        public static void EditarVeiculo()
        {
            Console.Clear();
            Console.Write("Digite a placa do veículo: ");
            string placa = Console.ReadLine().ToUpper().Replace("-", "");
            var veiculo = VeiculoRepositorio.ListarUmVeiculo(placa);

            Console.Write("Digite a placa correta do veículo para editar: ");
            string placaCorreta = Console.ReadLine().ToUpper().Replace("-", "");

            if (veiculo != null)
            {
                veiculo.Placa = placaCorreta;
                Console.WriteLine($"O veículo de placa Nº {placa}, foi atualizado para a placa Nº {placaCorreta}.");
            }
            else
            {
                Console.WriteLine("A placa informada não é válida!");
            }
        }

        public static void RemoverVeiculo()
        {
            Console.Clear();
            Console.Write("Digite a placa do veículo para remover: ");
            string placa = Console.ReadLine().ToUpper().Replace("-", "");

            Estacionamento estacionamento = new(precoInicial: 20.50M, precoPorHora: 2.50M);

            var veiculo = VeiculoRepositorio.ListarUmVeiculo(placa);

            if (veiculo != null)
            {
                Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado (no formato hh:mm): ");
                string[] partesHorasMin = Console.ReadLine().Split(':'); 

                if (partesHorasMin.Length == 2 && 
                int.TryParse(partesHorasMin[0], out int horas) && 
                int.TryParse(partesHorasMin[1], out int minutos) && 
                horas >= 0 && minutos >= 0 && 
                minutos < 60)
                {
                    decimal valorTotalGastoEstacionado;
                    if(minutos > 15)
                    {
                        valorTotalGastoEstacionado = estacionamento.CalculaPrecoInicialMaisPrecoPorHora(horas) + estacionamento.PrecoPorHora;
                    }
                    else
                    {
                        valorTotalGastoEstacionado = estacionamento.CalculaPrecoInicialMaisPrecoPorHora(horas);
                    }

                    VeiculoRepositorio.DeletarVeiculo(placa);
                    Console.WriteLine($"O veículo de Placa Nº: {placa}, foi removido e o preço total foi de: {valorTotalGastoEstacionado.ToString("C2")}");
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

            Console.ReadKey();
            Console.Clear();
        }

        private static bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa)) { return false; }

            if (placa.Length > 7 || placa.Length < 7) { return false; }

            if (char.IsLetter(placa, 4))
            {
                var padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                return padraoMercosul.IsMatch(placa);
            }
            else
            {
                var padraoNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
                return padraoNormal.IsMatch(placa);
            }
        }
    }
}
