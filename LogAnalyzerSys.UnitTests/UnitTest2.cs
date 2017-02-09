using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace LogAnalyzerSys.UnitTests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void Add_TheNumber2AndTheNumber3_ReturnCorrectResult()
        {
            ICalculator instance = Substitute.For<ICalculator>();
            instance.Add(2, 3).Returns(5);
            Assert.AreEqual(5, instance.Add(2, 3));
        }
    }
}
