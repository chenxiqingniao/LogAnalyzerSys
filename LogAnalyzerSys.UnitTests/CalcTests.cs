using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace LogAnalyzerSys.UnitTests
{
    [TestClass]
    public class CalcTests
    {
        ICalculator _instance;//计算接口
        [TestInitialize]
        public void Setup()
        {
            _instance = Substitute.For<ICalculator>();
        }

        [TestMethod]
        public void Add_TheNumber2AndTheNumber3_ReturnCorrectResult()
        {
            _instance.Add(2, 3).Returns(5);
            Assert.AreEqual(5, _instance.Add(2, 3));
        }

        [TestMethod]
        public void Add_TwoNumber_CorrectAddition()
        {
            _instance.Add(Arg.Any<double>(), Arg.Any<double>()).Returns(x => (double)x[0] + (double)x[1]);
            Assert.AreEqual(10, _instance.Add(5, 5));
        }

        [TestMethod]
        public void Add_Received_Passed()
        {
            _instance.Add(1, 2);
            _instance.Received().Add(1, 2);
        }

        [TestMethod]
        public void Add_DidNotReceive_Passed()
        {
            _instance.Add(1, 2);
            _instance.DidNotReceive().Add(5, 6);
        }

        [TestMethod]
        public void Add_InvokeReceivedMethod_SupportsArgMatching()
        {
            _instance.Add(5.0, -5.0);
            _instance.Received().Add(5, Arg.Any<double>());
            _instance.Received().Add(5, Arg.Is<double>(x => x < 0));
            _instance.Model.Returns("A","B","C");
            Assert.AreEqual("A", _instance.Model);
            Assert.AreEqual("B", _instance.Model);
            Assert.AreEqual("C", _instance.Model);
        }
    }
}
