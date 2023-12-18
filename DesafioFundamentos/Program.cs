// PARKING MANAGEMENT

using DesafioFundamentos.Models;
Console.Clear();

Console.WriteLine("Digite o preço inicial:");
decimal Preco_In = Convert.ToDecimal(Console.ReadLine());
//Console.WriteLine(Preco_In);

Console.WriteLine("Agora digite o preço por hora:");
decimal Preco_PH = Convert.ToDecimal(Console.ReadLine());
//Console.WriteLine(Preco_PH);

Parking par = new Parking(Preco_In, Preco_PH);
byte flag = 0x01; // Flag to determinate the while statement

while(flag==1)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículo");
    Console.WriteLine("4 - Encerrar");

    switch(Convert.ToByte(Console.ReadLine()))
    {
        case 1:
            par.Register();
            break;

        case 2:
            par.Remove();
            break;

        case 3:
            par.Show();
            break;

        case 4:
            flag &= 0x00; // disable the flag of while statement
            break;

        default:
            Console.WriteLine("Opção Inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

