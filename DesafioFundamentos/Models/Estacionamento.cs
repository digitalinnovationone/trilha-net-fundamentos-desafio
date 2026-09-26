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
            do
            {
                // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
                // *IMPLEMENTE AQUI*
                Console.WriteLine("Digite a placa do veículo para estacionar:");

                string placa = Console.ReadLine();

                if(placa is "" or null)
                {
                    Console.Clear();
                    Console.WriteLine("Há um problema com a placa do veículo. Por favor, verifique e tente novamente.");
                    Console.WriteLine("Pressione uma tecla para tentar novamente.");
                    Console.ReadKey();
                    continue;
                }

                veiculos.Add(placa);
                Console.WriteLine($"O veículo {placa} foi adicionado à lista!");
                break;
            } while(true);
        }

        public void RemoverVeiculo()
        {
            string placa;

            do {
                Console.WriteLine("Digite a placa do veículo para remover:");

                // Pedir para o usuário digitar a placa e armazenar na variável placa
                // *IMPLEMENTE AQUI*
                placa = Console.ReadLine();

                if(placa is "" or null)
                {
                    Console.Clear();
                    Console.WriteLine("Há um problema com a placa do veículo. Por favor, verifique e tente novamente.");
                    Console.WriteLine("Pressione uma tecla para tentar novamente.");
                    Console.ReadKey();
                    continue;
                }

                break;
            } while(true);

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                do
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                    // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                    // *IMPLEMENTE AQUI*
                    int horas = 0;
                    decimal valorTotal = 0; 

                    int.TryParse(Console.ReadLine(), out horas);

                    if(horas <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("A quantidade de horas informadas deve ser um número maior do que zero!");
                        continue;
                    }

                    valorTotal = precoInicial + precoPorHora * horas;

                    // TODO: Remover a placa digitada da lista de veículos
                    // *IMPLEMENTE AQUI*
                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                    break;
                } while(true);
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
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                foreach(string veiculo in veiculos)
                {
                    Console.WriteLine($"Veículo {veiculos.IndexOf(veiculo) + 1}: {veiculo}.");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
