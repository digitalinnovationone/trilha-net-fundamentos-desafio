using DesafioFundamentos.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.Write("Seja bem vindo ao sistema de estacionamento!\n" +
                    "Digite o preço inicial: ");
decimal precoInicial = decimal.Parse(Console.ReadLine());

Console.Write("Agora digite o preço por hora: ");
decimal precoPorHora = decimal.Parse(Console.ReadLine());

Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);
estacionamento.Menu();

Console.WriteLine("O programa se encerrou");
