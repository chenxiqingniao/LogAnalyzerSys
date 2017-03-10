using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace LogAnalyzerSys.UnitTests
{
    [TestClass]
    public class LogAnalyzerWebServiceTests
    {
        IWebService _webService;

        const string ErrorMessage = "Filename too short:abc.txt";

        const string TooShortFileName = "abc.txt";

        [TestInitialize]
        public void Setup()
        {
            _webService = Substitute.For<IWebService>();
        }

        [TestMethod]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            var log = new LogAnalyzer(_webService);

            log.Analyze(TooShortFileName);

            _webService.Received().LogError(ErrorMessage);//WebService作为摸你对象被预期调用方法
        }

        [TestMethod]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            var emailService = Substitute.For<IEmailService>();

            var log = new LogAnalyzer(_webService, emailService);

            _webService.When(x => x.LogError(ErrorMessage)).Throw(new Exception());//webService作为桩对象使用

            log.Analyze(TooShortFileName);

            Assert.AreEqual("a", emailService.To);//EmailService作为模拟对象使用

            Assert.AreEqual("fake exception", emailService.Body);

            Assert.AreEqual("subject", emailService.Subject);
        }

        
    }
}
