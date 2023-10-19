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
                                 
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            veiculos.Add (Console.ReadLine());  
                    
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            veiculos.Remove(Console.ReadLine());      
            string placa = "";
           

           
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))

            {
                 int horas = 0;

                 decimal valorTotal = 0;
                
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = int.Parse(Console.ReadLine());
                
                valorTotal = precoInicial + precoPorHora * horas;

                                
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
            /
            if (veiculos.Any())
            for (int contador = 0; contador < veiculos.Count; contador++)
            {
                
                Console.WriteLine($"Os veículos estacionados são:{contador} - {veiculos[contador]}");
                
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}