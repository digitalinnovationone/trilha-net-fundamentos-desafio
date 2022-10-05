using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
  public class Veiculo
  {
    public string Placa { get; private set; }
    public int HoraEntrada { get; private set; }
    private int HoraSaida { get; set; }

    public Veiculo(string placa, int horaEntrada)
    {
      this.Placa = placa;
      this.HoraEntrada = horaEntrada;
    }


    public void AddSaida(int horaSaida)
    {
      this.HoraSaida = horaSaida;
    }


  }
}