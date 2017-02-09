using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace LogAnalyzerSys.UnitTests
{
    [TestClass]
    public class LogAnalyzerWebServiceTests
    {
        [TestMethod]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            var webService = Substitute.For<IWebService>();
            const string errorMessage = "Filename too short:abc.txt";
            var log = new LogAnalyzer(webService);
            var tooShortFileName = "abc.txt";
            webService.When(x => x.LogError(errorMessage)).Do(x => webService.LastError = errorMessage);
            log.Analyze(tooShortFileName);
            Assert.AreEqual(errorMessage, webService.LastError);
        }

        [TestMethod]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            var webService = Substitute.For<IWebService>();

            var emailService = Substitute.For<IEmailService>();

            var log = new LogAnalyzer(webService, emailService);

            var tooShortFileName = "abc.txt";

            const string errorMessage = "Filename too short:abc.txt";

            webService.When(x => x.LogError(errorMessage)).Throw(new Exception());

            log.Analyze(tooShortFileName);

            Assert.AreEqual("a", emailService.To);
            Assert.AreEqual("fake exception", emailService.Body);
            Assert.AreEqual("subject", emailService.Subject);
        }
    }
}
