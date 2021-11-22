
using SOLIDExercise.Appenders;
using SOLIDExercise.Appenders.EventLevel;
using SOLIDExercise.Factory;
using SOLIDExercise.Loggers;
using System;

namespace SOLIDExercise
{
    class Program
    {
        static void Main(string[] args)
        {
           int appendersCount =  int.Parse(Console.ReadLine());
            var logger = new Logger();
            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderInfo = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                IAppender current = AppenderFactory.GetAppender(appenderInfo);
                if (appenderInfo.Length>2)
                {
                    if (Enum.TryParse(appenderInfo[2],true,out LogLevel result))
                    {
                        current.ReportLevel = result;
                    }
                    
                }
                logger.Appenders.Add(current);
            }

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] messageInfo = input.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string reportLevel = messageInfo[0];

                switch (reportLevel)
                {
                    case "INFO":
                        logger.Info(messageInfo[1],messageInfo[2]);
                        break;
                    case "WARNING":
                        logger.Warning(messageInfo[1], messageInfo[2]);
                        break;
                    case "ERROR":
                        logger.Error(messageInfo[1], messageInfo[2]);
                        break;
                    case "CRITICAL":
                        logger.Critical(messageInfo[1], messageInfo[2]);
                        break;
                    case "FATAL":
                        logger.Fatal(messageInfo[1], messageInfo[2]);
                        break;
                    default:
                        break;
                }
                input = Console.ReadLine();
            }
            logger.Appenders.ForEach(a => Console.WriteLine(a.GetAppenderInfo())); 
        }
    }
}
