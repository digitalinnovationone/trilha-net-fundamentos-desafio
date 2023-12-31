
using DesafioFundamentos.Models;

namespace Repository
{
    public class VeiculoRepositorio
    {
        private static List<Veiculo> veiculos = new List<Veiculo>();

        public static void AdicionarVeiculo(Veiculo veiculo)
        {
            veiculos.Add(veiculo);
        }

        public static List<Veiculo> ConsultarTodos()
        {
            return veiculos;
        }

        public static bool ConsultarVeiculo(string placa)
        {
            return veiculos.Any(e => e.Placa == placa);
        }

        public static Veiculo ConsultarUm(string placa)
        {
            return veiculos.FirstOrDefault(e => e.Placa == placa);
        }

        public static void Delete(string placa)
        {
            var veiculo = ConsultarUm(placa);
            veiculos.Remove(veiculo);
        }
    }
}