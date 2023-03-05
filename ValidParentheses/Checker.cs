using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

            foreach (var parentheses in chars)
            {
                if (parentheses == '(' || parentheses == '{' || parentheses == '[')
                {
                    stack.Push(parentheses);
                    continue;
                }

                if (stack.Count != 0 && CheckForMatchingOpenParentheses(stack.Pop(), parentheses))
                    continue;

                return false;
            }

            return (stack.Count == 0) ? true : false;
        }

        public bool CheckForMatchingOpenParentheses(char peek, char current)
        {
            return (current, peek) switch
            {
                ('}', '{') => true,
                (')', '(') => true,
                (']', '[') => true,
                _ => false
            };
        }
    }
}
