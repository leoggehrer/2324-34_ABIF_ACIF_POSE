# Considerations on the addition of binary numbers

## Possible situations

| carry  |  num1  |  num2  | result | carry' |
| :----: | :----: | :----: | :----: | :----: |
|   0    |    0   |    0   |    0   |    0   |
|   0    |    0   |    1   |    1   |    0   |
|   0    |    1   |    0   |    1   |    0   |
|   0    |    1   |    1   |    0   |    1   |
|   1    |    0   |    0   |    1   |    0   |
|   1    |    0   |    1   |    0   |    1   |
|   1    |    1   |    0   |    0   |    1   |
|   1    |    1   |    1   |    1   |    1   |

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
