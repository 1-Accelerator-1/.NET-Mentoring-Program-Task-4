using System;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            int intValue = default;
            char firstCharacter = '+';

            if (stringValue == null)
            {
                throw new ArgumentNullException();
            }

            stringValue = stringValue.Trim();
            
            if (string.IsNullOrEmpty(stringValue))
            {
                throw new FormatException();
            }

            if (stringValue[0] == '+' || stringValue[0] == '-')
            {
                firstCharacter = stringValue[0];
                stringValue = stringValue.Substring(1);
            }

            stringValue = RemoveFirstZeroNumbers(stringValue);

            foreach (var character in stringValue)
            {
                if (!char.IsNumber(character))
                {
                    throw new FormatException();
                }
            }

            for (int i = 0; i < stringValue.Length; i++)
            {
                int num = (int)char.GetNumericValue(stringValue[i]);
                
                for (int j = i + 1; j < stringValue.Length; j++)
                {
                    num *= 10;
                }

                num *= firstCharacter == '+' ? +1 : -1;

                intValue += num;
            }

            if (((intValue.ToString().Length < stringValue.Length) && ((intValue * -1).ToString().Length < stringValue.Length)) ||
                (intValue < 0 && firstCharacter == '+') ||
                (intValue > 0 && firstCharacter == '-'))
            {
                throw new OverflowException();
            }

            return intValue;
        }

        private string RemoveFirstZeroNumbers(string stringValue)
        {
            for (int i = 0; i < stringValue.Length; i++)
            {
                if (stringValue[i] != '0')
                {
                    return stringValue.Substring(i);
                }
            }

            return stringValue;
        }
    }
}