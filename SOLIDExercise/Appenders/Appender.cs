using SOLIDExercise.Appenders.EventLevel;
using SOLIDExercise.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExercise.Appenders
{
    public abstract class Appender : IAppender
    {
        public Appender(ILayout layout)
        {
            Layout = layout;
        }
        public ILayout Layout  {get;}
        public LogLevel ReportLevel { get; set ; }

        public int Count { get; protected set; }

        public abstract void Append(string date, LogLevel logLevel, string message);

        public virtual string GetAppenderInfo()
        {
            return $"Appender Type: {this.GetType().Name}, LayoutType: {this.Layout.GetType().Name}, Report level: {ReportLevel.}, Messages appended: {Count}";
        }
    }
}
//Appender type: ConsoleAppender, Layout type: SimpleLayout, Report level: CRITICAL, Messages appended: 2
