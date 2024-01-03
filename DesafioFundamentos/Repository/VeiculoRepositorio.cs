using DesafioFundamentos.Models;

namespace Repository
{
    public class VeiculoRepositorio
    {
        // Lista estática de objetos Veiculo para armazenar os veículos
        private static List<Veiculo> veiculos = new List<Veiculo>();

        // Método para adicionar um veículo à lista
        public static void AdicionarVeiculo(Veiculo veiculo)
        {
            veiculos.Add(veiculo);
        }

        // Método para consultar todos os veículos na lista
        public static List<Veiculo> ConsultarTodos()
        {
            return veiculos;
        }

        // Método para verificar se um veículo com a placa especificada existe na lista
        public static bool ConsultarVeiculo(string placa)
        {
            return veiculos.Any(e => e.Placa == placa);
        }

        // Método para consultar um veículo específico com base na placa
        public static Veiculo ConsultarUm(string placa)
        {
            return veiculos.FirstOrDefault(e => e.Placa == placa);
        }

        // Método para excluir um veículo com base na placa
        public static void Delete(string placa)
        {
            // Consulta o veículo com base na placa e o remove da lista
            var veiculo = ConsultarUm(placa);
            veiculos.Remove(veiculo);
        }
    }
}