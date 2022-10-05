namespace DesafioFundamentos.Models
{
  public class Estacionamento
  {
    private decimal precoInicial = 0;
    private decimal precoPorHora = 0;
    public List<Veiculo> veiculos = new List<Veiculo>();

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

    public Veiculo AdicionarVeiculo(string placa, int horaEntrada)
    {
      Veiculo veiculo = new Veiculo(placa.ToUpper(), horaEntrada);
      veiculos.Add(veiculo);
      return veiculo;
      //veiculos.Add(placa);
    }

    public void RemoverVeiculo()
    {
      Console.WriteLine("Digite a placa do veículo para remover:");

      string placa = "";
      placa = Console.ReadLine();

      // Verifica se o veículo existe
      if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
      {
        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");


        //"precoInicial + precoPorHora * horas" para a variável valorTotal                

        int horas = 0;
        decimal valorTotal = 0;
        horas = int.Parse(Console.ReadLine());
        valorTotal = (precoInicial + precoPorHora) * horas;


        veiculos.Remove(placa);

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
      if (veiculos.Any())
      {
        Console.WriteLine("Os veículos estacionados são:");
        foreach (var item in veiculos)
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
