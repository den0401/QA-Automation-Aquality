using System;
using System.Text;

namespace Aquality.Selenium.Template.Utilities
{
    public static class DataGenerator
    {
        public static string GeneratePassword() => GenerateRandomSymbols(26, 65).ToLower()
            + GenerateRandomSymbols(26, 65) + GenerateRandomSymbols(10, 48) + GenerateRandomSymbols(15, 33);

        public static string GenerateEmail(string password) => password.Remove(3);

        public static string GenerateRandomSymbols(int asciiSymbolsQuantity, int asciiFirstSymol)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();

            char ch;

            for (int i = 0; i < 4; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(asciiSymbolsQuantity * random.NextDouble() + asciiFirstSymol)));
                stringBuilder.Append(ch);
            }

            return stringBuilder.ToString();
        }
    }
}
