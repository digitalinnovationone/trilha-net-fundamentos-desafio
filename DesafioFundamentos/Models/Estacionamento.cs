namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;

        private string placa = string.Empty;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            placa = Console.ReadLine().Trim().ToUpper();

            if (string.IsNullOrEmpty(placa))
            {
                Console.WriteLine("Preenchimento obrigatório. Por favor, informe a placa do veiculo. Ex: xxx1234");
                return;
            }

            if (veiculos.Any(veiculo => veiculo.Equals(placa)))
            {
                Console.WriteLine($"O veiculo de placa {placa} já encontra-se no estacionamento");
                return;
            }   

            if (placa.Length == 7)
            {
                veiculos.Add(placa);
                Console.WriteLine($"O veiculo de placa {placa} foi estacinado com sucesso");
            }
            else
            {
                Console.WriteLine($"A placa do veiculo precisa ter 7 caracteres. Ex: xxx1234");
            }
        }

        public void RemoverVeiculo()
        {
            placa = "";

            Console.WriteLine("Digite a placa do veículo para remover:");
 
            placa = Console.ReadLine().Trim().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = 0;
                decimal valorTotal = 0;
                string input = Console.ReadLine();

                if (int.TryParse(input, out horas))
                {
                    valorTotal = (precoPorHora * horas) + precoInicial;
                    veiculos.Remove(placa);
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: {valorTotal:C}");
                }
                else
                {
                    Console.WriteLine("Digite apenas números inteiros na quantidade de horas");
                }
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

                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine(veiculos[i]);
                }

            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
