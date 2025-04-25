using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace A1RomnieEmileGalvez
{
    public class Square: Rectangle
    {
        private int _side;


        public int Side
        {
            get { return _side; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Side can't be < 0 or less than 0.");

                }
                _side = value;
                
            }
        }

        // you can't pass length and width to the base constructor, since length and width are not defined in the square constructor
        // passing length and width to the base constructor would cause an error
        public Square(int shapeId, ShapeTypes shapeTypes, int side, double opacity) : base(shapeId, shapeTypes, side, side, opacity)
        {
            Side = side;
        }


        public override double Area()
        {
            return _side * _side;
        }

        public override double Diameter()
        {
            return Math.Sqrt(2) * _side;
        }

        public override string ToString()
        {
            return $"{ShapeId} {_side} {Opacity:P2} {Area():F2} {Diameter():F2}";
        }
    }
}
