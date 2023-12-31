using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace DesafioFundamentos.util
{
    public static class StringUtils
    {
        public static bool IsInteger(string input)
        {
            return int.TryParse(input, out _);
        }

        public static bool IsPlacaValida(string placaVeiculo)
        {
            // Padrões para placas de veículo brasileiras: ABC1D23 ou ABC1234
            string pattern1 = @"^[A-Z]{3}\d[A-Z]\d{2}$";
            string pattern2 = @"^[A-Z]{3}\d{4}$";

            // Verifica se a placa corresponde a um dos padrões
            return Regex.IsMatch(placaVeiculo, pattern1) || Regex.IsMatch(placaVeiculo, pattern2);
        }
    }
}