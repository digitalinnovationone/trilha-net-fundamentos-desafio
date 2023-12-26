using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DesafioEstacionamento.Models;

namespace DesafioEstacionamento.Services
{
    public class EstacionamentoService
    {
        private readonly Estacionamento _estacionamento;

        public EstacionamentoService(Estacionamento estacionamento)
        {
            _estacionamento = estacionamento;
        }

        public void IniciarEstacionamento()
        {
            Console.Clear();
            int opcao = 0;

            while (opcao != 4)
            {
                Console.WriteLine("----------------------------------------------" +
                                "\n--- Bem vindo ao sistema de estacionamento ---" +
                                "\n----------------------------------------------");

                if (opcao == 0)
                {
                    Console.WriteLine("\nVocê deve adicionar o valor inicial(fixo).");
                    AdicionarValorInicial();

                    Console.WriteLine("\nVocê deve adicionar o valor hora.");
                    AdicionarValorHora();
                }

                Console.WriteLine("Selecione uma das opções" +
                                "\n1 - Adicionar Veiculo" +
                                "\n2 - Remover Veículo" +
                                "\n3 - Listar Veículos" +
                                "\n4 - Encerrar sistema");

                var opcaoTry = int.TryParse(Console.ReadLine(), out opcao);

                if (!opcaoTry)
                    Console.WriteLine("Nenhuma opção selecionada. Encerrando o sistema........");

                SelecionarOpcao(opcao);

            }
        }

        private void SelecionarOpcao(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    AdicionarVeiculo();
                    break;
                case 2:
                    Console.Clear();
                    RemoverVeiculo();
                    break;
                case 3:
                    Console.Clear();
                    ListarVeiculos();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Encerrando o sistema.....");
                    FechamentoDia();
                    break;
            }
        }

        private void AdicionarValorInicial()
        {
            try
            {
                decimal valorInicial = 0;
                Console.Write("Informe o valor inicial: ");
                var valorInicialTry = decimal.TryParse(Console.ReadLine(), out valorInicial);
                if (!valorInicialTry)
                    Console.WriteLine("Erro, informe um valor válido.");

                _estacionamento.AdicionarValorInicial(valorInicial);
            }
            catch
            {
                Console.WriteLine("Erro ao adicionar o valor inicial.");
            }
        }

        private void AdicionarValorHora()
        {
            try
            {
                decimal valorHora = 0;
                Console.Write("Informe o valor hora: ");
                var valorHoraTry = decimal.TryParse(Console.ReadLine(), out valorHora);
                if (!valorHoraTry)
                    Console.WriteLine("Erro, informe um valor válido.");

                _estacionamento.AdicionarValorHora(valorHora);
            }
            catch
            {
                Console.WriteLine("Erro ao adicionar o valor inicial.");
            }
        }

        private void AdicionarQtdHoras(Veiculo veiculo)
        {
            try
            {
                int qtdHoras = 0;
                Console.Write("Informe quantidade de horas: ");
                var qtdhorasTry = int.TryParse(Console.ReadLine(), out qtdHoras);
                if (!qtdhorasTry)
                    Console.WriteLine("Erro, informe um valor válido.");

                veiculo.AdicionarQtdHoras(qtdHoras);
            }
            catch
            {
                Console.WriteLine("Erro ao adicionar o valor inicial.");
            }
        }

        private void AdicionarVeiculo()
        {
            try
            {
                var veiculo = new Veiculo();

                Console.Write("Informe a placa do veículo: ");
                string placa = Console.ReadLine();
                veiculo.AdicionarPlaca(placa);

                AdicionarQtdHoras(veiculo);

                _estacionamento.AdicionarVeiculo(veiculo);
            }
            catch
            {
                Console.WriteLine("Ocorreu um erro ao adicionar o veículo.");
            }
        }

        private void RemoverVeiculo()
        {
            try
            {
                Console.Write("Informe a placa do veículo: ");
                string placa = Console.ReadLine();

                var veiculo = _estacionamento.SelecionarVeiculo(placa);

                if (veiculo == null)
                    Console.WriteLine("Veículo não encontrado");

                Total(veiculo.Placa);
                _estacionamento.RemoverVeiculo(veiculo);
            }
            catch
            {
                Console.WriteLine("Ocorreu um erro ao remover o veículo.");
            }
        }

        private void Total(string placa)
        {
            try
            {
                var veiculo = _estacionamento.SelecionarVeiculo(placa);

                var total = _estacionamento.ValorInicial + (_estacionamento.ValorHora * veiculo.QtdHoras);
                Console.WriteLine($"O valor total é: {total.ToString("C")}");
            }
            catch
            {
                Console.WriteLine("Erro ao calcular o total.");
            }
        }

        private void ListarVeiculos()
        {
            try
            {
                var listaVeiculos = _estacionamento.ListarVeiculos();

                Console.WriteLine("Veículos no estacionamento:");

                foreach (var veiculo in listaVeiculos)
                {
                    decimal total = _estacionamento.ValorInicial + (veiculo.QtdHoras * _estacionamento.ValorHora);
                    Console.WriteLine($"placa: {veiculo.Placa}, qtdHoras: {veiculo.QtdHoras}, total: {total.ToString("C")}");
                }

                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Ocorreu um erro ao adicionar o veículo.");
            }
        }

        private void FechamentoDia()
        {
            var veiculos = _estacionamento.ListarVeiculos();
            decimal total = 0;

            foreach (var veiculo in veiculos)
            {
                total += _estacionamento.ValorInicial + (_estacionamento.ValorHora * veiculo.QtdHoras);
            }

            Console.WriteLine($"Fechamento do dia: {total.ToString("C")}");
        }
    }
}