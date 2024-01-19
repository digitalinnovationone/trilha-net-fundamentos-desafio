using System;
using ClosedXML.Excel;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Controller
{
    class TrilhaExel
    {
        Veiculo veiculo = new Veiculo();

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

                if (veiculo.Placa.Contains(placa))
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

        public void ListarVeiculosExel(){
             if (veiculo.Placa.Any())
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

        public void LerPorExel(){
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

                if (veiculo.Placa.Contains(placa))
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
    }
}