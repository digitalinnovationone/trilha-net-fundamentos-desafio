using DesafioFundamentos.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        // Coloca o encoding para UTF8 para exibir acentuação
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        decimal precoInicial = 0;
        decimal precoPorHora = 0;
        /*

                Console.WriteLine(@"

        ░██████╗██╗░██████╗████████╗███████╗███╗░░░███╗░█████╗░  ██████╗░███████╗
        ██╔════╝██║██╔════╝╚══██╔══╝██╔════╝████╗░████║██╔══██╗  ██╔══██╗██╔════╝
        ╚█████╗░██║╚█████╗░░░░██║░░░█████╗░░██╔████╔██║███████║  ██║░░██║█████╗░░
        ░╚═══██╗██║░╚═══██╗░░░██║░░░██╔══╝░░██║╚██╔╝██║██╔══██║  ██║░░██║██╔══╝░░
        ██████╔╝██║██████╔╝░░░██║░░░███████╗██║░╚═╝░██║██║░░██║  ██████╔╝███████╗
        ╚═════╝░╚═╝╚═════╝░░░░╚═╝░░░╚══════╝╚═╝░░░░░╚═╝╚═╝░░╚═╝  ╚═════╝░╚══════╝

        ███████╗░██████╗████████╗░█████╗░░█████╗░██╗░█████╗░███╗░░██╗░█████╗░███╗░░░███╗███████╗███╗░░██╗████████╗░█████╗░
        ██╔════╝██╔════╝╚══██╔══╝██╔══██╗██╔══██╗██║██╔══██╗████╗░██║██╔══██╗████╗░████║██╔════╝████╗░██║╚══██╔══╝██╔══██╗
        █████╗░░╚█████╗░░░░██║░░░███████║██║░░╚═╝██║██║░░██║██╔██╗██║███████║██╔████╔██║█████╗░░██╔██╗██║░░░██║░░░██║░░██║
        ██╔══╝░░░╚═══██╗░░░██║░░░██╔══██║██║░░██╗██║██║░░██║██║╚████║██╔══██║██║╚██╔╝██║██╔══╝░░██║╚████║░░░██║░░░██║░░██║
        ███████╗██████╔╝░░░██║░░░██║░░██║╚█████╔╝██║╚█████╔╝██║░╚███║██║░░██║██║░╚═╝░██║███████╗██║░╚███║░░░██║░░░╚█████╔╝
        ╚══════╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝░╚════╝░╚═╝░╚════╝░╚═╝░░╚══╝╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝░░░╚═╝░░░░╚════╝░
        ");
        */

        Console.WriteLine();
        Console.WriteLine("======= Seja bem vindo! ========");
        Console.WriteLine();
        Console.Write("Digite o preço inicial: ");
        precoInicial = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine();
        Console.Clear();

        Console.Write("Agora digite o preço por hora: ");
        precoPorHora = Convert.ToDecimal(Console.ReadLine());
        Console.Clear();

        // Instancia a classe Estacionamento, já com os valores obtidos anteriormente
        Estacionamento es = new Estacionamento(precoInicial, precoPorHora);


        bool exibirMenu = true;

        // Realiza o loop do menu
        while (exibirMenu)
        {
            Console.Clear();
            Console.Write("Digite a sua opção:\n(1) - Cadastrar veículo\n(2) - Remover veículo\n(3) - Listar veículos\n(4) - Encerrar\n=> ");

            int opcaoMenu = int.Parse(Console.ReadLine());

            if (opcaoMenu > 0 && opcaoMenu < 6)
            {
                switch (opcaoMenu)
                {

                    case 1:
                        Console.Clear();
                        es.AdicionarVeiculo();
                        break;

                    case 2:
                        Console.Clear();
                        es.RemoverVeiculo();
                        break;

                    case 3:
                        Console.Clear();
                        es.ListarVeiculos();
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Obrigado e volte sempre!!!");
                        exibirMenu = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine($"A Opção {opcaoMenu} é inválida!! Tente Novamente...");
                        break;
                }

            }
            else
            {
                Console.Clear();
                System.Console.WriteLine("Tente digitar as opções validas entre <1> a <4> que são as opcões do Menu Inicial! Obrigado!");
                Console.WriteLine("*******************************************************************************************");

            }
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            System.Threading.Thread.Sleep(1000);

        }

        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("O programa foi encerrado!");
    }
}