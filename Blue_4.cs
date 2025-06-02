using Lab8;
using System;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        private int _sumResult;

        public int Output => _sumResult;

        public Blue_4(string input) : base(input)
        {
            _sumResult = 0;
        }

        private string ExtractNumberString(string source, ref int startPosition)
        {
            if (startPosition >= source.Length || startPosition < 0)
                return null;
            while (startPosition < source.Length && !char.IsDigit(source[startPosition]))
            {
                startPosition++;
            }

            if (startPosition == source.Length)
                return null;
            string numberString = "";
            if (startPosition > 0 && source[startPosition - 1] == '-')
                numberString += "-";
            else
                numberString += "+";
            while (startPosition < source.Length && char.IsDigit(source[startPosition]))
            {
                numberString += source[startPosition];
                startPosition++;
            }

            return numberString;
        }

        private int ConvertToNumber(string numberString)
        {
            if (string.IsNullOrEmpty(numberString))
            {  
                return 0; 
            }

            bool isNegative = numberString[0] == '-';
            int result = 0;

            for (int i = 1; i < numberString.Length; i++)
            {
                result = result * 10 + (numberString[i] - '0');
            }

            if (result < 0)
            {
                return -result;
            }
            else
            {
                return result;
            }
        }

        public override void Review()
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                _sumResult = 0;
                return;
            }

            int currentPosition = 0;
            while (currentPosition < input.Length)
            {
                string numberAsString = ExtractNumberString(input, ref currentPosition);
                if (numberAsString == null)
                    break;

                _sumResult += ConvertToNumber(numberAsString);
            }
        }

        public override string ToString()
        {
            return Output.ToString();
        }
    }
}
