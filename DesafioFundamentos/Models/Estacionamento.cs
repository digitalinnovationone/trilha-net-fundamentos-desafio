using System.Diagnostics;
using ClosedXML.Excel;
using DesafioFundamentos.Controller;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using DocumentFormat.OpenXml.Spreadsheet;
namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        Veiculo veiculo = new Veiculo();
         TrilhaTerminal trilhaTerminal = new TrilhaTerminal();
         TrilhaExel trilhaExel = new TrilhaExel();
        
      public void AdicionarVeiculoTerminal()
        {
            trilhaTerminal.AdicionarVeiculoTerminal();
        }

        public void RemoverVeiculoTerminal()
        {
            trilhaTerminal.RemoverVeiculoTerminal();
        }

        public void ListarVeiculosTerminal()
        {
            trilhaTerminal.ListarVeiculosTerminal();
        }

        //---------------------------------------------------------//
        //Trilha Exel

        public void AdicinarPorExcel()
        {
            trilhaExel.AdicinarPorExcel();
        }
        
        public void LerPorExel()
        {
           trilhaExel.LerPorExel();
        }

        public void ListarVeiculosExel()
        {
           trilhaExel.ListarVeiculosExel();
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

                for (int i = 0; i < veiculo.Placa.Count; i++)
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