using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1RomnieEmileGalvez
{
    public class Triangle : Shape
    {
        private int _sideA;
        private int _sideB;
        private int _sideC;

        public int SideA
        {
            get {  return _sideA; }
            set { 
                if (value <= 0)
                {
                    throw new Exception("Side A cannot be 0 or less than 0.");

                }
                _sideA = value;
            }
        }

        public int SideB
        {
            get { return _sideB; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Side B cannot be 0 or less than 0.");
                }
                _sideB = value;
            }
        }

        public int SideC
        {
            get { return _sideC; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Side C cannot be 0 or less than 0.");

                }
                _sideC = value;
            }
        }

        // derive class constructor
        public Triangle(int shapeId, ShapeTypes shapeTypes, int sideA, int sideB, int sideC, double opacity) : base(shapeId, shapeTypes, opacity)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public override double Area()
        {
            double semiPerimeter = (SideA + SideB + SideC) / 2.0;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
        }
        
        public override double Diameter()
        {
            return SideA + SideB + SideC;
        }

        public override string ToString()
        {
            return $"{base.ToString()} {SideA} {SideB} {SideC} {Opacity:P2} {Area():F2} {Diameter():F2}";


        }
    }
}
