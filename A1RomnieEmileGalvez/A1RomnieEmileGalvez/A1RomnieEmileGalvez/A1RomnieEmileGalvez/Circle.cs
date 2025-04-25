using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace A1RomnieEmileGalvez
{
    public class Circle : Shape
    {
        private int _radius;
        
        // this will throw when user inputs a wrong input on runtime
        public int Radius
        {
            get { return _radius; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Radius can't be less than 0.");
                }

                _radius = value;
            }
        }
        
     
        // derive class constructor
        public Circle(int shapeId, ShapeTypes shapeTypes, int radius, double opacity) : base(shapeId, shapeTypes, opacity) // original constructor + base constructor
        {
            Radius = radius;
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
            
        }

        public override double Diameter()
        {
            return Radius * 2;
        }

        public override string ToString()
        {
            return $"{base.ToString()} {Radius} {Opacity:P2} {Area():F2} {Diameter():F2}";

        }
    }
}
