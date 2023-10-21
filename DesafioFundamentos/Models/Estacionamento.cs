using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            if(Regex.IsMatch(placa, "\\w{3}-\\d{4}") || Regex.IsMatch(placa, "\\w{3}\\d{1}\\w{1}\\d{2}")){
                veiculos.Add(placa.ToUpper());
            }
            else {
                 Console.WriteLine("Placa inválida, favor inserir em um dos padões: XXX-1111 ou XXX1X11");
            }
            
        }

        public void RemoverVeiculo()
        {
            if (veiculos.Any()){
                Console.WriteLine("Digite a placa do veículo para remover:");
                string placa = Console.ReadLine();
                // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                bool parser = decimal.TryParse(Console.ReadLine(), out decimal horas);
                decimal valorTotal = 0; 
                if(parser){
                    valorTotal = precoInicial + precoPorHora * horas;
                    veiculos.Remove(placa.ToUpper());
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: {valorTotal:C2}");
                }        
                else{
                    Console.WriteLine("Horário invalido");
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
                
            }
            else{
                Console.WriteLine("Não há veículos estacionados.");
            }
            
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                if(veiculos.Any()){
                    foreach(string veiculo in veiculos){
                    Console.WriteLine(veiculo);
                }
                }
                else{
                    Console.WriteLine("O estacionamento está vazio!");
                }
                
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
