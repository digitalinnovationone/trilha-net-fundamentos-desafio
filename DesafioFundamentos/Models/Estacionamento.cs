namespace DesafioFundamentos.Models{
    public class Estacionamento{
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora){
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo(){
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            veiculos.Add(Console.ReadLine());
        }

        public void RemoverVeiculo(){
            if (veiculos != null && veiculos.Any()){
                ListarVeiculos();
                int horas = 0;
                decimal valorTotal = 0;
                Console.WriteLine("Digite a placa do veículo para remover:");
                string placa = (Console.ReadLine());
                Console.WriteLine("Informe a quantidade de horas em que o veículo permanecel no estacionamento: ");
                horas = int.Parse(Console.ReadLine());
                valorTotal = precoInicial + (horas * precoPorHora);
                Console.WriteLine($"O preço a ser pago é de: R$ {valorTotal}");
                veiculos.Remove(placa);
                Console.WriteLine("O valor foi pago e o veículo removido.");
            }
            else{
                Console.WriteLine("Não existem veículo cadastrados.");
            }
        }

        public void ListarVeiculos(){
            // Verifica se há veículos no estacionamento
            if (veiculos.Any()){
                Console.WriteLine("Os veículos estacionados são:");
                int indice = 1;
                foreach (var placa in veiculos){
                    Console.WriteLine($"[ {indice} ] - {placa}");
                    indice++;
                }
            }
            else{
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}