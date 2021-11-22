using SOLIDExercise.Appenders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExercise.Loggers
{
    public interface ILogger
    {
        public List<IAppender> Appenders { get; set; }

        public abstract void Info(string date, string message);

        public abstract void Warning(string date, string message);

        public abstract void Error(string date, string message);

        public abstract void Critical(string date, string message);

        public abstract void Fatal(string date, string message);
    }
}
