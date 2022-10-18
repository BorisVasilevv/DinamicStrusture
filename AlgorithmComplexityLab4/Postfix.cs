using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmComplexityLab4
{
    class Postfix
    {
        public static int prec(char c)
        {
            if (c == '*' || c == '/')
            {
                return 3;
            }

            if (c == '+' || c == '-')
            {
                return 4;
            }

            if (c == '&')
            {
                return 8;
            }

            if (c == '^')
            {
                return 9;
            }

            if (c == '|')
            {
                return 10;
            }

            return 99999;
        }

        public static bool isOperand(char c)
        {
            return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9');
        }

        public static string infixToPostfix(string infix)
        {
            MyStack<char> s = new MyStack<char>();
            string postfix = "";
            char[] CH = infix.ToCharArray();

            foreach (char c in CH)
            {
                if (c == '(')
                {
                    s.Push(c);
                }

                else if (c == ')')
                {
                    while (s.Top().Data != '(')
                    {
                        postfix += s.Top().Data;
                        s.Pop();
                    }
                    s.Pop();
                }

                // Случай 3. Если текущий токен является операндом, добавляем его в конец
                // постфиксное выражение
                else if (isOperand(c))
                {
                    postfix += c;
                }

                else
                {
                    while (!s.IsEmpty() && prec(c) >= prec(s.Top().Data))
                    {
                        postfix += s.Top().Data;
                        s.Pop();
                    }

                    s.Push(c);
                }
            }

            while (!s.IsEmpty())
            {
                postfix += s.Top().Data;
                s.Pop();
            }

            return postfix;
        }

        public static void WorkWithPostfix(string postfixExpr)
        {
            int doMath(string op, int op1, int op2)
            {
                int result = 0;
                if (op.Equals("*"))
                    result = op1 * op2;
                if (op.Equals("/"))
                    result = op1 / op2;
                if (op.Equals("+"))
                    result = op1 + op2;
                if (op.Equals("-"))
                    result = op1 - op2;
                if (op.Equals("^"))
                    result = Convert.ToInt32(Math.Pow(op1, op2));
                if (op.Equals("ln"))
                    result = Convert.ToInt32(Math.Log(op2, Math.E));
                if (op.Equals("cos"))
                    result = Convert.ToInt32(Math.Cos(op2));
                if (op.Equals("sin"))
                    result = Convert.ToInt32(Math.Sin(op2));
                if (op.Equals("sqrt"))
                    result = Convert.ToInt32(Math.Sqrt(op2));
                return result;
            }
            int postfixEval(string postfixExpr)
            {
                int result = 0;
                MyStack<int> operandStack = new MyStack<int>();
                String[] tokenList = postfixExpr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < tokenList.Length; i++)
                {
                    if (tokenList[i].Equals("1") || tokenList[i].Equals("2") || tokenList[i].Equals("3") || tokenList[i].Equals("4") || tokenList[i].Equals("5") || tokenList[i].Equals("6") || tokenList[i].Equals("7") || tokenList[i].Equals("8") || tokenList[i].Equals("9") || tokenList[i].Equals("0"))
                        operandStack.Push(Int32.Parse(tokenList[i]));
                    else
                    {
                        if (tokenList[i].Equals("ln") || tokenList[i].Equals("sin") || tokenList[i].Equals("sqrt") || tokenList[i].Equals("cos"))
                        {
                            int operand2 = operandStack.Pop();
                            result = doMath(tokenList[i], 0, operand2);
                            operandStack.Push(result);
                        }
                        else
                        {
                            int operand2 = operandStack.Pop();
                            int operand1 = operandStack.Pop();
                            result = doMath(tokenList[i], operand1, operand2);
                            operandStack.Push(result);
                        }
                    }
                }
                result = operandStack.Pop();
                return result;
            }
            Console.WriteLine(postfixEval(postfixExpr));
        }
    }
}
