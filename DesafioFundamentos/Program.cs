using DesafioFundamentos.Models;
using DocumentFormat.OpenXml.Drawing;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

Estacionamento es = new Estacionamento();

string opcao = string.Empty;
string trilha = string.Empty;
string filtro = string.Empty;
bool exibirMenu = true;
// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Escolha uma Trilha:");
    Console.WriteLine("1 - Trinha Usuario");
    Console.WriteLine("2 - Trilha Administrador");
    Console.WriteLine("3 - Trilha Desenvolvedor");
    Console.WriteLine("4 - Criar 10 Veiculos");
    Console.WriteLine("5 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine("Cadastro de Usuario ao Estacionamento");
            es.AdicionarVeiculo();
            break;

        case "2":
            Console.WriteLine("Escolha uma Opção:");
            Console.WriteLine("1-Adicinar Usuarios");
            opcao = Console.ReadLine();
            if (opcao == "1")
            {
                Console.WriteLine("2-adcionar por terminal");
                Console.WriteLine("3-adcionar por Excel");
                trilha = Console.ReadLine();
                switch (trilha)
                {
                    case "2":
                        es.AdicionarVeiculo();
                        break;
                    case "3":
                        es.AdicinarPorExcel();
                        Console.WriteLine("Após adicinar digite 'enter'");
                        Console.ReadLine();
                        es.LerPorExel();
                        break;
                }
            }
            break;

        case "3":
            Console.WriteLine("Por onde você quer caminhar?");
            Console.WriteLine("1-Terminal");
            Console.WriteLine("2-Exel");
            Console.WriteLine("3-CSV");

            opcao = Console.ReadLine();
            if (opcao == "1")
            {
                Console.WriteLine("O que você deseja fazer como Desenvolvedor?");
                Console.WriteLine("1-Adcinionar");
                Console.WriteLine("2-Listar");
                Console.WriteLine("3-Remover");
                trilha = Console.ReadLine();
                switch (trilha)
                {
                    case "1":
                        es.AdicionarVeiculo();
                        break;

                    case "2":
                        es.ListarVeiculosTerminal();
                        break;
                    case "3":
                        es.RemoverVeiculo();
                        es.LerPorExel();
                        break;
                }

            }
            else if (opcao == "2")
            {
                Console.WriteLine("O que você deseja fazer como Desenvolvedor?");
                Console.WriteLine("1-Adcinionar");
                Console.WriteLine("2-Listar");
                Console.WriteLine("3-Remover");
                trilha = Console.ReadLine();
                switch (trilha)
                {
                    case "1":

                        es.AdicinarPorExcel();
                        Console.WriteLine("Após adicinar digite 'enter'");
                        Console.ReadLine();
                        es.LerPorExel();
                        break;

                    case "2":

                        es.ListarVeiculosExel();
                        break;

                }

            }
            else if (opcao == "3")
            {

            }
            else
            {
                Console.WriteLine("Opção inválida");
                break;

            }
            break;
        case "4":
            es.BancoDeUsuarios();
            break;
        case "5":
            exibirMenu = false;
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");