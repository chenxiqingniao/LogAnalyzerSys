namespace LogAnalyzerSys
{
    public class LogAnalyzer
    {
        IEmailService emailService;
        IWebService webService;

        public LogAnalyzer(IWebService webService)
        {
            this.webService = webService;
        }

        public LogAnalyzer(IWebService webService1, IEmailService emailService):this(webService1)
        {
            this.emailService = emailService;
        }

        public void Analyze(string tooShortFileName)
        {
            if (tooShortFileName.Length < 8)
            {
                try
                {
                    webService.LogError($"Filename too short:{tooShortFileName}");
                }
                catch
                {
                    emailService.To = "a";
                    emailService.Body = "fake exception";
                    emailService.Subject = "subject";
                }
               
            }
        }
    }
}