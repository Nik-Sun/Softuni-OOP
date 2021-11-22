using SOLIDExercise.Appenders.EventLevel;
using SOLIDExercise.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExercise.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            :base(layout)
        {
           
        }
       

        public override void Append(string date,LogLevel logLevel,string message)
        {
            if (logLevel >= ReportLevel)
            {
                Console.WriteLine(Layout.Format, date, logLevel, message);
                Count++;
            }
            
        }

    }
}
