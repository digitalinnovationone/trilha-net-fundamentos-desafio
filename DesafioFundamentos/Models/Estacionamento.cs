using System.Diagnostics;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using DocumentFormat.OpenXml.Spreadsheet;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        Veiculo veiculo = new Veiculo();
        Boolean opcao = true;
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

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

        public void ListarVeiculosExel()
        {
            if (veiculo.Id.Any())
            {
        
                Process.Start(new ProcessStartInfo(@"C:\Temp\TestesExel.xlsx") { UseShellExecute = true });
                 var workbook = new XLWorkbook(@"C:\Temp\TestesExel.xlsx");
                workbook.SaveAs(@"C:\Temp\TestesExel.xlsx");
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
        public void ListarVeiculosTerminal()
        {
            // Verifica se há veículos no estacionamento
            if (veiculo.Id.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                for (int i = 0; i < veiculo.Id.Count; i++)
                {
                    Console.WriteLine($"ID: {veiculo.Id[i]}, Nome: {veiculo.Nome[i]}, CPF: {veiculo.CPF[i]}, CNH: {veiculo.CNH[i]}, Placa: {veiculo.Placa[i]}, Senha: {veiculo.Senha[i]}, Plano: {veiculo.Plano[i]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public void AdicinarPorExcel()
        {
            Process.Start(new ProcessStartInfo(@"C:\Temp\TestesExel.xlsx") { UseShellExecute = true });
            var workbook = new XLWorkbook(@"C:\Temp\TestesExel.xlsx");
            var planilha = workbook.Worksheets.First(w => w.Name == "PlanilhasUsuarios");
            var totalLinhas = planilha.Rows().Count();


            for (int l = 2; l <= totalLinhas; l++)
            {
                string id = planilha.Cell($"A{l}").Value.ToString();
                string nome = planilha.Cell($"B{l}").Value.ToString();
                string cpf = planilha.Cell($"C{l}").Value.ToString();
                string cnh = planilha.Cell($"D{l}").Value.ToString();
                string placa = planilha.Cell($"E{l}").Value.ToString();
                string senha = planilha.Cell($"F{l}").Value.ToString();

                string planoString = planilha.Cell($"G{l}").Value.ToString();
                int plano;
                bool planoValido = int.TryParse(planoString, out plano);

                if (veiculo.Id.Contains(id))
                {
                    continue;
                }
                veiculo.Id.Add(id);
                veiculo.Nome.Add(nome);
                veiculo.CPF.Add(cpf);
                veiculo.CNH.Add(cnh);
                veiculo.Placa.Add(placa);
                veiculo.Senha.Add(senha);
                veiculo.Plano.Add(plano);
            }

        }
        public void LerPorExel()
        {
            var workbook = new XLWorkbook(@"C:\Temp\TestesExel.xlsx");
            var planilha = workbook.Worksheets.First(w => w.Name == "PlanilhasUsuarios");
            var totalLinhas = planilha.Rows().Count();


            for (int l = 2; l <= totalLinhas; l++)
            {
                string id = planilha.Cell($"A{l}").Value.ToString();
                string nome = planilha.Cell($"B{l}").Value.ToString();
                string cpf = planilha.Cell($"C{l}").Value.ToString();
                string cnh = planilha.Cell($"D{l}").Value.ToString();
                string placa = planilha.Cell($"E{l}").Value.ToString();
                string senha = planilha.Cell($"F{l}").Value.ToString();

                string planoString = planilha.Cell($"G{l}").Value.ToString();
                int plano;
                bool planoValido = int.TryParse(planoString, out plano);

                if (veiculo.Id.Contains(id))
                {
                    continue;
                }
                veiculo.Id.Add(id);
                veiculo.Nome.Add(nome);
                veiculo.CPF.Add(cpf);
                veiculo.CNH.Add(cnh);
                veiculo.Placa.Add(placa);
                veiculo.Senha.Add(senha);
                veiculo.Plano.Add(plano);
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
                worksheet.Cell("H1").Value = "VALOR TOTAL";


                Console.WriteLine("Insira os nomes (digite 'sair' para parar):");

                while (opcao = true)
                {
                    Console.Write("ID: ");
                    string id = Console.ReadLine();
                    if (id.ToLower() == "sair")
                    {
                        opcao = false;
                        break;
                    }
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
                    worksheet.Cell(i + 2, 2).Value = veiculo.Nome[i];
                    worksheet.Cell(i + 2, 3).Value = veiculo.CPF[i];
                    worksheet.Cell(i + 2, 4).Value = veiculo.CNH[i];
                    worksheet.Cell(i + 2, 5).Value = veiculo.Placa[i];
                    worksheet.Cell(i + 2, 6).Value = veiculo.Senha[i];
                    worksheet.Cell(i + 2, 7).Value = veiculo.Plano[i];
                }

                worksheet.Cell("H2").FormulaA1 = "=SUM(G2:G20)";
                workbook.SaveAs(@"C:\Temp\TestesExel.xlsx");

            }
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
                worksheet.Cell("H1").Value = "VALOR TOTAL";


                veiculo.Id.AddRange(new List<string>
        {
            "ID001", "ID002", "ID003", "ID004", "ID005", "ID006", "ID007", "ID008", "ID009", "ID010"
        });
                veiculo.Nome.AddRange(new List<string>
        {
            "Alice", "Bob", "Charlie", "David", "Eva", "Frank", "Grace", "Hank", "Isabel", "Jack"
        });

                veiculo.CPF.AddRange(new List<string>
        {
            "111.111.111-11", "222.222.222-22", "333.333.333-33", "444.444.444-44", "555.555.555-55",
            "666.666.666-66", "777.777.777-77", "888.888.888-88", "999.999.999-99", "000.000.000-00"
        });

                veiculo.CNH.AddRange(new List<string>
        {
            "CNH001", "CNH002", "CNH003", "CNH004", "CNH005", "CNH006", "CNH007", "CNH008", "CNH009", "CNH010"
        });

                veiculo.Placa.AddRange(new List<string>
        {
            "ABC123", "DEF456", "GHI789", "JKL012", "MNO345", "PQR678", "STU901", "VWX234", "YZA567", "BCD890"
        });

                veiculo.Senha.AddRange(new List<string>
        {
            "senha1", "senha2", "senha3", "senha4", "senha5", "senha6", "senha7", "senha8", "senha9", "senha10"
        });
                veiculo.Plano.AddRange(new List<int>
                { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10

                 });

                for (int i = 0; i < veiculo.Id.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = veiculo.Id[i];
                    worksheet.Cell(i + 2, 2).Value = veiculo.Nome[i];
                    worksheet.Cell(i + 2, 3).Value = veiculo.CPF[i];
                    worksheet.Cell(i + 2, 4).Value = veiculo.CNH[i];
                    worksheet.Cell(i + 2, 5).Value = veiculo.Placa[i];
                    worksheet.Cell(i + 2, 6).Value = veiculo.Senha[i];
                    worksheet.Cell(i + 2, 7).Value = veiculo.Plano[i];

                }

                worksheet.Cell("H2").FormulaA1 = "=SUM(G2:G300)";
                workbook.SaveAs(@"C:\Temp\TestesExel.xlsx");

            }
        }
    }
}