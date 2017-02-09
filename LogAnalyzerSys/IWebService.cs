namespace LogAnalyzerSys
{
    public interface IWebService
    {
        string LastError { get; set; }

        void LogError(string msg);
    }
}