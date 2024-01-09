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

        private string VerificaPlaca()
        {
            string placa = "";
            bool primeiraTentativa = true;
            do
            {
                if (!primeiraTentativa)
                {
                    Console.WriteLine("PLACA INVÁLIDA! DIGITE UMA PLACA COM 7 DÍGITOS:");
                }
                Console.WriteLine("Digite a placa do veículo (7 DÍGITOS):");
                placa = Console.ReadLine();
            } while (placa.Length != 7);

            return placa.ToUpper();
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"

            Console.WriteLine("------ ADICIONAR VEICULO ------");
            veiculos.Add(VerificaPlaca());

        }

        public void RemoverVeiculo()
        {
            // Pedir para o usuário digitar a placa e armazenar na variável placa
            Console.WriteLine("------ REMOVER VEICULO ------");
            // veiculos.Remove(VerificaPlaca().ToUpper());
            string placa = VerificaPlaca();

            // string placa;
            // Verifica se o veículo existe
            if (veiculos.Any(x => x == placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                int horas = 0;
                decimal valorTotal = 0;
                Console.WriteLine("Digite o tempo de permanencia em horas");
                horas = Convert.ToInt32(Console.ReadLine());
                valorTotal = precoInicial + precoPorHora * horas;


                // TODO: Remover a placa digitada da lista de veículos
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
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                int ordem = 1;
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"Nº{ordem} - Placa: {veiculo}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
