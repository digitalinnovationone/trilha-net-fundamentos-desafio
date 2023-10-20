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
            // Implementado!!!!!
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            veiculos.Add (placa);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            //  // Implementado!!!!!
            string placa = Console.ReadLine();

            //  // Implementado!!!!!


            if 
            
            (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                 // Implementado!!!!! 
                if
                
                (int.TryParse(Console.ReadLine(), out int horas))

                {
                    decimal valorTotal = precoInicial + precoPorHora * horas; veiculos.Remove(placa);
                
                 Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");

                }  
                             
             // Implementado!!!!!

            }

                        else
            {               
             Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");

            }
        }

        public void ListarVeiculos()
        {
             // Implementado!!!!!
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(var veiculo in veiculos)

              {                
                 Console.WriteLine(veiculo);
              }                // Implementado!!!!!
            }

            else          
             {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
