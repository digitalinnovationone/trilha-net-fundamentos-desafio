using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Veiculo
    {
        public string Placa { get; set; }
        public DateTime Entrada { get; set; }

        // Construtor para desserialização
        public Veiculo() { }

        public Veiculo(string placa)
        {
            Placa = placa.ToUpper().Trim();
            Entrada = DateTime.Now;
        }
    }

    public class HistoricoEntry
    {
        public string Placa { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public double Horas { get; set; }
        public decimal Valor { get; set; }
    }

    public class PersistedState
    {
        public decimal PrecoInicial { get; set; }
        public decimal PrecoPorHora { get; set; }
        public List<Veiculo> Veiculos { get; set; } = new();
        public List<HistoricoEntry> Historico { get; set; } = new();
    }

    public class Estacionamento
    {
        private const string DataFile = "data.json";

        private decimal precoInicial;
        private decimal precoPorHora;

        private readonly List<Veiculo> veiculos = new();
        private readonly List<HistoricoEntry> historico = new();

        public decimal PrecoInicial => precoInicial;
        public decimal PrecoPorHora => precoPorHora;

        private Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = Math.Round(precoInicial, 2);
            this.precoPorHora = Math.Round(precoPorHora, 2);
        }

        public static Estacionamento LoadOrCreate()
        {
            try
            {
                if (File.Exists(DataFile))
                {
                    var json = File.ReadAllText(DataFile);
                    var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var state = JsonSerializer.Deserialize<PersistedState>(json, opts);
                    if (state != null)
                    {
                        var est = new Estacionamento(state.PrecoInicial, state.PrecoPorHora);
                        est.veiculos.AddRange(state.Veiculos ?? new List<Veiculo>());
                        est.historico.AddRange(state.Historico ?? new List<HistoricoEntry>());
                        return est;
                    }
                }
            }
            catch
            {
                // se falhar ao ler, ignorar e criar novo
            }

            MenuUI.DrawHeader("SISTEMA DE ESTACIONAMENTO");
            Console.WriteLine("Arquivo de dados não encontrado. Vamos configurar os preços iniciais.\n");
            decimal inicial = ReadDecimalInitial("Digite o preço inicial (ex: 5,50):");
            MenuUI.DrawHeader("SISTEMA DE ESTACIONAMENTO");
            decimal porHora = ReadDecimalInitial("Agora digite o preço por hora (ex: 2,00):");

            var created = new Estacionamento(inicial, porHora);
            created.Persist();
            return created;
        }

        private static decimal ReadDecimalInitial(string prompt)
        {
            decimal value;
            var culture = CultureInfo.GetCultureInfo("pt-BR");

            while (true)
            {
                MenuUI.DrawHeader("SISTEMA DE ESTACIONAMENTO");
                Console.WriteLine(prompt);
                Console.Write("> ");
                var input = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(input))
                    input = input.Replace(" ", "").Replace('.', ',');

                if (decimal.TryParse(input, System.Globalization.NumberStyles.Number, culture, out value))
                    return Math.Round(value, 2);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Valor inválido. Digite um número como 5,50 ou 5.50");
                Console.ResetColor();
            }
        }

        public void AdicionarVeiculo()
        {
            MenuUI.DrawHeader("SISTEMA DE ESTACIONAMENTO");
            Console.Write("\nDigite a placa do veículo para estacionar: ");
            string placa = Console.ReadLine()?.Trim().ToUpper();

            if (!PlacaValida(placa))
                return;

            if (veiculos.Any(v => v.Placa == placa))
            {
                EscreverErro("❌ Este veículo já está estacionado.");
                return;
            }

            var v = new Veiculo(placa);
            veiculos.Add(v);
            Persist();

            EscreverSucesso($"✔ Veículo {placa} estacionado às {v.Entrada:dd/MM/yyyy HH:mm}.");
        }

        public void RemoverVeiculo()
        {
            MenuUI.DrawHeader("SISTEMA DE ESTACIONAMENTO");
            Console.Write("\nDigite a placa do veículo para remover: ");
            string placa = Console.ReadLine()?.Trim().ToUpper();

            if (!PlacaValida(placa))
                return;

            var veiculo = veiculos.FirstOrDefault(v => v.Placa == placa);
            if (veiculo == null)
            {
                EscreverErro("❌ Esse veículo não está estacionado.");
                return;
            }

            MenuUI.DrawHeader("SISTEMA DE ESTACIONAMENTO");
            Console.WriteLine($"Entrada registrada em: {veiculo.Entrada:dd/MM/yyyy HH:mm}");
            Console.Write("Digite horas (ENTER = auto calcular): ");
            string horasInput = Console.ReadLine();

            double horas;
            if (string.IsNullOrWhiteSpace(horasInput))
            {
                var diff = DateTime.Now - veiculo.Entrada;
                horas = Math.Ceiling(diff.TotalHours);

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"🕒 Horas calculadas automaticamente: {horas}h (total real: {diff.TotalHours:F2}h)");
                Console.ResetColor();
            }
            else if (!double.TryParse(horasInput.Replace(',', '.'), System.Globalization.NumberStyles.Number, CultureInfo.InvariantCulture, out horas) || horas < 0)
            {
                EscreverErro("❌ Valor inválido para horas.");
                return;
            }

            decimal valor = precoInicial + (decimal)horas * precoPorHora;
            valor = Math.Round(valor, 2);

            veiculos.Remove(veiculo);
            var entry = new HistoricoEntry
            {
                Placa = veiculo.Placa,
                Entrada = veiculo.Entrada,
                Saida = DateTime.Now,
                Horas = horas,
                Valor = valor
            };
            historico.Add(entry);
            Persist();

            EscreverAviso($"\n⚠ Veículo {placa} removido.");
            EscreverSucesso($"💰 Total a pagar: {valor.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");
        }

        public void ListarVeiculos()
        {
            MenuUI.DrawHeader("SISTEMA DE ESTACIONAMENTO");
            Console.WriteLine();
            if (!veiculos.Any())
            {
                EscreverAviso("Nenhum veículo estacionado.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("VEÍCULOS ESTACIONADOS");
            Console.ResetColor();
            Console.WriteLine("Placa".PadRight(12) + "Entrada");
            Console.WriteLine(new string('-', 35));

            foreach (var v in veiculos)
            {
                Console.WriteLine(
                    v.Placa.PadRight(12) +
                    v.Entrada.ToString("dd/MM/yyyy HH:mm")
                );
            }
        }

        public void MostrarResumo()
        {
            MenuUI.DrawHeader("SISTEMA DE ESTACIONAMENTO");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("HISTÓRICO DE REMOÇÕES");
            Console.ResetColor();

            if (!historico.Any())
            {
                EscreverAviso("Nenhuma remoção registrada ainda.");
                return;
            }

            Console.WriteLine("Placa".PadRight(12) +
                              "Entrada".PadRight(20) +
                              "Saída".PadRight(20) +
                              "Horas".PadRight(8) +
                              "Valor");

            Console.WriteLine(new string('-', 70));

            foreach (var h in historico)
            {
                Console.WriteLine(
                    h.Placa.PadRight(12) +
                    h.Entrada.ToString("dd/MM/yyyy HH:mm").PadRight(20) +
                    h.Saida.ToString("dd/MM/yyyy HH:mm").PadRight(20) +
                    h.Horas.ToString().PadRight(8) +
                    h.Valor.ToString("C", CultureInfo.GetCultureInfo("pt-BR"))
                );
            }

            Console.WriteLine("\nVagas atualmente ocupadas: " + veiculos.Count);
            Console.WriteLine("Total faturado: " + historico.Sum(x => x.Valor).ToString("C", CultureInfo.GetCultureInfo("pt-BR")));
        }

        public void UpdatePrecos(decimal novoInicial, decimal novoPorHora)
        {
            this.precoInicial = Math.Round(novoInicial, 2);
            this.precoPorHora = Math.Round(novoPorHora, 2);
            Persist();
        }

        private bool PlacaValida(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
            {
                EscreverErro("❌ Placa não pode ser vazia.");
                return false;
            }

            var normalized = placa.Replace("-", "").ToUpper();

            var oldPattern = @"^[A-Z]{3}[0-9]{4}$";
            var mercosulPattern = @"^[A-Z]{3}[0-9][A-Z0-9][0-9]{2}$";

            if (!Regex.IsMatch(normalized, oldPattern) && !Regex.IsMatch(normalized, mercosulPattern))
            {
                EscreverErro("❌ Placa inválida. Use formato ABC1234 ou ABC1D23 (Mercosul).");
                return false;
            }

            return true;
        }

        private void EscreverErro(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        private void EscreverSucesso(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        private void EscreverAviso(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        private void Persist()
        {
            try
            {
                var state = new PersistedState
                {
                    PrecoInicial = this.precoInicial,
                    PrecoPorHora = this.precoPorHora,
                    Veiculos = new List<Veiculo>(this.veiculos),
                    Historico = new List<HistoricoEntry>(this.historico)
                };

                var opts = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters = { new JsonStringEnumConverter() }
                };

                var json = JsonSerializer.Serialize(state, opts);
                File.WriteAllText(DataFile, json);
            }
            catch
            {
                // não falhar a execução do app em caso de erro de IO
            }
        }
    }
}
