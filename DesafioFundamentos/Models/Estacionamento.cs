namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private readonly decimal precoInicial = 0;
        private readonly decimal precoPorHora = 0;
        private readonly List<string> veiculos = new ();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            var placa = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(placa))
            {
                Console.WriteLine("Placa inválida!");
                return;
            }
            veiculos.Add(placa.ToUpper());
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine().ToUpper();

            if (veiculos.Any(x => x.ToUpper() == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                if (!int.TryParse(Console.ReadLine(), out int horas))
                {
                    horas = 0;
                }

                decimal valorTotal = precoInicial + precoPorHora * horas; 

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
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                foreach (string veiculo in veiculos)
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
