namespace LogAnalyzerSys
{
    public interface IEmailService
    {
        string Body { get; set; }
        string Subject { get; set; }
        string To { get; set; }
    }
}