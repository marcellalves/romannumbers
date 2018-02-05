using System;
using Xunit;

namespace RomanNumber.Tests
{
    public class RomanNumberTest
    {
        [Fact]
        public void ToArabicNumber_SingleDigitRomanNumber_CorrectArabicNumber()
        {
            var romanNumber = new Core.RomanNumber();

            var arabicNumber = romanNumber.ToArabicNumber("I");

            Assert.Equal(1, arabicNumber);
        }

        [Fact]
        public void ToArabicNumber_DoubleEqualDigitRomanNumber_CorrectArabicNumber()
        {
            var romanNumber = new Core.RomanNumber();

            var arabicNumber = romanNumber.ToArabicNumber("II");

            Assert.Equal(2, arabicNumber);
        }

        [Fact]
        public void ToArabicNumber_LowerValueInLeftRomanNumber_CorrectArabicNumber()
        {
            var romanNumber = new Core.RomanNumber();

            var arabicNumber = romanNumber.ToArabicNumber("IV");

            Assert.Equal(4, arabicNumber);
        }

        [Fact]
        public void ToArabicNumber_HigherValueInLeftRomanNumber_CorrectArabicNumber()
        {
            var romanNumber = new Core.RomanNumber();

            var arabicNumber = romanNumber.ToArabicNumber("VI");

            Assert.Equal(6, arabicNumber);
        }

        [Fact]
        public void ToArabicNumber_ThreeDigitRomanNumber_CorrectArabicNumber()
        {
            var romanNumber = new Core.RomanNumber();

            var arabicNumber = romanNumber.ToArabicNumber("III");

            Assert.Equal(3, arabicNumber);
        }

        [Fact]
        public void ToArabicNumber_SingleDigitInvalidRomanNumber_ThrowsException()
        {
            var romanNumber = new Core.RomanNumber();

            Assert.Throws<Exception>(() => romanNumber.ToArabicNumber("A"));
        }

        [Fact]
        public void ToArabicNumber_RomanNumberWithInvalidPair_ThrowsException()
        {
            var romanNumber = new Core.RomanNumber();

            Assert.Throws<Exception>(() => romanNumber.ToArabicNumber("IL"));
        }

        [Fact]
        public void ToArabicNumber_RomanNumberWithDuplicatedD_ThrowsException()
        {
            var romanNumber = new Core.RomanNumber();

            Assert.Throws<Exception>(() => romanNumber.ToArabicNumber("DD"));
        }

        [Fact]
        public void ToArabicNumber_RomanNumberWithDuplicatedL_ThrowsException()
        {
            var romanNumber = new Core.RomanNumber();

            Assert.Throws<Exception>(() => romanNumber.ToArabicNumber("LL"));
        }

        [Fact]
        public void ToArabicNumber_RomanNumberWithDuplicatedV_ThrowsException()
        {
            var romanNumber = new Core.RomanNumber();

            Assert.Throws<Exception>(() => romanNumber.ToArabicNumber("VV"));
        }

        [Fact]
        public void ToArabicNumber_RomanNumberWithMoreThan4OccurencesOfI_ThrowsException()
        {
            var romanNumber = new Core.RomanNumber();

            Assert.Throws<Exception>(() => romanNumber.ToArabicNumber("IIIII"));
        }

        [Fact]
        public void ToArabicNumber_RomanNumberWithMoreThan4OccurencesOfX_ThrowsException()
        {
            var romanNumber = new Core.RomanNumber();

            Assert.Throws<Exception>(() => romanNumber.ToArabicNumber("XXXXX"));
        }

        [Fact]
        public void ToArabicNumber_RomanNumberWithMoreThan4OccurencesOfC_ThrowsException()
        {
            var romanNumber = new Core.RomanNumber();

            Assert.Throws<Exception>(() => romanNumber.ToArabicNumber("CCCCC"));
        }

        [Fact]
        public void ToArabicNumber_RomanNumberWithMoreThan4OccurencesOfM_ThrowsException()
        {
            var romanNumber = new Core.RomanNumber();

            Assert.Throws<Exception>(() => romanNumber.ToArabicNumber("MMMMM"));
        }

        [Fact]
        public void ToArabicNumber_RomanNumberValidFourOccurencesOfSameDigit_CorrectArabicNumber()
        {
            var romanNumber = new Core.RomanNumber();

            var arabicNumber = romanNumber.ToArabicNumber("XXXIX");

            Assert.Equal(39, arabicNumber);
        }
    }
}
