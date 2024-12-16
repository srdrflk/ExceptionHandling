using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null)
                throw new ArgumentNullException("Input string cannot be null.");

            stringValue = stringValue.Trim();

            if (stringValue.Length == 0)
                throw new FormatException("Input string is empty or only contains whitespace.");

            bool isNegative = stringValue[0] == '-';
            int startIndex = (stringValue[0] == '+' || stringValue[0] == '-') ? 1 : 0;


            int result = 0;
            for (int i = startIndex; i < stringValue.Length; i++)
            {
                char chr = stringValue[i];
                if (chr < '0' || chr > '9')
                    throw new FormatException($"Input string contains invalid character '{chr}'.");

                int digit = chr - '0';

                // Overflow check
                int tempResult = result * 10 + digit;
                if ((isNegative && -tempResult > 0) || (!isNegative && tempResult < 0))
                {
                    throw new OverflowException("Numeric value is out of Int32 range.");
                }
                else
                {
                    result = tempResult;
                }
            }

            if (isNegative)
            {
                // When condition matches exactly to the edge case of int.MinValue without overflow exception
                if (stringValue == "-2147483648")
                {
                    return int.MinValue;
                }
                else
                {
                    return -result;
                }
            }

            return result;
        }
    }
}
