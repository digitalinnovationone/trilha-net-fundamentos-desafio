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
            Console.WriteLine("Digite a placa do veículo para estacionar: ");
            string novaPlaca = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(novaPlaca))
            {
                Console.WriteLine("A placa está vazia!\n");
                Console.WriteLine("Se deseja tentar adicionar novamente, aperte 1: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        AdicionarVeiculo();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Voltando para o menu...");
                        return;
                }
            }

            veiculos.Add(novaPlaca.ToUpper());

            Console.Clear();
            Console.WriteLine("Veículo adicionado com sucesso!");
            Thread.Sleep(1000);
        }

        public void RemoverVeiculo()
        {
            if (!veiculos.Any())
            {
                Console.WriteLine("Não há veículos cadastrados");
                Console.WriteLine("Voltando para o menu...");
                return;
            }

            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();

            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Voltando para o menu...");
                return;
            }

            // Verifica se o veículo existe
            if (veiculos.Any(x => x == placa))
            {
                decimal horas = 0;
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                if (decimal.TryParse(Console.ReadLine(), out horas)) { }

                decimal valorTotal = precoInicial + precoPorHora * horas;

                if (veiculos.Remove(placa))
                {
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                Thread.Sleep(300);
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (var placa in veiculos)
                {
                    Console.WriteLine($"Placa: {placa}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
