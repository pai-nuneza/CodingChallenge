// Check if a number given has 3 or more decimals

bool HasThreeDecimals(double number)
{
    string numberString = number.ToString();
    int decimalIndex = numberString.IndexOf('.');

    if (decimalIndex == -1)
    {
        return false;
    }

    int decimalPlaces = numberString.Length - decimalIndex - 1;

    var hasThree = decimalPlaces >= 3;
    return hasThree;

}


HasThreeDecimals(123.457); // Returns true
HasThreeDecimals(123.45);  // Returns false
HasThreeDecimals(123.4545);  // Returns true