using System.Text.RegularExpressions;

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
            string placa = string.Empty;
            // Verifica se a placa está no padrão mercosul, podendo ser informado com ou sem hífen
            string padraoPlaca = @"[A-Z]{3}-?[0-9][0-9A-Z][0-9]{2}";
            bool placaValida = false;

            Console.WriteLine("Digite a placa do veículo para estacionar:");

            do
            {
                placa = Console.ReadLine();

                if (!Regex.IsMatch(placa.ToUpper(), padraoPlaca))
                {
                    Console.WriteLine("Placa inválida. Digite novamente:");
                } else
                {
                    placaValida = true;
                }

            } while (!placaValida);

            veiculos.Add(placa.ToUpper());
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                uint horas;
                bool sucesso = false;

                // Se não for possível converter a entrada para um int unsigned, será solicitado para digitar novamente a quantidade de horas.
                do
                {
                    sucesso = uint.TryParse(Console.ReadLine(), out horas);
                    if (!sucesso)
                    {
                        Console.WriteLine("Número inválido.\nDigite novamente a quantidade de horas que o veículo permaneceu estacionado:");
                    }
                } while (!sucesso);

                decimal valorTotal = precoInicial + (precoPorHora * horas);

                veiculos.Remove(placa);

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
