using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DiceProbabilityCalculator
{
    public class Operations
    {
        private const string Dice = "Dice";

        #region Members
        // Object Expression Split - If Dice Const 'Dice' Appear
        private List<string> ObjectExpression { get; set; }

        // Dice Numbers By Index Of ObjectExpression
        private Dictionary<int, List<int>> DiceDict { get; set; }

        // Result Of Expressions + Number + Percentage
        private List<Result> ResultSet { get; set; }

        // The Number Of Expressions Can Be
        private float NumberOfExpressions { get; set; } = 1;
        #endregion

        #region Ctor
        public Operations()
        {
            ObjectExpression = new List<string>();
            DiceDict = new Dictionary<int, List<int>>();
            ResultSet = new List<Result>();
        }
        #endregion

        #region Methods

        // Calculate Dice Probability
        public List<Result> Calculate(string expression)
        {
            if (expression.Length > 100)
            {
                Console.WriteLine("Max length of expression is 100.");
                return null;
            }

            SetSlicedExpresion(expression);
            Calc("", ObjectExpression, 0);
            return ResultSet;
        }

        // Split expression by Number d[0-9] OR [0-9] OR * OR + OR -
        private void SetSlicedExpresion(string expression)
        {
            var slicedExpression = Regex.Split(expression, @"(d[\d$]|[^\d$]|\+|\-|\*)").Where(s => s != String.Empty).ToArray<string>();
            AddObjectExpression(slicedExpression);

        }

        // Add expression to Object Expression object - If found dice Add to dictionary too
        private void AddObjectExpression(string[] slicedExpression)
        {
            int idx = 0;
            foreach (var exp in slicedExpression)
            {
                if (exp.StartsWith("d"))
                {
                    ObjectExpression.Add(Dice); // Flag For Dice Object

                    var rangeNumber = int.Parse(exp.Remove(0, 1));
                    DiceDict.Add(idx, new List<int>(Enumerable.Range(1, rangeNumber).ToList()));
                    NumberOfExpressions = NumberOfExpressions * rangeNumber;
                }
                else
                    ObjectExpression.Add(exp);
                idx++;
            }
        }

        // Calculate expressions / Results / Percentage
        private void Calc(string expresion, List<string> objectExpresion, int idx)
        {
            if (idx == objectExpresion.Count)
            {
                int numResult = (int)new DataTable().Compute(expresion, null);
                ResultSet.Add(new Result(expresion.TrimStart(), numResult, Math.Round((1 / NumberOfExpressions) * 100, 2)));
                return;
            }


            if (objectExpresion[idx].Equals("Dice"))
            {
                for(int i = 0; i < DiceDict[idx].Count; i++)
                {
                    Calc($"{expresion} {DiceDict[idx][i]}", objectExpresion, idx + 1);
                }
            }
            else
            {
                Calc($"{expresion} {objectExpresion[idx]}", objectExpresion, idx + 1);
            }            
        }

        // Print the result
        public void PrintResult()
        {
            foreach (var item in ResultSet)
            {
                Console.WriteLine($"Expression: {item.Expression} " +
                                  $"Result: {item.ResultNum} " +
                                  $"Percentage {item.Percentage}%");
            }
            Console.ReadLine();

        }
        #endregion
    }
}
