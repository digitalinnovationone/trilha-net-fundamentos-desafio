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
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (string.IsNullOrEmpty(placa))
            {
                Console.WriteLine("Não são permitidas placas vazias!\n");
            }
            else if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Essa placa já foi cadastrada anteriormente!\n");
            }
            else
                veiculos.Add(placa);
        }

        public void RemoverVeiculo()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Digite a placa do veículo para remover:");

                // Pedir para o usuário digitar a placa e armazenar na variável placa
                string placa = "";
                placa = Console.ReadLine();

                // Verifica se o veículo existe
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                    // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                    // *IMPLEMENTE AQUI*
                    int horas = 0;
                    decimal valorTotal = 0;
                    string horasInseridas = Console.ReadLine();

                    bool conversaoBemSucedida = int.TryParse(horasInseridas, out horas);

                    if (!conversaoBemSucedida)
                    {
                        Console.WriteLine("Insira uma quantidade inteira de horas!\n");
                    }
                    else
                    {
                        valorTotal = precoInicial + (horas * precoPorHora);

                        // TODO: Remover a placa digitada da lista de veículos
                        // *IMPLEMENTE AQUI*
                        veiculos.Remove(placa);
                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                    }
                }
                else
                {
                    throw new Exception("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
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
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"    - Veículo {i+1}: placa {veiculos[i]}");
                }
            }
            else 
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
