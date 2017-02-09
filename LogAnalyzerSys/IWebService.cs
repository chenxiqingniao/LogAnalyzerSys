namespace LogAnalyzerSys
{
    public interface IWebService
    {
        string LastError { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        void LogError(string msg);
    }
}