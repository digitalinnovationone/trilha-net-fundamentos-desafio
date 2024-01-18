namespace DesafioFundamentos.Models
{
    public class Veiculo
    {
        public string Placa { get; set; }

        public override string ToString()
        {
            return Placa;
        }
    }
}