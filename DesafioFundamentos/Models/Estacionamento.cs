using System.ComponentModel.DataAnnotations;

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
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            placa = placa.ToUpper();
            // Usando regex (conhecimento já estabelecido) para verificar a placa
            if (validacaoPlaca(placa) && !veiculos.Contains(placa))
            {
                veiculos.Add(placa);
                Console.WriteLine($"O veículo de placa {placa} foi registrado!");
            }
            else if(veiculos.Contains(placa))
            {
                Console.WriteLine($"O veículo de placa {placa} já se encontra no estacionamento!");
            }
            else
            {
                Console.WriteLine("Placa Inválida!");
            }

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();
            placa = placa.ToUpper();

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            if (validacaoPlaca(placa))
            {
                // Verifica se o veículo existe
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    Console.WriteLine("Veículo Encontrado!");
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                    // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                    // *IMPLEMENTE AQUI*
                    int horas = Convert.ToInt32(Console.ReadLine());
                    decimal valorTotal = precoInicial + (precoPorHora * horas);

                    // TODO: Remover a placa digitada da lista de veículos
                    veiculos.Remove(placa);


                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                } 
            }
            else
            {
                Console.WriteLine("Placa inválida!");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private bool validacaoPlaca(string placa)
        {
            List<char> listaLetras = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            List<char> listaNumeros = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            bool valido = true;
            for (int i = 0; i < placa.Length; i++)
            {
                char caraterPlaca = placa[i];
                if (i < 2 && !listaLetras.Contains(caraterPlaca))
                {
                    valido = false;
                    break;
                }
                else if (i == 3 && caraterPlaca != '-')
                {
                    valido = false;
                    break;
                }
                else if (i > 3 && !listaNumeros.Contains(caraterPlaca))
                {
                    valido = false;
                    break;
                }
            }
            return valido;
        }

    }
}
