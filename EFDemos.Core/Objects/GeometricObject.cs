

namespace EF_Demos.Objects
{
    public class GeometricObject
    {
        public string Color { get; set; }
        public bool IsFilled { get; set; }

        public GeometricObject(string color, bool isFilled)
        {
            Color = color;
            IsFilled = isFilled;
        }

        public override string ToString()
        {
            return $"This geometric object has the color {Color} and is {(IsFilled ? "filled" : "not filled")}.";
        }
    }
}
