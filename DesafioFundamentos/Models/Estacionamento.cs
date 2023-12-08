namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        public decimal PrecoInicial
        {
            get => precoInicial;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Preço inicial não pode ser negativo.");

                precoInicial = value;
            }
        }
        public decimal PrecoPorHora
        {
            get => precoPorHora;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Preço por hora não pode ser negativo.");
            }
        }

        private List<Veiculo> veiculos = new List<Veiculo>
        {
            new Veiculo("COY-8123"),
            new Veiculo("MIC-5465"),
            new Veiculo("abc-9782"),
            new Veiculo("mec-9813"),
        };

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            Veiculo veiculo = new Veiculo(placa);
            veiculos.Add(veiculo);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();
            int indiceVeiculoParaRemover = veiculos.FindIndex(
                v => v.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase)
            );

            // Verifica se o veículo existe
            if (indiceVeiculoParaRemover != -1)
            {
                Console.WriteLine(
                    "Digite a quantidade de horas que o veículo permaneceu estacionado:"
                );

                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal

                decimal valorTotal = 0;
                string txtHoras = Console.ReadLine();

                if (UInt16.TryParse(txtHoras, out UInt16 horas))
                    valorTotal = PrecoInicial + (PrecoPorHora * horas);
                else
                    throw new ArgumentException("A quantidade de horas deve ser uma valor válido.");

                veiculos.RemoveAt(indiceVeiculoParaRemover);

                Console.WriteLine(
                    $"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}"
                );
            }
            else
            {
                Console.WriteLine(
                    "Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente"
                );
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Count == 0)
                Console.WriteLine("Não há veículos estacionados.");
            else
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (Veiculo veiculo in veiculos)
                    Console.WriteLine(veiculo);
            }
        }
    }
}
