using Services;

namespace DesafioFundamentos.Models
{
    public class Menu
    {
        public static void ExibirMenuPrimario()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Bem-vindo ao Gerenciador de Veículos ====");
                Console.WriteLine("Escolha uma das seguintes opções:");
                Console.WriteLine("1 - Adicionar um Novo Veículo");
                Console.WriteLine("2 - Listar Todos os Veículos");
                Console.WriteLine("3 - Localizar Veículo por Placa");
                Console.WriteLine("4 - Remover um Veículo Existente");
                Console.WriteLine("5 - Encerrar o Programa");
                Console.Write("Opção: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        VeiculoService.AdicionarVeiculo();
                        break;
                    case "2":
                        VeiculoService.ListarVeiculos();
                        break;
                    case "3":
                        VeiculoService.ListarVeiculoPorPlaca();
                        break;
                    case "4":
                        VeiculoService.RemoverVeiculo();
                        break;
                    case "5":
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

        public static void ExibirMenuSecundario()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Escolha uma Opção ====");
                Console.WriteLine("1 - Adicionar um Novo Veículo");
                Console.WriteLine("2 - Localizar Veículo por Placa");
                Console.WriteLine("3 - Remover um Veículo Existente");
                Console.WriteLine("4 - Voltar para o Menu Principal");
                Console.Write("Opção: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        VeiculoService.AdicionarVeiculo();
                        break;
                    case "2":
                        VeiculoService.ListarVeiculoPorPlaca();
                        break;
                    case "3":
                        VeiculoService.RemoverVeiculo();
                        break;
                    case "4":
                        ExibirMenuPrimario();
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
            Console.WriteLine("O programa será encerrado em 5 segundos...");
            Thread.Sleep(5000);
            Console.WriteLine("Programa encerrado.\nAgradecemos por utilizar nossos serviços!");
        }
    }
}
