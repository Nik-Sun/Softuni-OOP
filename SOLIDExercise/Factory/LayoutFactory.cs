using SOLIDExercise.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLIDExercise.Factory
{
    public static class LayoutFactory
    {
        public static ILayout Create(string type)
        {
            if (type == nameof(SimpleLayout))
            {
                return new SimpleLayout();
            }
            else if (type == nameof(XmlLayout))
            {
                return new XmlLayout();
            }
            else
            {
                throw new ArgumentException("Wrong layout type");
            }
        }
    }
}
