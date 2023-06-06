using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        string infixExpression =Console.ReadLine();
        string postfixExpression = ConvertToPostfix(infixExpression);
        Console.WriteLine("Lengyel forma: " + postfixExpression);

        Console.ReadKey();
    }

    public static string ConvertToPostfix(string infixExpression)
    {
        Dictionary<char, int> precedence = new Dictionary<char, int>();
        precedence.Add('+', 1);
        precedence.Add('-', 1);
        precedence.Add('*', 2);
        precedence.Add('/', 2);
        precedence.Add('^', 3);

        Stack<char> operators = new Stack<char>();
        string postfix = "";

        foreach (char c in infixExpression)
        {
            if (char.IsDigit(c))
            {
                postfix += c;
            }
            else if (c == '(')
            {
                operators.Push(c);
            }
            else if (c == ')')
            {
                while (operators.Count > 0 && operators.Peek() != '(')
                {
                    postfix += operators.Pop();
                }

                operators.Pop();
            }
            else if (precedence.ContainsKey(c))
            {
                while (operators.Count > 0 && operators.Peek() != '(' && precedence[c] <= precedence[operators.Peek()])
                {
                    postfix += operators.Pop();
                }

                operators.Push(c);
            }
        }

        while (operators.Count > 0)
        {
            postfix += operators.Pop();
        }

        return postfix;
    }
}
