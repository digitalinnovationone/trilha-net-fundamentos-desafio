using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class Parking
    {
        private decimal _PreIn, _PrePH;
        private List<string> Park = new List<string>();

        private decimal Parking_Price(int H)
        {
            return ((_PrePH*H) + _PreIn);
        }

        public Parking(decimal inp, decimal inpPH)
        {
            if(inp >= 0 && inpPH >= 0)
            {
                this._PreIn = inp;
                this._PrePH = inpPH;
            }

            else
            {
                Console.WriteLine("Uma das variaveis foi iniciada menor que zero, mude ela por favor!!");
                this._PreIn = 0;
                this._PrePH = 0;
            }
        }

        public void Register()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            //'if(placa!="")
            //'{
            //'    this.Park.Add(placa);
            //'}

            if(placa=="")
            {
                throw new FormatException("Formato inválido para placa do veículo");
            }

            else
            {
                this.Park.Add(placa);
            }
        }

        public bool Remove()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string plc = Console.ReadLine();

            if(this.Park.Exists(x => x.ToUpper() == plc.ToUpper()))
            {
                this.Park.Remove(plc);
                Console.WriteLine("Removido com sucesso");

                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int hours = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("O veículo " + plc + " foi removido e o preço total foi de: " + Parking_Price(hours).ToString("C2", CultureInfo.CreateSpecificCulture("pt-BR")));
                return true;
            }

            else
            {
                Console.WriteLine("Essa placa não existe nesse estacionamento");
                return false;
            }
        }

        public void Show()
        {
            if(Park.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(string i in Park)
                {
                    Console.WriteLine(i);
                }
            }

            else
            {
                Console.WriteLine("Não há veículos estacionados");
            }
        }
    }
}