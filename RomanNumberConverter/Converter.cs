using RomanNumberConverter.Shared;

namespace RomanNumberConverter;

public class Converter
{
    private const string InvalidInputErrorMessage = "INVALID_INPUT";
    private const char One = 'I',
        Five = 'V',
        Ten = 'X',
        Fifty = 'L',
        OneHundred = 'C',
        FiveHundred = 'D',
        OneThousand = 'M';
    private readonly ICollection<char> _validRomanNumbers = new List<char> 
    {
        One, Five, Ten, Fifty, OneHundred, FiveHundred, OneThousand
    };
    
    public Either<int?, string?> RomanNumberToDecimal(string inputRomanNumber)
    {
        if (!IsValid(inputRomanNumber))
            return Either<int?, string?>.Left(InvalidInputErrorMessage);
        
        var convertedNumbers = inputRomanNumber
            .Select(ConvertRomanDigitToDigit)
            .ToArray();

        var total = convertedNumbers[^1];
        for (var counter = convertedNumbers.Length - 1; counter > 0; counter--)
        {
            var previousNumber = convertedNumbers[counter - 1];
            var currentNumber = convertedNumbers[counter];
            if (previousNumber < currentNumber)
                total -= previousNumber;
            else
                total += previousNumber;
        }

        return Either<int?, string?>.Right(total);
    }

    private bool IsValid(string numbers)
    {
        return !string.IsNullOrWhiteSpace(numbers) && numbers.All(ch => _validRomanNumbers.Contains(ch));
    }
    
    private int ConvertRomanDigitToDigit(char romanDigit)
    {
        return romanDigit switch
        {
            One => 1,
            Five => 5,
            Ten => 10,
            Fifty => 50,
            OneHundred => 100,
            FiveHundred => 500,
            OneThousand => 1000
        };
    }
}