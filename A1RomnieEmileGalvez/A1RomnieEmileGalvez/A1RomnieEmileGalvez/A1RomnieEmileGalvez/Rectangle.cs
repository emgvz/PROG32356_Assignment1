using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1RomnieEmileGalvez
{

    public class Rectangle : Shape
    {

        private int _length;
        private int _width;

        public int Length
        {
            get { return _length; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Length can't be 0 or less than 0.");
                }
                _length = value;
            }
        }

        public int Width
        {
            get { return _width; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Width can't be 0 or less than 0.");

                }
                _width = value;
            }
        }

        // derive class constructor
        public Rectangle(int shapeId, ShapeTypes shapeTypes, int length, int width, double opacity) : base(shapeId, shapeTypes, opacity)
        {
            Length = length;
            Width = width;
        }
        
        public override double Area()
        {
            return Length * Width;
        }

        public override double Diameter()
        {
            return Math.Sqrt(Length * Length + Width * Width);
        }

        public override string ToString()
        {
            return $"{base.ToString()} {Length} {Width} {Opacity:P2} {Area():F2} {Diameter():F2}";
        }
    }

}
