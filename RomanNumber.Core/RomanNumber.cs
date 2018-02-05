using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RomanNumber.Core
{
    public class RomanNumber
    {
        public int ToArabicNumber(string romanNumber)
        {
            if (!IsValid(romanNumber))
            {
                throw new Exception("Invalid roman number");
            }

            _romanNumber = romanNumber.ToCharArray();

            return ToArabicNumber();
        }

        private bool IsValid(string romanNumber)
        {
            return !string.IsNullOrEmpty(romanNumber) && 
                    Regex.IsMatch(romanNumber, @"^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$");
        }

        private int ToArabicNumber(int next = 0, int convertedArabicNumber = 0)
        {
            var nextSibling = next + 1;

            if (next >= _romanNumber.Length)
            {
                return convertedArabicNumber;
            }

            if (nextSibling == _romanNumber.Length)
            {
                convertedArabicNumber += RomanDigitToArabicNumber(_romanNumber[next]);
                return convertedArabicNumber;
            }

            var leftValue = RomanDigitToArabicNumber(_romanNumber[next]);
            var rightValue = RomanDigitToArabicNumber(_romanNumber[nextSibling]);

            if (leftValue < rightValue)
            {
                convertedArabicNumber += rightValue - leftValue;
                return ToArabicNumber(next + 2, convertedArabicNumber);
            }
            else
            {
                convertedArabicNumber += leftValue;
                return ToArabicNumber(next + 1, convertedArabicNumber);
            }
        }

        private int RomanDigitToArabicNumber(char romanDigit)
        {
            return _romanToArabic[romanDigit];
        }

        private char[] _romanNumber;

        private readonly IDictionary<char, int> _romanToArabic = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };
    }
}
