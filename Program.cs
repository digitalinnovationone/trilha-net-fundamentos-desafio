
using DesafioDIO_NET_Estacionamento.Models;

Console.WriteLine("--- Estacionamento DIO BOOTCAMP .NET ---\n");
decimal precoInicio = 0;
decimal precoHora = 0;

Console.WriteLine("Digite o preço inicial:");
precoInicio = Convert.ToDecimal(Console.ReadLine());


Console.WriteLine("Digite o preço por hora:");
precoHora = Convert.ToDecimal(Console.ReadLine());

Estacionamento est = new Estacionamento(precoInicio, precoHora);


int opcao = 0;

bool Menu = true;

while (Menu)
{
    Console.Clear();
    Console.WriteLine("Selecione a opção desejada:");
    Console.WriteLine("[1] - Cadastrar um veículo");
    Console.WriteLine("[2] - Remover um veículo");
    Console.WriteLine("[3] - Listar todos veículos");
    Console.WriteLine("[4] - Sair");

    switch (Console.ReadLine())
    {
        case "1":
            est.AdicionarVeiculo();
            break;

        case "2":
            est.RemoverVeiculo();
            break;

        case "3":
            est.ListarVeiculos();
            break;

        case "4":
            Menu = false;
            break;

        default:
            Console.WriteLine("Opção incorreta!");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");