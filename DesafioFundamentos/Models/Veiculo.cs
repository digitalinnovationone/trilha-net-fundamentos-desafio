
namespace DesafioFundamentos.Models
{
    public class Veiculo
    {
        public string Placa { get; set; }

        // Tranforma o objeto em um texto
        public override string ToString()
        {
            return Placa;
        }
    }
}