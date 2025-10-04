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
            //Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            try
            {
                string placa = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(placa))
                {
                    throw new Exception("A placa não pode ser vazia. Tente novamente.");
                }

                veiculos.Add(placa);

                Console.WriteLine($"O veículo com a placa {placa} foi estacionado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
            
           
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            //Pedir para o usuário digitar a placa e armazenar na variável placa
          
            string placa = "";
            placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                //Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                //Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
               
                int horas = 0;
                decimal valorTotal = 0;

                try
                {
                    horas = int.Parse(Console.ReadLine());

                    valorTotal = precoInicial + precoPorHora * horas;

                    //Remover a placa digitada da lista de veículos
                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo com placa {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro para as horas.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("O número de horas informado é muito grande. Por favor, digite um valor menor.");
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
                //Realizar um laço de repetição, exibindo os veículos estacionados
                
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
