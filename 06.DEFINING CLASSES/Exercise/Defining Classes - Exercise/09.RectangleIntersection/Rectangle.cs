namespace _09.RectangleIntersection
{
    using System;

    public class Rectangle
    {
        public Rectangle(string id, double width, double height, double x, double y)
        {
            Id = id;
            Width = width;
            Height = height;
            this.TopLeftCorner_x = x;
            this.TopLeftCorner_y = y;
        }

        public string Id { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double TopLeftCorner_x { get; set; }   //x in coordinate system

        public double TopLeftCorner_y { get; set; }  // y in coordinate system

        public bool Interracts(Rectangle secondRectangle)
        {
            var r1 = this;
            var r2 = secondRectangle;

            if ((r1.TopLeftCorner_x <= r2.TopLeftCorner_x + r2.Width)
                && (r1.TopLeftCorner_x + r1.Width >= r2.TopLeftCorner_x)
                && (r1.TopLeftCorner_y <= r2.TopLeftCorner_y + r2.Height)
                && (r1.TopLeftCorner_y + r1.Height >= r2.TopLeftCorner_y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
