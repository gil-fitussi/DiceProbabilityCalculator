using System;

namespace DiceProbabilityCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Operations operation = new Operations();
            string expression = "12-d2*d6";
            var res = operation.Calculate(expression);
            operation.PrintResult();
            
        }
    }
}
