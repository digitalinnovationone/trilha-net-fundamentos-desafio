namespace DesafioFundamentos.Models{
    public class Veiculo
    {
        private string _placa;
        public string Placa{
            get { return _placa; }
            set { _placa = value.ToUpper(); }
        }

        public Veiculo(string placa){
            Placa = placa;
        }
    }
}