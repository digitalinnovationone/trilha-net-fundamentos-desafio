using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {


            Console.WriteLine("Digite a placa (no formato AAA-0000 ou Mercosul) do veículo para estacionar:");
            string placa = Console.ReadLine();

            var resultado = ValidarPlaca(placa);
            if (resultado == false)
            {
                Console.WriteLine("Placa inválida! Tente novamente...");
                AdicionarVeiculo();
            }
            else
            {
                veiculos.Add(placa);
                Console.WriteLine("Veículo adicionado com sucesso!");
            }

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa (no formato AAA-0000 ou Mercosul) do veículo para remover:");


            string placa = Console.ReadLine();

            var resultado = ValidarPlaca(placa);
            if (resultado == false)
            {
                Console.WriteLine("Placa inválida! Tente novamente...");
                RemoverVeiculo();
            }
            else
            {
                Console.WriteLine("Aguarde um momento enquanto tentamos econtrar seu veículo...");
                Thread.Sleep(2000);

                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");



                    int horas = int.Parse(Console.ReadLine());
                    decimal valorTotal = precoInicial + precoPorHora * horas;


                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }

        }

        public void ListarVeiculos()
        {

            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }


        private static bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa)) { return false; }

            if (placa.Length > 8) { return false; }

            placa = placa.Replace("-", "").Trim();


            if (char.IsLetter(placa, 4))
            {

                var padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                return padraoMercosul.IsMatch(placa);
            }
            else
            {

                var padraoNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
                return padraoNormal.IsMatch(placa);
            }
        }

    }
}
