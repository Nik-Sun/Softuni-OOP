using SOLIDExercise.Appenders;
using SOLIDExercise.Files;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExercise.Factory
{
    public static class AppenderFactory
    {
        public static IAppender GetAppender(params string[] args)
        {
            if (args[0] == nameof(ConsoleAppender))
            {
                return new ConsoleAppender(LayoutFactory.Create(args[1]));
            }
            else if (args[0] == nameof(FileAppender))
            {
                return new FileAppender(LayoutFactory.Create(args[1]),new LogFile());
            }
            else
            {
                throw new ArgumentException("Wrong appender type");
            }
        }
    }
}
