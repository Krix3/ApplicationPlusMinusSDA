using System;
using System.Collections.Generic;

class SimpleCalculator
{
    static void Main()
    {
        Console.WriteLine("Введите арифметическое выражение (поддерживаются только + и -):");
        string input = Console.ReadLine();

        try
        {
            double result = EvaluateExpression(input);
            Console.WriteLine($"Результат: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    static double EvaluateExpression(string expression)
    {
        List<double> numbers = new List<double>();
        List<char> operators = new List<char>();
        int i = 0;
        while (i < expression.Length)
        {
            if (char.IsDigit(expression[i]) || (expression[i] == '-' && (i == 0 || !char.IsDigit(expression[i - 1]))))
            {
                string numberStr = "";
                while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.' || expression[i] == '-'))
                {
                    numberStr += expression[i];
                    i++;
                }
                if (double.TryParse(numberStr, out double number))
                {
                    numbers.Add(number);
                }
                else
                {
                    throw new ArgumentException("Неверный формат числа.");
                }
            }
            else if (expression[i] == '+' || expression[i] == '-')
            {
                operators.Add(expression[i]);
                i++;
            }
            else if (char.IsWhiteSpace(expression[i]))
            {
                i++;
            }
            else
            {
                throw new ArgumentException($"Недопустимый символ: {expression[i]}");
            }
        }

        if (numbers.Count == 0)
        {
            throw new ArgumentException("Выражение не содержит чисел.");
        }

        double result = numbers[0];
        for (int j = 0; j < operators.Count; j++)
        {
            if (operators[j] == '+')
            {
                result += numbers[j + 1];
            }
            else if (operators[j] == '-')
            {
                result -= numbers[j + 1];
            }
        }

        return result;
    }
}