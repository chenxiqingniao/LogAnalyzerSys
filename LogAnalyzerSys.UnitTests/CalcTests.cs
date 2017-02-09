using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace LogAnalyzerSys.UnitTests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Add_TheNumber2AndTheNumber3_ReturnCorrectResult()
        {
            ICalculator instance = Substitute.For<ICalculator>();
            instance.Add(2, 3).Returns(5);
            Assert.AreEqual(5, instance.Add(2, 3));
        }

        [TestMethod]
        public void Add_TwoNumber_CorrectAddition()
        {
            var instance = Substitute.For<ICalculator>();
            instance.Add(Arg.Any<double>(), Arg.Any<double>()).Returns(x => (double)x[0] + (double)x[1]);
            Assert.AreEqual(10, instance.Add(5, 5));

        }
    }
}
