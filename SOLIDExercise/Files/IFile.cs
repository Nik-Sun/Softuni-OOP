using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExercise.Files
{
    public interface IFile
    {

        public int Size { get;  }
        public void Write(string s);
    }
}
