using System.Text;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {   
        private string PADRAO_PLACA_VEICULO = @"(^[a-z]{1,3})\-([0-9]{1,3})$";
        private const decimal SESSENTA_MINUTOS = 0.60M;

        private decimal precoInicial = decimal.Zero;
        private decimal precoPorHora = decimal.Zero;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string placaVeiculo;

            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            if(!ReceberPlacaVeiculo("Digite a placa do veículo para estacionar:",  out placaVeiculo))
            {
                return;
            }

            if(PlacaVeiculoExiste(placaVeiculo))
            {
                Console.WriteLine($"Placa de veículo informada já existe.");
                return;
            }

            this.veiculos.Add(placaVeiculo);
        }

        public void RemoverVeiculo()
        {
            string placaVeiculo;

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            if(!ReceberPlacaVeiculo("Digite a placa do veículo para remover:", out placaVeiculo))
            {
                return;
            }

            if(!PlacaVeiculoExiste(placaVeiculo))
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                return;
            }

            // Se o veículo existe

            decimal quantidadeHoras = decimal.Zero;

            // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
            if(!ReceberQuantidadeHoras("Digite a quantidade de horas que o veículo permaneceu estacionado:", out quantidadeHoras))
            {
                Console.WriteLine("Quantidade de horas informada não é um valor válido.");
                return;
            }

            // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
            decimal valorTotal = CalcularValor(quantidadeHoras); 

            // TODO: Remover a placa digitada da lista de veículos
            this.veiculos.Remove(placaVeiculo);

            Console.WriteLine($"O veículo {placaVeiculo} foi removido e o preço total foi de: R$ {valorTotal}");
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                foreach(string veiculo in veiculos)
                {
                    Console.WriteLine($"- {veiculo}");
                }     
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private bool ReceberQuantidadeHoras(string mensagemParaExibir, out decimal quantidadeHoras)
        {
            Console.WriteLine($"{mensagemParaExibir}.{Environment.NewLine}Exemplo 2.55 para 02horas e 55 minutos.");
            string quantidadeHorasInformada = Console.ReadLine();

            if(!decimal.TryParse(quantidadeHorasInformada, out quantidadeHoras))
            {
                return false;
            }
            
            return ParteFracionariaQuantidadeHorasIsValid(quantidadeHorasInformada);
        }

        private bool ReceberPlacaVeiculo(string mensagemParaExibir, out string placaVeiculo)
        {
            Console.WriteLine(mensagemParaExibir);
            placaVeiculo = Console.ReadLine();

            if(!PlacaVeiculoIsValid(placaVeiculo))
            {
                Console.WriteLine($"Placa de veículo informada não é válida. Esperado o formato 'AAA-123'.");
                return false;
            }

            return true;
        }

        private bool PlacaVeiculoIsValid(string placaVeiculo)
        {
            Regex regex = new(PADRAO_PLACA_VEICULO, RegexOptions.IgnorePatternWhitespace);

            return regex.IsMatch(placaVeiculo);
        }

        private bool PlacaVeiculoExiste(string placaVeiculo)
            => this.veiculos.Any(v => v == placaVeiculo);

        private bool ParteFracionariaQuantidadeHorasIsValid(string quantidadeHorasInformada)
        {
            string[] partesQuantidadeHorasInformada = quantidadeHorasInformada.Split('.');

            if(partesQuantidadeHorasInformada.Length > 1)
            {
                string parteFracionariaQuantidadeHorasInformada = $"0.{partesQuantidadeHorasInformada[1]}";

                decimal parteFracionaria;
                decimal.TryParse(parteFracionariaQuantidadeHorasInformada, out parteFracionaria);

                if(parteFracionaria > SESSENTA_MINUTOS)
                {
                    Console.WriteLine($"Quantidade de horas informada ({quantidadeHorasInformada}) com valor excedente ({parteFracionariaQuantidadeHorasInformada}).");
                    return false;
                }
            }

            return true;
        }

        private decimal CalcularValor(decimal quantidadeHoras)
        {
            string quantidadeHorasConvertida = quantidadeHoras.ToString();
            string[] partesQuantidadeHorasConvertida = quantidadeHorasConvertida.Split('.');

            decimal horas;
            decimal minutos;
            
            decimal.TryParse(partesQuantidadeHorasConvertida[0], out horas);
            decimal.TryParse($"0.{partesQuantidadeHorasConvertida[1]}", out minutos);

            decimal valorTotal = precoInicial + precoPorHora;

            // Calcular o valor baseado apenas na quantidade de horas inteiras informada.
            decimal valorPorHora = valorTotal * horas;

            // Verificar qual a proporcao de  minutos informado dentro de minutos possiveis dentro de uma hora.
            decimal proporcaoMinutos = minutos / SESSENTA_MINUTOS;

            // Calcular o valor baseado apenas na quantidade de minutos informado e de acordo com a proporção.
            decimal valorPorMinutos = valorTotal * proporcaoMinutos;

            // Garante truncar o valor com até 2 casas decimais, sem permitir arredondamento.
            return (Math.Truncate((valorPorHora + valorPorMinutos)*100))/100;
        }
    }
}
