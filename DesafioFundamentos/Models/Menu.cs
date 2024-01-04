using Services;

namespace DesafioFundamentos.Models
{
    //
    public class Menu
    {
        public static void ExibirMenu()
        {
            bool exibirMenu = true;
            while (exibirMenu)
            {
                Console.Clear();
                Console.WriteLine("Bem-vindo ao Gerenciador de Veículos!");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Adicionar um novo veículo");
                Console.WriteLine("2 - Remover um veículo existente");
                Console.WriteLine("3 - Listar todos os veículos");
                Console.WriteLine("4 - Encerrar o programa");
                Console.Write("Opção: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        VeiculoService.AdicionarVeiculo();
                        break;
                    case "2":
                        VeiculoService.RemoverVeiculo();
                        break;
                    case "3":
                        VeiculoService.ListarVeiculos();
                        break;
                    case "4":
                        ExibirCancelarPrograma();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
                
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadKey();
            }
        }

        public static void ExibirMenuCase()
        {
            while(true)
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
                        ExibirMenu();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private static void ExibirCancelarPrograma()
        {
            Console.Clear();
            Console.WriteLine("Programa se encerará em 5 segundos...");
            Thread.Sleep(5000);
            Console.WriteLine("Programa encerrado. \nObrigado por usar os nossos serviços!");
        }
    }
}
