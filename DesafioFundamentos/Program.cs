using DesafioFundamentos.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;
bool sucesso = false;

Console.Write("Seja bem vindo ao sistema de estacionamento!\n\n" + 
"A seguir vamos inicializar os parâmetros do sistema. Bom trabalho!\n\n");

do {
    Console.Write("Digite o preço inicial R$: ");
    string precoInicialEntrada = Console.ReadLine();

    if(!string.IsNullOrEmpty(precoInicialEntrada)) (sucesso,precoInicial) = ValidarEntrada(precoInicialEntrada, precoInicial);
} while(!sucesso);

do {
    Console.Write("Agora digite o preço por hora R$: ");
    string precoPorHoraEntrda = Console.ReadLine();

    if(!string.IsNullOrEmpty(precoPorHoraEntrda)) (sucesso,precoPorHora) = ValidarEntrada(precoPorHoraEntrda,precoPorHora);

} while(!sucesso);

static (bool,decimal) ValidarEntrada(string entrada, decimal valor)
{
    bool retorno = false;
    if(decimal.TryParse(entrada, out valor)) 
    {
        retorno = true;
    }
    return (retorno, valor);
}

Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Sistema inicializado");
    Console.WriteLine($"Taxa do serviço...R$ {precoInicial:0.00}");
    Console.WriteLine($"Valor por hora....R$ {precoPorHora:0.00}\n");
    Console.WriteLine(" 1 - Cadastrar veículo");
    Console.WriteLine(" 2 - Remover veículo");
    Console.WriteLine(" 3 - Listar veículos");
    Console.WriteLine(" 4 - Encerrar\n");
    Console.Write(" Digite a sua opção: ");
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

        case "4":
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

