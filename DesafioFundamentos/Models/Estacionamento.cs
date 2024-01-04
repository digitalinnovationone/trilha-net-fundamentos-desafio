
namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal PrecoInicial { get; set; }    
        private decimal PrecoPorHora { get; set; }
        public List<Veiculo> veiculos { get; set; }

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;
        }

        public decimal CalculaPrecoInicialMaisPrecoPorHora()
        {
            return PrecoInicial + PrecoPorHora; 
        }
    }
}