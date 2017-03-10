namespace Turbo.Plugins.Jack
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Turbo.Plugins.Jack.DevTool.Logger;

    public static class Says
    {
        public static ushort MaxMessages { get; set; }
        public static List<LogMessage> Messages { get; private set; }

        static Says()
        {
            MaxMessages = 45;
            Messages = new List<LogMessage>(MaxMessages);
        }

        private static void AddMessage(string message, LogLevel level = LogLevel.All, string format = "{1:HH:mm:ss.fff} : {2,5} : {0}")
        {
            if (Messages.Count >= MaxMessages)
            {
                var temp = Messages.First();
                temp.Message = string.Format(format, message, DateTime.Now, level);
                temp.Level = level;

                Messages = Messages.Skip(Math.Max(0, Messages.Count() - MaxMessages + 1)).ToList();

                Messages.Add(temp);
            }
            else
            {
                Messages.Add(new LogMessage(string.Format(format, message, DateTime.Now, level), level));
            }
        }

        public static void Debug(string message)
        {
            AddMessage(message, LogLevel.Debug);
        }

        public static void Debug(params object[] param)
        {
            Debug(string.Join(", ", param));
        }

        public static void Debug(IEnumerable<object> param)
        {
            Debug(string.Join(", ", param));
        }

        public static void Debug(string message, params object[] param)
        {
            Debug(string.Format(CultureInfo.InvariantCulture, message, param));
        }

        public static void Info(string message)
        {
            AddMessage(message, LogLevel.Info);
        }

        public static void Info(params object[] param)
        {
            Info(string.Join(", ", param));
        }

        public static void Info(IEnumerable<object> param)
        {
            Info(string.Join(", ", param));
        }

        public static void Info(string message, params object[] param)
        {
            Info(string.Format(CultureInfo.InvariantCulture, message, param));
        }

        public static void Error(string message)
        {
            AddMessage(message, LogLevel.Error);
        }

        public static void Error(params object[] param)
        {
            Error(string.Join(", ", param));
        }

        public static void Error(IEnumerable<object> param)
        {
            Error(string.Join(", ", param));
        }

        public static void Error(string message, params object[] param)
        {
            Error(string.Format(CultureInfo.InvariantCulture, message, param));
        }
    }
}