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

        [TestInitialize]
        public void Setup()
        {
            _webService = Substitute.For<IWebService>();
        }

        [TestMethod]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            var log = new LogAnalyzer(_webService);

            var tooShortFileName = "abc.txt";

            _webService.When(x => x.LogError(ErrorMessage)).Do(x => _webService.LastError = ErrorMessage);

            log.Analyze(tooShortFileName);

            Assert.AreEqual(ErrorMessage, _webService.LastError);
        }

        [TestMethod]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            var emailService = Substitute.For<IEmailService>();

            var log = new LogAnalyzer(_webService, emailService);

            var tooShortFileName = "abc.txt";

            _webService.When(x => x.LogError(ErrorMessage)).Throw(new Exception());

            log.Analyze(tooShortFileName);

            Assert.AreEqual("a", emailService.To);

            Assert.AreEqual("fake exception", emailService.Body);

            Assert.AreEqual("subject", emailService.Subject);
        }

        
    }
}
