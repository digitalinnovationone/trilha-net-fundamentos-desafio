namespace DesafioFundamentos.Models
{
    public class Veiculo
    {
        public string Placa { get; set; }

        public Veiculo(string placa)
        {
            Placa = placa;
        }

        public override string ToString()
        {
            return Placa;
        }
    }
}