using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal initialPrice = 0;
decimal pricePerHour = 0;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                  "Digite o preço inicial:");
initialPrice = Convert.ToDecimal(Console.ReadLine());

Console.WriteLine("Agora digite o preço por hora:");
pricePerHour = Convert.ToDecimal(Console.ReadLine());

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Parking parking = new Parking(initialPrice, pricePerHour);

string option = string.Empty;
bool showMenu = true;

// Realiza o loop do menu
while (showMenu)
{
    Console.Clear();
    Console.WriteLine("Enter your option:");
    Console.WriteLine("1 - Register vehicle");
    Console.WriteLine("2 - Remove vehicle");
    Console.WriteLine("3 - List vehicles");
    Console.WriteLine("4 - Close");

    switch (Console.ReadLine())
    {
        case "1":
            parking.AddVahicle();
            break;

        case "2":
            parking.RemoveVehicle();
            break;

        case "3":
            parking.ListVehicles();
            break;

        case "4":
            showMenu = false;
            break;

        default:
            Console.WriteLine("Invalid option");
            break;
    }

    Console.WriteLine("Press any key to continue");
    Console.ReadLine();
}

Console.WriteLine("The program has ended");
