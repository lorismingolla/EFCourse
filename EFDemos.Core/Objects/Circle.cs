
namespace EF_Demos.Objects
{
    public class Circle
    {
        public string Color { get; set; }
        public bool IsFilled { get; set; }
        public int Radius { get; set; }

        public Circle(int radius, string color, bool isFilled)
        {
            Radius = radius;
            Color = color;
            IsFilled = isFilled;
        }

        public override string ToString()
        {
            return $"This geometric object has the color {Color} and is {(IsFilled ? "filled" : "not filled")}.";
        }
    }
}
