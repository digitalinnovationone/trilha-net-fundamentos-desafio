namespace DesafioFundamentos.Helpers
{
    public static class ValidacaoDeInputs
    {
        public static bool PlacaValida(string placa)
        {
            // Verifica o comprimento e o hífen na posição correta
            if (placa.Length != 8 || placa[3] != '-')
                return false;

            // Verifica se os 3 primeiros são letras
            for (int i = 0; i < 3; i++)
            {
                if (!char.IsLetter(placa[i]))
                    return false;
            }

            // Verifica se os 4 últimos são números
            for (int i = 4; i < 8; i++)
            {
                if (!char.IsDigit(placa[i]))
                    return false;
            }

            return true;
        }

        public static string FormatarPlaca(string placa)
        {
            return placa.ToUpper().Trim();
        }

        public static bool HoraValida(string entrada)
        {
            // Tenta converter a string para inteiro
            if (!int.TryParse(entrada, out int hora))
                return false;

            // Verifica se está dentro do intervalo de horas válidas
            return hora >= 0 && hora <= 23;
        }       

    }
}