
namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        public decimal PrecoInicial { get; set; }    
        public decimal PrecoPorHora { get; set; }
        public List<Veiculo> veiculos { get; set; }

        public Estacionamento(decimal precoInicial = 10.50M, decimal precoPorHora = 11.90M)
        {
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;
        }
    }
}