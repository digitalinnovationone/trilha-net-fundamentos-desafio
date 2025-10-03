using DesafioFundamentos.Helpers;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Veiculo> veiculos = new List<Veiculo>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = ValidacaoDeInputs.FormatarPlaca(Console.ReadLine());

            if (ValidacaoDeInputs.PlacaValida(placa))
            {
                veiculos.Add(new Veiculo(placa));
                Console.WriteLine("Veículo adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
            }

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = ValidacaoDeInputs.FormatarPlaca(Console.ReadLine());

            if (!ValidacaoDeInputs.PlacaValida(placa))
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
                return;
            }


            // Verifica se o veículo existe
            var veiculo = veiculos.FirstOrDefault(v => v.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase));

            if (veiculo != null)
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                string input = Console.ReadLine();

                if (!ValidacaoDeInputs.HoraValida(input))
                {
                    Console.WriteLine("Hora inválida. Tente novamente.");
                    return;
                }

                int horas = Convert.ToInt32(input);
                decimal valorTotal = precoInicial + (precoPorHora * horas);

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*

                //Mostrar quantas horas o veículo permaneceu estacionado 
                DateTime horaSaida = veiculo.HoraEntrada.AddHours(horas);

                veiculos.Remove(veiculo);

                Console.WriteLine($"O veículo {placa} foi removido.");
                Console.WriteLine($"Horário: de {veiculo.HoraEntrada:HH:mm} até {horaSaida:HH:mm}");
                Console.WriteLine($"Preço total: R$ {valorTotal}");
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
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"Placa: {veiculo.Placa} | Hora de entrada: {veiculo.HoraEntrada:HH:mm}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

    }
}
