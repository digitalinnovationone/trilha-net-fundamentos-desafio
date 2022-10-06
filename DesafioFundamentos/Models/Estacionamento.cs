namespace DesafioFundamentos.Models
{
  public class Estacionamento
  {
    private decimal precoInicial = 0;
    private decimal precoPorHora = 0;
    public static List<Veiculo> Veiculos = new List<Veiculo>();
    public static List<Veiculo> Relatorio = new List<Veiculo>();

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
      this.precoInicial = precoInicial;
      this.precoPorHora = precoPorHora;
    }


    

    public void AdicionarVeiculo(string placa, int horaEntrada)
    {
      Veiculo veiculo = new Veiculo(placa.ToUpper(), horaEntrada);
      Veiculos.Add(veiculo);
    }

    public Veiculo BuscarVeiculo(string placa)
    {

      if (!Veiculos.Any(v => v.Placa == placa.ToUpper()))
        return null;
      return Veiculos.FirstOrDefault(v => v.Placa == placa.ToUpper());
    }

    public void RemoverVeiculo(Veiculo veiculo, int horaSaida)
    {
      if (veiculo != null)
      {
        veiculo.AddSaida(8);
        Relatorio.Add(veiculo);
        Veiculos.Remove(veiculo);
      }
      else
      {
        throw new Exception("Veiculo chegou nulo");
      }
    }

    public int CalculaHoras(Veiculo veiculo)
    {
      return veiculo.HoraSaida - veiculo.HoraEntrada;
    }


    public Decimal GeraPagamento(Veiculo veiculo, int totalHoras)
    {
      //valorTotal = (precoInicial + precoPorHora) * horas;
      //valorTotal = (2+4) * (8-2);
      //valortotal = 6 * 6 = 36

      Decimal valorTotal = (precoInicial + precoPorHora) * totalHoras;


      return valorTotal;

    }


    

    

  }
}
