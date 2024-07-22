using RomanNumberConverter;

Console.WriteLine("Insert a roman number");
var input = Console.ReadLine();

var converter = new Converter();
var result = converter.RomanNumberToDecimal(input);

Console.WriteLine(result.ToString());
Console.ReadLine();