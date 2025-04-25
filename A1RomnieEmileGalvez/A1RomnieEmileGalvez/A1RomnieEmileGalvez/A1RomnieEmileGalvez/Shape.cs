using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1RomnieEmileGalvez
{

    public enum ShapeTypes
    {
        Circle, Triangle, Rectangle, Square
    }


    public abstract class Shape
    {
        // fields

        private int _shapeId;
        private ShapeTypes _shapeTypes;
        private double _opacity;
        
        // start of properties
        public int ShapeId
        {
            get { return _shapeId; }
            private set { _shapeId = value; }

        }

        public ShapeTypes TypeOfShapes 
        {
            get { return _shapeTypes; }
            private set { _shapeTypes = value; }
        }

        public double Opacity
        {
            get { return _opacity; }
            private set
            {
                if (value < 0)
                {
                    throw new Exception("Opacity can't be less than 0.");
                    
                }
                _opacity = value;

            }
        }

        // end of properties

        // constructor for base class

        public Shape(int shapeId, ShapeTypes shapeTypes, double opacity)
        {
            ShapeId = shapeId;
            TypeOfShapes = shapeTypes;
            Opacity = opacity;
        }

        public void OpacityChange(double newOpacity)
        {
            if (newOpacity < 0 )
            {
                throw new Exception("Opacity can't be less than 0.");
            }
            Opacity = newOpacity;

        }

        // abstract method Area that shares with everyone

        public abstract double Area();

        // abstract method Diameter that shares with everyone

        public abstract double Diameter();

        // overriden string ToString(), displays information

        public override string ToString()
        {

            return $"{_shapeId}";

            //return $"\n{_shapeTypes}:\n" +
            //    "ID\tRadius\tOpacity\tArea\tPerimeter\n"+
            //    "-----------------------------------------"+
            //    $"\n{_shapeId}";
        }

    }
}
