using System;

public static class MenuUI
{
    public static void DrawHeader(string title)
    {
        Console.Clear();

        int consoleWidth = 80;
        try
        {
            consoleWidth = Console.WindowWidth - 4;
        }
        catch
        {
            // ambiente que não suporta WindowWidth
        }

        int maxWidth = Math.Min(60, consoleWidth);
        int minWidth = 20;
        int width = Math.Max(minWidth, maxWidth);

        string border = new string('═', width);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"╔{border}╗");
        var centered = title.PadLeft((width + title.Length) / 2).PadRight(width);
        Console.WriteLine($"║{centered}║");
        Console.WriteLine($"╚{border}╝\n");
        Console.ResetColor();
    }

    public static int Menu(string titulo, string[] opcoes)
    {
        int index = 0;
        ConsoleKey key;

        do
        {
            DrawHeader(titulo);

            for (int i = 0; i < opcoes.Length; i++)
            {
                if (i == index)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"> {opcoes[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {opcoes[i]}");
                }
            }

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow) index = (index == 0) ? opcoes.Length - 1 : index - 1;
            else if (key == ConsoleKey.DownArrow) index = (index == opcoes.Length - 1) ? 0 : index + 1;

        } while (key != ConsoleKey.Enter);

        return index;
    }
}
