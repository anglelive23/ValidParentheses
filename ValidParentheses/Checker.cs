using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidParentheses
{
    public class Checker
    {
        public Checker()
        {
            Check();
        }

        public void Check()
        {
            Console.Write("Expression: ");
            Span<char> chars = Console.ReadLine().ToCharArray().AsSpan();
            Console.WriteLine(IsValidParentheses(chars) ? "Valid" : "Not valid");
        }

        public bool IsValidParentheses(Span<char> chars)
        {
            Stack<char> stack = new Stack<char>();
            bool isValidParentheses = true;

            foreach (var parentheses in chars)
            {
                // Pushing
                if (parentheses == '(' || parentheses == '{' || parentheses == '[')
                {
                    stack.Push(parentheses);
                    continue;
                }
                // if item is closing parentheses then we check if the top element in stack is a matching open parentheses
                if (stack.Count != 0 && CheckForMatchingOpenParentheses(stack.Pop(), parentheses))
                    continue;

                // if you reach this point this mean it's not valid expression and so we break the loop and return false
                isValidParentheses = false;
                break;
            }

            return (isValidParentheses) ? true : false;
        }

        public bool CheckForMatchingOpenParentheses(char peek, char current)
        {
            switch (current)
            {
                case ')':
                    if (peek == '(') return true;
                    break;
                case '}':
                    if (peek == '{') return true;
                    break;
                case ']':
                    if (peek == '[') return true;
                    break;
                default:
                    return false;
            }
            return false;
        }
    }
}
