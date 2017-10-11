using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionSample
{
    class Program
    {
        public static T AddExpression<T>(T left, T right)
        {
            ParameterExpression leftOperand = Expression.Parameter(typeof(T), "left");
            ParameterExpression rightOperand = Expression.Parameter(typeof(T), "right");
            BinaryExpression body = Expression.Add(leftOperand, rightOperand);
            Expression<Func<T, T, T>> adder = Expression.Lambda<Func<T, T, T>>(body, leftOperand, rightOperand);
            Func<T, T, T> theDelegate = adder.Compile();
            return theDelegate(left, right);
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"{AddExpression<int>(3,"5")}");
        }
    }
}
