using System;
using System.Collections.Generic;
using System.Text;

namespace DiceProbabilityCalculator
{
    public class Result
    {
        #region Members
        public string Expression { get; set; }
        public int ResultNum { get; set; }
        public double Percentage { get; set; }
        #endregion

        #region Ctor
        public Result(string expresion, int resultNum, double percentage)
        {
            Expression = expresion;
            ResultNum = resultNum;
            Percentage = percentage;
        }
        #endregion

        #region Overrides
        // For Unit Testing
        public override bool Equals(object obj)
        {
            var result = obj as Result;
            return result != null &&
                   Expression == result.Expression &&
                   ResultNum == result.ResultNum &&
                   Percentage == result.Percentage;
        }
        #endregion

    }
}
