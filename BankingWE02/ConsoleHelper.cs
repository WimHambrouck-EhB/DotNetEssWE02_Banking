using System;
using System.Collections.Generic;
using System.Text;

namespace WE02Console
{
    static class ConsoleHelper
    {
        public static void TekenKader(string titel, bool dubbel = true)
        {
            char horizontaal = '─';
            char verticaal = '│';
            char linksBoven = '┌';
            char linksOnder = '└';
            char rechtsBoven = '┐';
            char rechtsOnder = '┘';

            if (dubbel)
            {
                horizontaal = '═';
                verticaal = '║';
                linksBoven = '╔';
                linksOnder = '╚';
                rechtsBoven = '╗';
                rechtsOnder = '╝';
            }

            Console.Write(linksBoven);
            for (int i = 0; i < titel.Length + 14; i++)
            {
                Console.Write(horizontaal);
            }
            Console.WriteLine(rechtsBoven);

            Console.WriteLine(verticaal + "       " + titel + "       " + verticaal);

            Console.Write(linksOnder);
            for (int i = 0; i < titel.Length + 14; i++)
            {
                Console.Write(horizontaal);
            }
            Console.WriteLine(rechtsOnder);
        }

        public static int Menu(List<string> opties, string quit = "Quit")
        {
            for (int i = 0; i < opties.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {opties[i]}");
            }
            Console.WriteLine("0 - " + quit);

            return SafeInt("Choose an option: ", 0, opties.Count);
        }

        private static int SafeInt(string vraag, int min = int.MinValue, int max = int.MaxValue)
        {
            Console.Write(vraag);
            string consoleInput = Console.ReadLine();
            int input;

            while (!int.TryParse(consoleInput.ToString(), out input) || input < min || input > max)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(vraag);
                consoleInput = Console.ReadLine();
            }

            return input;
        }

    }
}
