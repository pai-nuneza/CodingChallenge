/* 

This code accepts roman numerals and convert that to its shortest form. 

    Sample:
    Input: XXXVVIIIIIIIIII
    Output: L

    Because the total of the input is equals to L which means L is 50.
        X = 10 x 3 = 30
        V = 5 x 2 = 10
        I = 1 x 10 = 10

*/

string RomanNumeralReduction(string str)
{
    Dictionary<char, int> romanValues = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

    int result = 0;
    for (int i = 0; i < str.Length; i++)
    {
        if (i < str.Length - 1 && romanValues[str[i]] < romanValues[str[i + 1]])
            result -= romanValues[str[i]];
        else
            result += romanValues[str[i]];
    }
    return ToRomanNumeral(result);
}

string ToRomanNumeral(int number)
{
    if (number < 1 || number > 3999)
        throw new ArgumentOutOfRangeException("Number out of range (1 to 3999).");

    Dictionary<int, string> romanNumerals = new Dictionary<int, string>
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" }
        };

    string result = "";
    foreach (var numeral in romanNumerals)
    {
        while (number >= numeral.Key)
        {
            result += numeral.Value;
            number -= numeral.Key;
        }
    }

    return result;
}


Console.WriteLine(RomanNumeralReduction("XXXVVIIIIIIIIII")); // Output: L
Console.WriteLine(RomanNumeralReduction("DDLL")); // Output: MC
Console.WriteLine(RomanNumeralReduction("DDDD")); // Output: LL
Console.WriteLine(RomanNumeralReduction("DDDDCCCCC")); // Output: LLD
