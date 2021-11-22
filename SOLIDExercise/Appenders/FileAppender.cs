using SOLIDExercise.Appenders.EventLevel;
using SOLIDExercise.Files;
using SOLIDExercise.Layouts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOLIDExercise.Appenders
{
    public class FileAppender : Appender
    {
        public FileAppender(ILayout format,IFile logFile)
            :base(format)
        {
            LogFile = logFile;
        }
        public IFile LogFile { get; }

        public override void Append(string date, LogLevel logLevel, string message)
        {
            if (logLevel >= ReportLevel)
            {
                File.WriteAllText("log.txt", string.Format(Layout.Format, date, logLevel, message));
                LogFile.Write(string.Format(Layout.Format, date, logLevel, message));
                Count++;
            }
           
        }
        public override string GetAppenderInfo()
        {
            return $"{base.GetAppenderInfo()}, File size: {LogFile.Size}";
        }

    }
}
