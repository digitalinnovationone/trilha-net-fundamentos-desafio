using System.Text.RegularExpressions;
using DesafioFundamentos.Models;
using Repository;

namespace Services
{
    public class VeiculoService
    {
        public static void AdicionarVeiculo()
        {
            // Solicita ao usuário que digite a placa do veículo
            Console.Clear();
            Console.Write("Digite a placa do veículo para estacionar: ");
            string placa = Console.ReadLine().ToUpper();

            // Valida a placa do veículo
            if (ValidarPlaca(placa))
            {
                // Verifica se o veículo já está estacionado
                if (VeiculoRepositorio.ConsultarVeiculo(placa))
                {
                    Console.WriteLine($"Veículo de Placa: {placa}, já está estacionado.");
                    return;
                }

                // Cria um novo objeto Veiculo e o adiciona ao repositório
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

            // Exibe um loop para adicionar ou não outro veículo
            Console.ReadKey();
            Console.Clear();
            MenuCase menuCase = new MenuCase();
            menuCase.ExibirMenuCase();
        }

        // Método para remover um veículo do estacionamento
        public static void RemoverVeiculo()
        {
            // Solicita ao usuário que digite a placa do veículo a ser removido
            Console.Clear();
            Console.Write("Digite a placa do veículo para remover: ");
            string placa = Console.ReadLine().ToUpper();

            // Cria uma instância de Estacionamento
            Estacionamento estacionamento = new Estacionamento(10.50M, 10.50M);

            // Consulta o veículo no repositório
            var veiculo = VeiculoRepositorio.ConsultarUm(placa);

            // Verifica se o veículo está estacionado
            if (veiculo != null)
            {
                // Solicita ao usuário a quantidade de horas que o veículo permaneceu estacionado
                Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                int horas = int.Parse(Console.ReadLine());

                // Calcula o valor total com base nas horas e remove o veículo do repositório
                decimal valorTotal = estacionamento.CalculaPrecoInicialMaisPrecoPorHora() * horas;
                VeiculoRepositorio.Delete(placa);

                Console.WriteLine($"O veículo de Placa: {placa}, foi removido e o preço total foi de: R$ {valorTotal.ToString("F2")}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }

            // Exibe um loop para Remover ou não outro veículo
            Console.ReadKey();
            Console.Clear();
            MenuCase menuCase = new MenuCase();
            menuCase.ExibirMenuCase();
        }

        // Método para listar todos os veículos estacionados
        public static void ListarVeiculos()
        {
            // Consulta todos os veículos no repositório
            var veiculos = VeiculoRepositorio.ConsultarTodos();

            // Verifica se há veículos estacionados
            if (veiculos.Any())
            {
                Console.Clear();
                Console.WriteLine("Os veículos estacionados são:");

                // Itera sobre os veículos e exibe suas informações
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

        // Método para validar a placa do veículo
        public static bool ValidarPlaca(string placa)
        {

            // Verifica se a placa é nula ou consiste apenas em espaços em branco
            if (string.IsNullOrWhiteSpace(placa)) { return false; }

            // Verifica se a placa tem mais de 8 caracteres
            if (placa.Length > 8) { return false; }

            // Remove caracteres de formatação da placa
            placa = placa.Replace("-", "").Trim();

            // Verifica se a placa segue o padrão do Mercosul ou padrão normal
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