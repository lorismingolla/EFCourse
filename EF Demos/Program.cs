using EF_Demos.Objects;
using System;

namespace EF_Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowGeometricObject(new GeometricObject("red", true));
            //ShowGeometricObject(new Circle(10, "red", true));
            //ShowGeometricObject(new Rectangle(10, 5, "red", true));
        }

        public static void ShowGeometricObject(GeometricObject geometricObject)
        {
            Console.WriteLine($"This geometric object is {geometricObject.Color} of color and is {(geometricObject.IsFilled ? "all the way filled up." : "not filled.")}");
        }
    }
}
