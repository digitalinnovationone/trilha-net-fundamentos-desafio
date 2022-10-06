using DesafioFundamentos.Models;

namespace DesafioFundamentos.Controllers
{
    public class MainMenu
    {
        private readonly Estacionamento _estacionamento;

        public MainMenu(Estacionamento estacionamento)
        {
            _estacionamento = estacionamento;
        }
        
        public  void AdicionarVeiculoMenu()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            Console.WriteLine("Digite a hora atual (int):");
            int horaEntrada = int.Parse(Console.ReadLine());

            
            _estacionamento.AdicionarVeiculo(placa, horaEntrada);
            
        }

        public void RemoverVeiculoMenu()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();
            
            var veiculo = _estacionamento.BuscarVeiculo(placa);
            if (veiculo != null)
            { 
               Console.WriteLine("Digite a Hora de saida(int):");
               int horaSaida = int.Parse(Console.ReadLine());
               _estacionamento.RemoverVeiculo(veiculo,horaSaida); 
               int totalhoras = _estacionamento.CalculaHoras(veiculo);
               decimal totalPagar = _estacionamento.GeraPagamento(veiculo, totalhoras);
               Console.WriteLine($"O veiculo {veiculo.Placa} ficou estacionado por {totalhoras} horas e deve R$ {totalPagar}");
            }
            else
            {
                Console.WriteLine("Veiculo não encontrado");
            }
            


        }

        public void ListarVeiculosMenu()
        {
            var veiculos = Estacionamento.Veiculos;
            
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var item in veiculos)
                {
                    Console.WriteLine(item.Placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}