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
            Console.WriteLine("Digite a placa do veículo para estacionar: ex.: ABC-123");
            placa = Console.ReadLine();
            
            if (string.IsNullOrEmpty(placa))
            {
                Console.WriteLine("Obrigatório inserir a placa do veículo!");
            }
            else
            {
                veiculos.Add(placa.ToUpper().Trim());
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = string.Empty;
            placa = Console.ReadLine();

            if (string.IsNullOrEmpty(placa))
            {
                Console.WriteLine("Obrigatório inserir a placa do veículo!");
            }
            else
            {
                // Verifica se o veículo existe
                if (veiculos.Any(x => x.ToUpper().Trim() == placa.ToUpper().Trim()))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    int horas = Convert.ToInt32(Console.ReadLine());
                    decimal valorTotal = precoInicial + precoPorHora * horas;

                    veiculos.Remove(placa.ToUpper().Trim());

                    Console.WriteLine($"O veículo {placa.ToUpper().Trim()} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
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
