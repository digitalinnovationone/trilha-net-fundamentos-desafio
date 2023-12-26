namespace DesafioEstacionamento.Models
{
    public class Estacionamento
    {
        public decimal ValorInicial { get; private set; }     
        public decimal ValorHora { get; private set; } 
        private List<Veiculo> veiculos; 

        public Estacionamento()
        {
            veiculos = new List<Veiculo>();
        }

        public void AdicionarValorInicial(decimal valorInicial)
        {
            ValidarValor(valorInicial);
            ValorInicial = valorInicial;
        }

        public void AdicionarValorHora(decimal valorHora)
        {
            ValidarValor(valorHora);
            ValorHora = valorHora;
        }

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            veiculos.Add(veiculo);
        }

        public void RemoverVeiculo(Veiculo veiculo)
        {
            veiculos.Remove(veiculo);
        }

        public List<Veiculo> ListarVeiculos()
        {
            Validarveiculos();
            return veiculos;
        }

        public Veiculo SelecionarVeiculo(string placa)
        {
            Validarveiculos();

            return veiculos.FirstOrDefault(v => v.Placa == placa);
        }

        private void ValidarValor(decimal valor)
        {
            if (valor < 0)
                Console.WriteLine("Informe um valor válido");
        }

        

        private void Validarveiculos()
        {
            if (!veiculos.Any())
                throw new Exception("Nenhum veículos no estacionamento");
        }
    }
}