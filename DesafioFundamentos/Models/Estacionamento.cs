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
            Console.Clear();
            Console.WriteLine("=========================================================================");
            Console.WriteLine("|                    REGISTRAR CARRO NO ESTACIONAMENTO                  |");
            Console.WriteLine("=========================================================================\n");
           
            Console.WriteLine("Digite a placa do veículo:");
            string placaAdicionar = Console.ReadLine().ToUpper();
            veiculos.Add(placaAdicionar);

            Console.WriteLine($"Veiculo de placa: {placaAdicionar} foi cadastrado com sucesso!\n");
        }

        public void RemoverVeiculo()
        {   
            Console.Clear();

            Console.WriteLine("=========================================================================\n");
            Console.WriteLine("Digite a placa do veículo para remoção:");
           

            string placa =  Console.ReadLine().ToUpper();

            if (veiculos.Any(x => x.ToUpper() == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = int.Parse(Console.ReadLine());
                decimal valorTotal = precoInicial + (precoPorHora * horas); 
                veiculos.Remove(placa);
                Console.WriteLine($"O veículo de placa: {placa} foi removido e o preço total foi de: R$ {Math.Round(valorTotal,2)}");
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
                Console.Clear();
                Console.WriteLine("=========================================================================");
                Console.WriteLine("|                            LISTA DE VEÍCULOS                          |");
                Console.WriteLine("=========================================================================");
                Console.WriteLine($"                 Quantidade de veículos estacionados: {veiculos.Count}");
                Console.WriteLine("=========================================================================\n");
                Console.WriteLine("Placas dos veículos estacionados:\n");

                foreach(string carros in veiculos)
                {
                    Console.WriteLine($" PLACA: {carros}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public void ConsultarTabelaPreco()
        {

            Console.Clear();
            Console.WriteLine("=========================================================================");
            Console.WriteLine("|                      CONSULTA TABELA DE PRECO                         |");
            Console.WriteLine("=========================================================================\n");

            Console.WriteLine($"Valor para  entrada: {precoInicial}");
            Console.WriteLine($"Valor da Hora: {precoPorHora}");

            Console.WriteLine("\nDigite:\n 1 - Auterar tabela de valores\n 2 - Voltar menu inicial");

            switch(Console.ReadLine())
            {
                case "1":
                    AtualizarTabela();
                    break;

                case "2":
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Por favor digite um valor válido...");
                    Console.WriteLine("Digite algo para continuar...");
                    Console.ReadLine();
                    ConsultarTabelaPreco();
                    break;
            }

        }

        public void AtualizarTabela()
        {   
            Console.Clear();
            Console.WriteLine("=========================================================================");
            Console.WriteLine("|                          ATUALIZANDO VALORES                          |");
            Console.WriteLine("=========================================================================\n");

            Console.WriteLine($"O Valor para entrada atual é {precoInicial}\nDigite o novo valor:");
            precoInicial = decimal.Parse(Console.ReadLine());
            Console.WriteLine($"O Valor da hora atual é {precoPorHora}\nDigite o novo valor:");
            precoPorHora = decimal.Parse(Console.ReadLine());
        }
    }
}
