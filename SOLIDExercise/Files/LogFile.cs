using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOLIDExercise.Files
{
    public class LogFile : IFile
    {
        private StringBuilder stringBuilder;
        public LogFile()
        {
            stringBuilder = new StringBuilder();
        }
        public int Size => stringBuilder.ToString().Where(c => char.IsLetter(c)).Sum(c => c);
        
        public void Write(string s)
        {
            stringBuilder.Append(s);
        }
    }
}
