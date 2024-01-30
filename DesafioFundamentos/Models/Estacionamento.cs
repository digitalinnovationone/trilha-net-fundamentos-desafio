namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        public decimal PrecoInicial { get; private set; }    
        public decimal PrecoPorHora { get; private set; }

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