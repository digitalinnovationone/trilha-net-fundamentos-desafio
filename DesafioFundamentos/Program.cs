using DesafioFundamentos.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = Convert.ToDecimal(7.5);
decimal precoPorHora = Convert.ToDecimal(4.5);

Console.Clear();
Console.WriteLine("\n=========================================================================");
Console.WriteLine("|                             SEJA BEM VINDO!                           |");       
Console.WriteLine("|                       SISTEMA DE ESTACIONAMENTO                       |");
Console.WriteLine("=========================================================================");
Console.WriteLine("|                                                                       |");
Console.WriteLine("|                                                                       |");
Console.WriteLine("|                          _____                _____      _____        |");
Console.WriteLine("|       ______   ______  º!O____!º   ______   º!_O___!º  º!_O___!º      |");
Console.WriteLine("|      | vago | | vago | |       |  | vago |  |       |  |       |      |");
Console.WriteLine("|       __TT__   __TT_  _<>_____<>_  __TT__  _<>_____<>__<>_____<>_     |");
Console.WriteLine("|    /        /       /   U     U /        /  U       U/ U       U /    |");
Console.WriteLine("|   /        /       /           /        /           /           /     |");
Console.WriteLine("|                                                                       |");
Console.WriteLine("|                                                                       |");
Console.WriteLine("=========================================================================\n");
Console.WriteLine("Pressione uma tecla para continuar...");
Console.ReadLine();

Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("=========================================================================");
    Console.WriteLine("|                              MENU PRINCIPAL                           |");
    Console.WriteLine("=========================================================================\n");

    Console.WriteLine("Digite:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Tabela de valores");
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
            es.ListarVeiculos();
            break;

        case "5":
            exibirMenu = false;
            break;
        
        case "4":
            es.ConsultarTabelaPreco();
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}
Console.Clear();
Console.WriteLine("O programa se encerrou");
