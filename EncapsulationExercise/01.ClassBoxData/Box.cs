using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length,double width,double height)
        {
            Lenght = length;
            Width = width;
            Height = height;

        }
        public double Lenght
        {
            get => length;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                length = value;
            }
        }
        public double Width
        {
            get => width;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                width = value;
            }
        }
        public double Height
        {
            get => height;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                height = value;
            }
        }

        public double GetSurfaceArea()
        {
            return 2 * (width * height) + 2 * (length * height) + 2 * (width * length);
        }
        public double GetLateralSurfaceArea()
        {
            return 2 * (length * height) + 2 * (width* height);
        }
        public double GetVolume()
        {
            return Lenght * width * height ;
        }
    }
}
