namespace RomanNumberConverter.Tests;

public class UnitTests
{
    private Converter _converter;
    
    [SetUp]
    public void Setup()
    {
        _converter = new Converter();
    }

    [TestCase(null, "INVALID_INPUT")]
    [TestCase("", "INVALID_INPUT")]
    [TestCase("TEST", "INVALID_INPUT")]
    [TestCase("XP", "INVALID_INPUT")]
    [TestCase("IIX", "INVALID_INPUT")]
    [TestCase("VX", "INVALID_INPUT")]
    [TestCase("XIIII", "INVALID_INPUT")]
    [TestCase("IIII", "INVALID_INPUT")]
    public void Convert_InvalidInput_ShouldReturnError(string? romanNumber, string expectedErrorMessage)
    {
        var result = _converter.RomanNumberToDecimal(romanNumber);
        
        Assert.That(result.Error, Is.EqualTo(expectedErrorMessage));
        Assert.That(result.Value, Is.Null);
    }
    
    [TestCase("I", 1)]
    [TestCase("V", 5)]
    [TestCase("X", 10)]
    [TestCase("L", 50)]
    [TestCase("C", 100)]
    [TestCase("D", 500)]
    [TestCase("M", 1000)]
    [TestCase("XX", 20)]
    [TestCase("IV", 4)]
    [TestCase("VI", 6)]
    [TestCase("XXIX", 29)]
    [TestCase("XIII", 13)]
    public void Convert_ValidInput_ShouldReturnExpectedValue(string romanNumber, int expectedValue)
    {
        var result = _converter.RomanNumberToDecimal(romanNumber);
            
        Assert.That(result.Value, Is.EqualTo(expectedValue));
    }
}