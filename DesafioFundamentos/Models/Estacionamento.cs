using System.Diagnostics;
using ClosedXML.Excel;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();
        Veiculo veiculo = new Veiculo();
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                int horas = int.Parse(Console.ReadLine());
                decimal valorTotal = precoInicial + (precoPorHora * horas);

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*
                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }

            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public void AdicionarVeiculo()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("PlanilhasUsuarios");
                worksheet.Cell("A1").Value = "ID";
                worksheet.Cell("B1").Value = "NOMES";
                worksheet.Cell("C1").Value = "CPF";
                worksheet.Cell("D1").Value = "CNH";
                worksheet.Cell("E1").Value = "PLACA";
                worksheet.Cell("F1").Value = "SENHA";
                worksheet.Cell("G1").Value = "PLANO";


                Console.WriteLine("Insira os nomes (digite 'sair' para parar):");

                while (true)
                {
                    Console.Write("ID: ");
                    string id = Console.ReadLine();
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("CPF: ");
                    string cpf = Console.ReadLine();
                    Console.Write("CNH: ");
                    string cnh = Console.ReadLine();
                    Console.Write("Placa: ");
                    string placa = Console.ReadLine();
                    Console.Write("Senha: ");
                    string senha = Console.ReadLine();
                    Console.Write("Plano: ");
                    int plano = int.Parse(Console.ReadLine());

                    if (id.ToLower() == "sair")
                        break;
                        veiculo.Id.Add(id);
                        veiculo.Nome.Add(nome);
                        veiculo.CPF.Add(cpf);
                        veiculo.CNH.Add(cnh);
                        veiculo.Placa.Add(placa);
                        veiculo.Senha.Add(senha);
                        veiculo.Plano.Add(plano);

                }
                for (int i = 0; i < veiculo.Id.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = veiculo.Id[i];
                }
                for (int i = 0; i < veiculo.Nome.Count; i++)
                {
                    worksheet.Cell(i + 2, 2).Value = veiculo.Nome[i];
                }
                for (int i = 0; i < veiculo.CPF.Count; i++)
                {
                    worksheet.Cell(i + 2, 3).Value = veiculo.CPF[i];
                }
                for (int i = 0; i < veiculo.CNH.Count; i++)
                {
                    worksheet.Cell(i + 2, 4).Value = veiculo.CNH[i];
                }
                for (int i = 0; i < veiculo.Placa.Count; i++)
                {
                    worksheet.Cell(i + 2, 5).Value = veiculo.Placa[i];
                }
                for (int i = 0; i < veiculo.Senha.Count; i++)
                {
                    worksheet.Cell(i + 2, 6).Value = veiculo.Senha[i];
                }
                for (int i = 0; i < veiculo.Plano.Count; i++)
                {
                    worksheet.Cell(i + 2, 7).Value = veiculo.Plano[i];
                }

                workbook.SaveAs(@"C:\Temp\TestesExel.xlsx");

            }
            Process.Start(new ProcessStartInfo(@"C:\Temp\TestesExel.xlsx") { UseShellExecute = true });

        }

        public void BancoDeUsuarios()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("PlanilhasUsuarios");
                worksheet.Cell("A1").Value = "ID";
                worksheet.Cell("B1").Value = "NOMES";
                worksheet.Cell("C1").Value = "CPF";
                worksheet.Cell("D1").Value = "CNH";
                worksheet.Cell("E1").Value = "PLACA";
                worksheet.Cell("F1").Value = "SENHA";
                worksheet.Cell("G1").Value = "PLANO";

                List<string> Id = new List<string>
        {
            "ID001", "ID002", "ID003", "ID004", "ID005", "ID006", "ID007", "ID008", "ID009", "ID010"
        };

                List<string> Nome = new List<string>
        {
            "Alice", "Bob", "Charlie", "David", "Eva", "Frank", "Grace", "Hank", "Isabel", "Jack"
        };

                List<string> CPF = new List<string>
        {
            "111.111.111-11", "222.222.222-22", "333.333.333-33", "444.444.444-44", "555.555.555-55",
            "666.666.666-66", "777.777.777-77", "888.888.888-88", "999.999.999-99", "000.000.000-00"
        };

                List<string> CNH = new List<string>
        {
            "CNH001", "CNH002", "CNH003", "CNH004", "CNH005", "CNH006", "CNH007", "CNH008", "CNH009", "CNH010"
        };

                List<string> Placa = new List<string>
        {
            "ABC123", "DEF456", "GHI789", "JKL012", "MNO345", "PQR678", "STU901", "VWX234", "YZA567", "BCD890"
        };

                List<string> Senha = new List<string>
        {
            "senha1", "senha2", "senha3", "senha4", "senha5", "senha6", "senha7", "senha8", "senha9", "senha10"
        };

                List<int> Plano = new List<int>
                { 100, 200, 300, 100, 200, 300, 100, 200, 300, 100

                };

                for (int i = 0; i < veiculo.Id.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = veiculo.Id[i];
                }
                for (int i = 0; i < veiculo.Nome.Count; i++)
                {
                    worksheet.Cell(i + 2, 2).Value = veiculo.Nome[i];
                }
                for (int i = 0; i < veiculo.CPF.Count; i++)
                {
                    worksheet.Cell(i + 2, 3).Value = veiculo.CPF[i];
                }
                for (int i = 0; i < veiculo.CNH.Count; i++)
                {
                    worksheet.Cell(i + 2, 4).Value = veiculo.CNH[i];
                }
                for (int i = 0; i < veiculo.Placa.Count; i++)
                {
                    worksheet.Cell(i + 2, 5).Value = veiculo.Placa[i];
                }
                for (int i = 0; i < veiculo.Senha.Count; i++)
                {
                    worksheet.Cell(i + 2, 6).Value = veiculo.Senha[i];
                }
                for (int i = 0; i < veiculo.Plano.Count; i++)
                {
                    worksheet.Cell(i + 2, 7).Value = veiculo.Plano[i];
                }

                workbook.SaveAs(@"C:\Temp\TestesExel.xlsx");

            }
            Process.Start(new ProcessStartInfo(@"C:\Temp\TestesExel.xlsx") { UseShellExecute = true });
        }
    }
}
