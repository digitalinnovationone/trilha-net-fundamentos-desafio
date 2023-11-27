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
            // *IMPLEMENTE AQUI*
            //Feito
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string Placa = Convert.ToString(Console.ReadLine());
            this.veiculos.Add(Placa);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            
            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            //Feito
            string placa = Convert.ToString(Console.ReadLine());
            int index = this.veiculos.IndexOf(placa);

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                
                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado, FEITO
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal  FEITO              
                // *IMPLEMENTE AQUI*
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = Convert.ToInt32(Console.ReadLine());
                
                decimal valorTotal = this.precoInicial+(this.precoPorHora*horas); 

                // TODO: Remover a placa digitada da lista de veículos FEITO
                // *IMPLEMENTE AQUI*
                this.veiculos.Remove(veiculos[index]);

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
                // *IMPLEMENTE AQUI* FEITO
                for(int i=0; i<this.veiculos.Count; i++){
                    Console.WriteLine($"N: {i} - Placa: {this.veiculos[i]} \n");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}