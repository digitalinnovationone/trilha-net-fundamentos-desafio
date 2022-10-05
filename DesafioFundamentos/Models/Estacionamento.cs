namespace DesafioFundamentos.Models
{
  public class Estacionamento
  {
    private decimal precoInicial = 0;
    private decimal precoPorHora = 0;
    public List<Veiculo> Veiculos = new List<Veiculo>();
    public static List<Veiculo> Relatorio = new List<Veiculo>();

    public Estacionamento(decimal precoInicial, decimal precoPorHora)
    {
      this.precoInicial = precoInicial;
      this.precoPorHora = precoPorHora;
    }


    public void AdicionarVeiculoMenu()
    {
      Console.WriteLine("Digite a placa do veículo para estacionar:");
      string placa = Console.ReadLine();
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


    public Decimal GeraPagamento(Veiculo veiculo, int totalHoras)
    {
      //valorTotal = (precoInicial + precoPorHora) * horas;
      //valorTotal = (2+4) * (8-2);
      //valortotal = 6 * 6 = 36

      Decimal valorTotal = (precoInicial + precoPorHora) * totalHoras;


      return valorTotal;

    }


    public void RemoverVeiculoMenu()
    {
      Console.WriteLine("Digite a placa do veículo para remover:");

      string placa = "";
      placa = Console.ReadLine();

      // Verifica se o veículo existe
      if (Veiculos.Any(x => x.Placa == placa.ToUpper()))
      {
        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");


        //"precoInicial + precoPorHora * horas" para a variável valorTotal                

        int horas = 0;
        decimal valorTotal = 0;
        horas = int.Parse(Console.ReadLine());
        valorTotal = (precoInicial + precoPorHora) * horas;


        // Veiculos.Remove(placa);

        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
      }
      else
      {
        Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
      }
    }

    public void ListarVeiculos()
    {
      // Verifica se há veículos no estacionamento
      if (Veiculos.Any())
      {
        Console.WriteLine("Os veículos estacionados são:");
        foreach (var item in Veiculos)
        {
          Console.WriteLine(item);
        }
      }
      else
      {
        Console.WriteLine("Não há veículos estacionados.");
      }
    }

  }
}
