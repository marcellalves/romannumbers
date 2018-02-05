using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RomanNumber.Core
{
    public class RomanNumber
    {
        public int ToArabicNumber(string romanNumber)
        {
            _romanNumber = romanNumber.ToCharArray();

            if (!ValidRepetitionRules())
            {
                throw new Exception(_exceptionMessage);
            }

            return ToArabicNumber(0, 0);
        }

        private bool ValidRepetitionRules()
        {
            var romanNumber = _romanNumber.ToList();

            if (romanNumber.Count(d => d.Equals('D')) > 1 ||
                romanNumber.Count(d => d.Equals('L')) > 1 ||
                romanNumber.Count(d => d.Equals('V')) > 1)
            {
                return false;
            }

            if (romanNumber.Count(d => d.Equals('I')) > 4 ||
                romanNumber.Count(d => d.Equals('X')) > 4 ||
                romanNumber.Count(d => d.Equals('C')) > 4 ||
                romanNumber.Count(d => d.Equals('M')) > 4)
            {
                return false;
            }

            var match = Regex.Match(romanNumber.ToString(), "I{3}|X{3}|C{3}|M{3}");
            while (match.Success)
            {
                var matchIndex = match.Index;
                if (_romanNumber.Length >= matchIndex + 4)
                {
                    if (_romanNumber[matchIndex + 4] == match.Value.ToCharArray()[0])
                    {
                        return false;
                    }
                    else
                    {
                        if (_romanNumber.Length >= matchIndex + 5)
                        {
                            if (_romanNumber[matchIndex + 5] == match.Value.ToCharArray()[0] 
                                && RomanDigitToArabicNumber(_romanNumber[matchIndex + 5]) < RomanDigitToArabicNumber(match.Value.ToCharArray()[0]))
                            {
                                return false;
                            }
                        }
                    }
                }

                match = match.NextMatch();
            }

            return true;
        }

        private int ToArabicNumber(int next, int convertedArabicNumber)
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
                convertedArabicNumber += RomanPairToArabicNumber(_romanNumber[next], _romanNumber[nextSibling]);
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
            if (!_romanToArabic.TryGetValue(romanDigit, out int arabicNumber))
            {
                throw new Exception(_exceptionMessage);
            }

            return arabicNumber;
        }

        private int RomanPairToArabicNumber(char leftDigit, char rightDigit)
        {
            if (!IsValidPair(leftDigit.ToString() + rightDigit.ToString()))
            {
                throw new Exception(_exceptionMessage);
            }

            return RomanDigitToArabicNumber(rightDigit) - RomanDigitToArabicNumber(leftDigit);
        }

        private bool IsValidPair(string pair)
        {
            return !_invalidRomanPairs.Contains(pair);
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

        private readonly IList<string> _invalidRomanPairs = new List<string>
        {
            "IL",
            "IC",
            "ID",
            "IM",
            "XD",
            "XM",
            "VX",
            "VL",
            "VC",
            "VD",
            "VM",
            "LC",
            "LD",
            "LM",
            "DM"
        };

        private const string _exceptionMessage = "Invalid roman number";
    }
}
