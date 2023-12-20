using System;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal PrecoInicial { get; set; }    
        private decimal PrecoPorHora { get; set; }
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;
        }

        private void AdicionarVeiculo()
        {
            Console.Write("Digite a placa do veículo para estacionar: ");
            string placa = Console.ReadLine();

            if (veiculos.Contains(placa))
            {
                Console.WriteLine($"Veículo de Placa: {placa}, já está estacionado.");
                return;
            }

            if (ValidarPlaca(placa))
            {
                veiculos.Add(placa);
                Console.WriteLine("A placa informada é válida! \nVeículo estacionado com sucesso!!");
            }
            else
            {
                Console.WriteLine("A placa informada NÃO é válida!");
            }
        }

        private void RemoverVeiculo()
        {
            Console.Write("Digite a placa do veículo para remover: ");
            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                int horas = int.Parse(Console.ReadLine());

                decimal valorTotal = (PrecoInicial + PrecoPorHora) * horas;
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo de Placa: {placa}, foi removido e o preço total foi de: R$ {valorTotal.ToString("F2")}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        private void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                int contadorVeiculo = 1;
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"Vaga {contadorVeiculo} - Veículo de Placa: {veiculo.ToUpper()} está estacionado!");
                    contadorVeiculo++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private static bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa)) { return false; }

            if (placa.Length > 8) { return false; }

            placa = placa.Replace("-", "").Trim();

            /*
                Verifica se o caractere da posição 4 é uma letra, se sim, aplica a validação para o formato de placa do Mercosul,
                senão, aplica a validação do formato de placa padrão normal.
             */
            if (char.IsLetter(placa, 4))
            {
                //Verifica se a placa está no formato: três letras, um número, uma letra e dois números.
                // Padrão de Placa do Mercosul --> DVA-8F14
                var padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                return padraoMercosul.IsMatch(placa);
            }
            else
            {
                // Verifica se os 3 primeiros caracteres são letras e se os 4 últimos são números.
                // Padrão de Placa Normal --> BQD-7012
                var padraoNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
                return padraoNormal.IsMatch(placa);
            }
        }

        public void Menu()
        {
            bool exibirMenu = true;
            while (exibirMenu)
            {
                Console.Clear();
                Console.WriteLine("Digite a sua opção:");
                Console.WriteLine("1 - Cadastrar veículo");
                Console.WriteLine("2 - Remover veículo");
                Console.WriteLine("3 - Listar veículos");
                Console.WriteLine("4 - Encerrar");

                switch (Console.ReadLine())
                {
                    case "1":
                        AdicionarVeiculo();
                        break;
                    case "2":
                        RemoverVeiculo();
                        break;
                    case "3":
                        ListarVeiculos();
                        break;
                    case "4":
                        exibirMenu = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadLine();
            }
        }
    }
}