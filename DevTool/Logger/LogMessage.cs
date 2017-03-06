namespace Turbo.Plugins.Jack.DevTool.Logger
{
    public class LogMessage
    {
        public string Message { get; set; }
        public LogLevel Level { get; set; }

        public LogMessage(string message, LogLevel level = LogLevel.All)
        {
            Message = message;
            Level = level;
        }
    }
}