using DiceProbabilityCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestDiceProbabilityCalculator
{
    [TestClass]
    public class BasicTests
    {
        [TestMethod]
        public void DieTwoAdditions()
        {
            List<Result> expected = new List<Result>()
            {
                new Result("1 + 1 + 1",3,25),
                new Result("1 + 2 + 1",4,25),
                new Result("1 + 3 + 1",5,25),
                new Result("1 + 4 + 1",6,25)
            };


            Operations operation = new Operations();
            string expression = "1+d4+1";
            var res = operation.Calculate(expression);
            CollectionAssert.AreEqual(expected, res);
        }

        [TestMethod]
        public void TwoDice()
        {
            List<Result> expected = new List<Result>()
            {
                new Result("1 + 1",2,12.5),
                new Result("1 + 2",3,12.5),
                new Result("1 + 3",4,12.5),
                new Result("1 + 4",5,12.5),
                new Result("2 + 1",3,12.5),
                new Result("2 + 2",4,12.5),
                new Result("2 + 3",5,12.5),
                new Result("2 + 4",6,12.5),
            };


            Operations operation = new Operations();
            string expression = "d2+d4";
            var res = operation.Calculate(expression);
            CollectionAssert.AreEqual(expected, res);
        }

        [TestMethod]
        public void SubtractionOfDice()
        {
            List<Result> expected = new List<Result>()
            {
                new Result("1 - 2 * 1",-1,33.33),
                new Result("1 - 2 * 2",-3,33.33),
                new Result("1 - 2 * 3",-5,33.33),
            };

            Operations operation = new Operations();
            string expression = "d1-2*d3";
            var res = operation.Calculate(expression);
            CollectionAssert.AreEqual(expected, res); 
        }

        [TestMethod]
        public void MultiplicationOfDice()
        {
            List<Result> expected = new List<Result>()
            {
                new Result("12 - 1 * 1",11, 8.33),
                new Result("12 - 1 * 2",10, 8.33),
                new Result("12 - 1 * 3",9 ,8.33),
                new Result("12 - 1 * 4",8 ,8.33),
                new Result("12 - 1 * 5",7 ,8.33),
                new Result("12 - 1 * 6",6 ,8.33),
                new Result("12 - 2 * 1",10, 8.33),
                new Result("12 - 2 * 2",8 ,8.33),
                new Result("12 - 2 * 3",6 ,8.33),
                new Result("12 - 2 * 4",4 ,8.33),
                new Result("12 - 2 * 5",2 ,8.33),
                new Result("12 - 2 * 6",0 ,8.33)
            };

            
            Operations operation = new Operations();
            string expression = "12-d2*d6";
            var res = operation.Calculate(expression);
            CollectionAssert.AreEqual(expected, res);
        }
    }
}
