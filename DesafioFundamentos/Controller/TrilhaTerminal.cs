using System;
using DesafioFundamentos.Models;
using ClosedXML.Excel;

namespace DesafioFundamentos.Controller
{
    class TrilhaTerminal
    {
        Veiculo veiculo = new Veiculo();
        Boolean opcao = true;

        private decimal precoInicial = 0;

        private decimal precoPorHora = 0;

        public void AdicionarVeiculoTerminal()
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

                while (opcao)
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

                worksheet.Cell("H2").FormulaA1 = "=SUM(G2:G20)";
                workbook.SaveAs(@"C:\Temp\TestesExel.xlsx");

            }
        }


        public void RemoverVeiculoTerminal()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculo.Placa.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                int horas = int.Parse(Console.ReadLine());
                decimal valorTotal = precoInicial + (precoPorHora * horas);

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*
                veiculo.Placa.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }
        public void ListarVeiculosTerminal(){
            if (veiculo.Placa.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                for (int i = 0; i < veiculo.Placa.Count; i++)
                {
                    Console.WriteLine($"ID: {veiculo.Id[i]}, Nome: {veiculo.Nome[i]}, CPF: {veiculo.CPF[i]}, CNH: {veiculo.CNH[i]}, Placa: {veiculo.Placa[i]}, Senha: {veiculo.Senha[i]}, Plano: {veiculo.Plano[i]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}