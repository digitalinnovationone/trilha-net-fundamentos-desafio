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
            //Tarefa concluída!!!
            Console.Write("Digite a placa do veículo para estacionar: ");
            string placa = Console.ReadLine();
            veiculos.Add(placa);
            
        }

        public void RemoverVeiculo()
        {
            //Tarefa concluída!!!
            Console.Write("Digite a placa do veículo para remover: ");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                //Tarefa concluída!!!
                Console.Write("Quantidade de hora(s) que o veículo permaneceu estacionado: ");
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + (precoPorHora * horas); 
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido!");
                Console.WriteLine($"Preço total a pagar: R$ {valorTotal}");
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
                Console.WriteLine("Veículos estacionados:");
                int i = 1;
                foreach (var v in veiculos)
                {
                    //Tarefa concluída!!!
                    Console.WriteLine($"{i}º veículo: {v}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
