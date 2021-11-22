using SOLIDExercise.Appenders;
using SOLIDExercise.Appenders.EventLevel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExercise.Loggers
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            Appenders = new List<IAppender>();
            Appenders.AddRange(appenders);
        }
        public List<IAppender> Appenders { get; set ; }


        public void Fatal(string date, string message)
        {
            AppendAll(date, LogLevel.Fatal, message);
        }


        public void Error(string date, string message)
        {
            AppendAll(date, LogLevel.Error, message);
        }


        public void Info(string date, string message)
        {
            AppendAll(date, LogLevel.Info, message);
        }


        public void Critical(string date, string message)
        {
            AppendAll(date, LogLevel.Critical, message);
        }


        public void Warning(string date, string message)
        {
            AppendAll(date, LogLevel.Warning, message);
        }


        private void AppendAll(string date,LogLevel logLevel,string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(date, logLevel, message);
            }
        }
    }
}
