# Considerations on the addition of binary numbers

## Possible situations

| carry  |  num1  |  num2  | result | carry' |
| :----: | :----: | :----: | :----: | :----: |
|   0    |    0   |    0   |    0   |    0   |
|   0    |    0   |    1   |  **1** |    0   |
|   0    |    1   |    0   |  **1** |    0   |
|   0    |    1   |    1   |    0   |  **1** |
|   1    |    0   |    0   |  **1** |    0   |
|   1    |    0   |    1   |    0   |  **1** |
|   1    |    1   |    0   |    0   |  **1** |
|   1    |    1   |    1   |  **1** |  **1** |

### Conversion into a CSharp program

```csharp
if (carry == false && number1[i] == '0' && number2[i] == '0')
{
    result = '0' + result;
}
else if (carry == false && number1[i] == '1' && number2[i] == '0')
{
    result = '1' + result;
}
else if (carry == false && number1[i] == '0' && number2[i] == '1')
{
    result = '1' + result;
}
else if (carry == false && number1[i] == '1' && number2[i] == '1')
{
    carry = true;
    result = '0' + result;
}
else if (carry && number1[i] == '0' && number2[i] == '0')
{
    carry = false;
    result = '1' + result;
}
else if (carry && number1[i] == '1' && number2[i] == '0')
{
    result = '0' + result;
}
else if (carry && number1[i] == '0' && number2[i] == '1')
{
    result = '0' + result;
}
else if (carry && number1[i] == '1' && number2[i] == '1')
{
    result = '1' + result;
}
```

## Information on formatting the binary number

The binary number is extended with zeros to a length divisible by 4.

```csharp
int expandLength = 8 - number.Length % 8 + number.Length;

// A space is added after every 4 digits.
for (int i = 0; i < number.Length; i++)
{
    if (i > 0 && i % 8 == 0)
    {
        result += ' ';
    }
    result += number[i];
}
```
