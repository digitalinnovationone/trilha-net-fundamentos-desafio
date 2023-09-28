namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.Clear();
            Console.Write("Digite a placa do veículo para estacionar: ");
            string placa = Console.ReadLine();
            char[] arrayPlaca = placa.ToArray();

            if(string.IsNullOrEmpty(placa) || !arrayPlaca.Length.Equals(7)) 
            {
                Console.WriteLine("A placa deve ter 7 digitos,\n por favor tente novamente!\n");
                return;
            }

            DateTime datahora = DateTime.Now;
            Console.WriteLine($" Data e horário de entrada: {datahora}\n Apresente o ticket na saída.\n");

            veiculos.Add(
                new Veiculo
                {
                    Placa = placa.ToUpper(),
                    DataHoraEntrada = datahora
                }
            );
        }

        public void RemoverVeiculo()
        {
            Console.Write("Digite a placa do veículo para remover: ");
            
            string placa = Console.ReadLine();

            if (veiculos.Any(v => v.Placa == placa.ToUpper()))
            {
                Veiculo veiculo =  veiculos.FirstOrDefault(v => v.Placa == placa.ToUpper());
                TimeSpan tempoDecorrido = DateTime.Now - veiculo.DataHoraEntrada;

                Console.WriteLine($"O veículo permaneceu estacionado por {tempoDecorrido}");

                int horas = tempoDecorrido.Hours;
                decimal valorTotal = 0; 

                if(horas == 0 && tempoDecorrido.Minutes < 15) 
                {
                    valorTotal = precoInicial + precoPorHora * 0.5m;
                }
                else 
                {
                    if(horas < 1)
                    {
                        valorTotal = precoInicial + precoPorHora;
                    } 
                    else
                    {
                        valorTotal = precoInicial + precoPorHora * horas;
                    }
                }

                try
                {
                    if(veiculos.Remove(veiculo))
                    {
                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:0.00}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro ao tentar remover o veículo {placa}\n{e}");   
                }
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
                Console.WriteLine("Os veículos estacionados são:\n");

                Console.WriteLine("\tPlaca\t\tEntrada\t\t\tTempo Decorrido");
                foreach(var veiculo in veiculos) 
                {
                    Console.WriteLine($"\t{veiculo.Placa}\t\t{veiculo.DataHoraEntrada}\t{DateTime.Now - veiculo.DataHoraEntrada}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
