using System;
using System.Text;

namespace Aquality.Selenium.Template.Utilities
{
    public class DataGenerator
    {
        private readonly int _asciiUpperLettersQuantity = 26;
        private readonly int _asciiALetter = 65;
        private readonly int _asciiNumbersQuantity = 10;
        private readonly int _ascii0Number = 48;
        private readonly int _asciiSymbolsQuantity = 15;
        private readonly int _asciiExclamationMarkSymbol = 33;

        public string GeneratePassword() => GenerateRandomSymbols(_asciiUpperLettersQuantity, _asciiALetter).ToLower()
            + GenerateRandomSymbols(_asciiUpperLettersQuantity, _asciiALetter)
            + GenerateRandomSymbols(_asciiNumbersQuantity, _ascii0Number)
            + GenerateRandomSymbols(_asciiSymbolsQuantity, _asciiExclamationMarkSymbol);

        public string GenerateEmail(string password) => password.Remove(3);

        protected string GenerateRandomSymbols(int asciiSymbolsQuantity, int asciiFirstSymbol)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();

            int quantityOfEachSymbolType = 3;
            char ch;

            for (int i = 1; i <= quantityOfEachSymbolType; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(asciiSymbolsQuantity * random.NextDouble() + asciiFirstSymbol)));
                stringBuilder.Append(ch);
            }

            return stringBuilder.ToString();
        }
    }
}
