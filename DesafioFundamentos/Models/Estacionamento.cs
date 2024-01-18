namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal PrecoInicial { get; }    
        private decimal PrecoPorHora { get; }

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