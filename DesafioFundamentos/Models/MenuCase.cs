using Services;

namespace DesafioFundamentos.Models
{
    public class MenuCase
    {
        public void ExibirMenuCase()
        {
            bool continuaCaseMenu = true;
            while (continuaCaseMenu)
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Adicionar um novo veículo");
                Console.WriteLine("2 - Remover um veículo existente");
                Console.WriteLine("3 - Voltar");
                Console.Write("Opção: ");

                Menu menu = new Menu();
                switch (Console.ReadLine())
                {
                    case "1":
                        VeiculoService.AdicionarVeiculo();
                        break;
                    case "2":
                        VeiculoService.RemoverVeiculo();
                        break;
                    case "3":
                        menu.ExibirMenu();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }
    }
}