using System.Text.RegularExpressions;
using DesafioFundamentos.Models;
using Repository;

namespace Services
{
    public class VeiculoService
    {
        public static void AdicionarVeiculo()
        {
            Console.Write("Digite a placa do veículo para estacionar: ");
            string placa = Console.ReadLine().ToUpper();

            if (ValidarPlaca(placa))
            {
                if (VeiculoRepositorio.ConsultarVeiculo(placa))
                {
                    Console.WriteLine($"Veículo de Placa: {placa}, já está estacionado.");
                    return;
                }
                Veiculo veiculo = new Veiculo()
                {
                    Placa = placa,
                };

                VeiculoRepositorio.AdicionarVeiculo(veiculo);
                Console.WriteLine("A placa informada é válida! \nVeículo estacionado com sucesso!!");
            }
            else
            {
                Console.WriteLine("A placa informada NÃO é válida!");
            }
        }

        public static void RemoverVeiculo()
        {
            Console.Write("Digite a placa do veículo para remover: ");
            string placa = Console.ReadLine().ToUpper();

            Estacionamento estacionamento = new Estacionamento();
            var veiculo = VeiculoRepositorio.ConsultarUm(placa);
            if (veiculo != null)
            {
                Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                int horas = int.Parse(Console.ReadLine());

                decimal valorTotal = (estacionamento.PrecoInicial + estacionamento.PrecoPorHora) * horas;
                VeiculoRepositorio.Delete(placa);

                Console.WriteLine($"O veículo de Placa: {placa}, foi removido e o preço total foi de: R$ {valorTotal.ToString("F2")}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public static void ListarVeiculos()
        {
            var veiculos = VeiculoRepositorio.ConsultarTodos();

            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                int contadorVeiculo = 1;
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"Vaga {contadorVeiculo} - Veículo de Placa: {veiculo.ToString()} está estacionado!");
                    contadorVeiculo++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public static bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa)) { return false; }

            if (placa.Length > 8) { return false; }

            placa = placa.Replace("-", "").Trim();

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