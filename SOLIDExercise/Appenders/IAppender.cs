using SOLIDExercise.Appenders.EventLevel;
using SOLIDExercise.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExercise.Appenders
{
    public interface IAppender
    {
        public LogLevel ReportLevel { get; set; }
        public ILayout Layout { get;  }
        public void Append(string date, LogLevel logLevel, string message);
        public int Count { get; }
        public string GetAppenderInfo();
    }
}
