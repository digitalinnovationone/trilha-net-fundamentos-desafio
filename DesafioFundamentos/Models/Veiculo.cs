using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioEstacionamento.Models
{
    public class Veiculo
    {
        public string Placa { get; private set; }
        public int QtdHoras { get; private set; }

        public void AdicionarPlaca(string placa)
        {
            ValidarPlaca(placa);
            Placa = placa;
        }

        public void AdicionarQtdHoras(int qtdHoras)
        {
            ValidarQtdHoras(qtdHoras);
            QtdHoras = qtdHoras;
        }

        private void ValidarPlaca(string placa)
        {
            if (string.IsNullOrEmpty(placa))
                throw new Exception("a placa deve ser preenchida");
        }        

        private void ValidarQtdHoras(int valor)
        {
            if (valor < 0)
                Console.WriteLine("Informe a quantidade de horas");
        }

    }
}