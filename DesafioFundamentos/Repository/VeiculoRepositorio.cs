using DesafioFundamentos.Models;

namespace Repository
{
    public class VeiculoRepositorio
    {
        private static readonly List<Veiculo> veiculos =
        [
            new() { Placa = "ASD1A11" },
            new() { Placa = "ZXC1Z11" },
            new() { Placa = "QWE1Q11" },
        ];

        public static void AdicionarVeiculo(Veiculo veiculo)
        {
            veiculos.Add(veiculo);
        }

        public static List<Veiculo> ListarTodosVeiculos()
        {
            return veiculos;
        }

        public static bool ExisteVeiculoPorPlaca(string placa)
        {
            return veiculos.Any(e => e.Placa == placa);
        }

        public static Veiculo ListarUmVeiculo(string placa)
        {
            return veiculos.FirstOrDefault(e => e.Placa == placa);
        }

        public static void DeletarVeiculo(string placa)
        {
            var veiculo = ListarUmVeiculo(placa);
            veiculos.Remove(veiculo);
        }
    }
}