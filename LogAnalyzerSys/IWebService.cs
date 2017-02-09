namespace LogAnalyzerSys
{
    public interface IWebService
    {
        /// <summary>
        /// 最后错误消息
        /// </summary>
        string LastError { get; set; }

        /// <summary>
        /// 记录错误
        /// </summary>
        /// <param name="msg">错误消息</param>
        void LogError(string msg);
    }
}