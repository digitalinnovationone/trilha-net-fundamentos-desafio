using DesafioFundamentos.Models;
using DocumentFormat.OpenXml.Drawing;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

Estacionamento es = new Estacionamento();

string opcao = string.Empty;
bool exibirMenu = true;
// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Criar 10 Veiculos");
    Console.WriteLine("5 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            Console.WriteLine("Como você que Listar os veiculos?");
            Console.WriteLine("1-Terminal");
            Console.WriteLine("2-Exel");
            Console.WriteLine("3-CSV");

            opcao = Console.ReadLine();
            if(opcao=="1"){
                es.ListarVeiculosTerminal();
            }
            else if(opcao=="2"){
                es.ListarVeiculosExel();
            }
            else if(opcao=="3"){

            }else{
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
