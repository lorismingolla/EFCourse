
namespace EF_Demos.Objects
{
    public class Rectangle
    {
        public string Color { get; set; }
        public bool IsFilled { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int width, int height, string color, bool isFilled)
        {
            Width = width;
            Height = height;
            Color = color;
            IsFilled = isFilled;
        }

        public override string ToString()
        {
            return $"This geometric object has the color {Color} and is {(IsFilled ? "filled" : "not filled")}.";
        }

        public override bool Equals(object obj)
        {
            Rectangle r = obj as Rectangle;
            if (r == null)
            {
                return false;
            }
            return base.Equals((Rectangle)obj) && Width == r.Width && Height == r.Height;
        }
    }
}
