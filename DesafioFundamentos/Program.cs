using System;
using System.Globalization;
using System.Threading;

namespace DesafioFundamentos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

            MenuUI.DrawHeader("SISTEMA DE ESTACIONAMENTO");
            var estacionamento = Models.Estacionamento.LoadOrCreate();

            string[] menu = {
                "Cadastrar veículo",
                "Remover veículo",
                "Listar veículos",
                "Mostrar histórico",
                "Configurar preços",
                "Encerrar"
            };

            bool rodando = true;

            while (rodando)
            {
                int opcao = MenuUI.Menu("SISTEMA DE ESTACIONAMENTO", menu);

                switch (opcao)
                {
                    case 0: estacionamento.AdicionarVeiculo(); break;
                    case 1: estacionamento.RemoverVeiculo(); break;
                    case 2: estacionamento.ListarVeiculos(); break;
                    case 3: estacionamento.MostrarResumo(); break;
                    case 4: ConfigurarPrecos(estacionamento); break;
                    case 5: rodando = false; break;
                }

                if (rodando)
                {
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nO programa foi encerrado. Obrigado!");
            Console.ResetColor();
        }

        static void ConfigurarPrecos(Models.Estacionamento estacionamento)
        {
            MenuUI.DrawHeader("SISTEMA DE ESTACIONAMENTO");
            Console.WriteLine("Configurar preços atuais:");
            Console.WriteLine($"Preço inicial atual: {estacionamento.PrecoInicial.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");
            Console.WriteLine($"Preço por hora atual: {estacionamento.PrecoPorHora.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");
            Console.WriteLine();

            decimal novoInicial = ReadDecimalOptional("Digite novo preço inicial (ENTER para manter):", estacionamento.PrecoInicial);
            MenuUI.DrawHeader("SISTEMA DE ESTACIONAMENTO");
            decimal novoPorHora = ReadDecimalOptional("Digite novo preço por hora (ENTER para manter):", estacionamento.PrecoPorHora);

            estacionamento.UpdatePrecos(novoInicial, novoPorHora);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPreços atualizados e persistidos.");
            Console.ResetColor();
        }

        static decimal ReadDecimalOptional(string prompt, decimal atual)
        {
            decimal value;
            var culture = CultureInfo.GetCultureInfo("pt-BR");

            while (true)
            {
                MenuUI.DrawHeader("SISTEMA DE ESTACIONAMENTO");
                Console.WriteLine(prompt);
                Console.Write("> ");
                var input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    return atual;
                }

                if (!string.IsNullOrEmpty(input))
                    input = input.Replace(" ", "").Replace('.', ',');

                if (decimal.TryParse(input, System.Globalization.NumberStyles.Number, culture, out value))
                    return Math.Round(value, 2);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Valor inválido. Digite um número como 5,50 ou deixe em branco para manter.");
                Console.ResetColor();
                Thread.Sleep(900);
            }
        }
    }
}
