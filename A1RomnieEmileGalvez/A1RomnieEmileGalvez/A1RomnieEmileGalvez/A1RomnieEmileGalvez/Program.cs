using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using ConsoleTables;

namespace A1RomnieEmileGalvez
{
    internal class Program
    {
        public static List<Shape> shapes = new List<Shape>();
        //public static List<Triangle> triangle = new List<Triangle>();
        //public static List<Rectangle> rectangle = new List<Rectangle>();
        //public static List<Rectangle> square = new List<Rectangle>();

        static int nextId = 1;

        static void Details()
        {
            Console.WriteLine("Assignment #1 - Romnie Emile Galvez");
            Console.WriteLine("Assignment #1 - ID 991515759");
            Console.WriteLine("");
            Console.WriteLine("-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
        }

        static void DisplayMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("\tMain Menu");
            Console.WriteLine("");
            Console.WriteLine("\t1. Add Shape");
            Console.WriteLine("\t2. Edit Shape");
            Console.WriteLine("\t3. Delete Shape");
            Console.WriteLine("\t4. View Shape");
            Console.WriteLine("\t5. Exit");
            Console.WriteLine("");
            Console.Write("Enter your choice: ");
        }

        private static int generateId()
        {
            return nextId++;
        }
        static void ViewShapes(List<Shape> shapes)
        {
            CircleDetails(shapes);

            RectangleDetails(shapes);

            TriangleDetails(shapes);

            SquareDetails(shapes);

            Console.WriteLine($"Total shapes at start: {shapes.Count}");

            Console.WriteLine("");
            Console.Write("Press any key to continue. . .");
            Console.ReadLine();

        }

        static void CircleDetails(List<Shape> shapes)
        {
            Console.WriteLine("\nCircles: ");
            var table = new ConsoleTable("ID", "Radius", "Opacity", "Area", "Perimeter");
            table.Options.EnableCount = false;

            // Filtering for Circle objects only
            foreach (Shape circleShape in shapes)
            {
                if (circleShape is Circle circle)
                {
                    table.AddRow(circle.ShapeId, circle.Radius, circle.Opacity,
                                 circle.Area().ToString("F2"), circle.Diameter().ToString("F2"));
                }
            }

            table.Write();
        }

        static void RectangleDetails(List<Shape> shapes)
        {
            Console.WriteLine("\nRectangles: ");
            var table = new ConsoleTable("ID", "Length", "Width", "Opacity", "Area", "Diameter");
            table.Options.EnableCount = false;

            // Filter rectangle
            foreach (Shape rectangleShape in shapes)
            {
                if (rectangleShape is Rectangle rectangle && !(rectangleShape is Square)) // excludes the square, without the second condition
                {                                                                         // shape details from the square will be added to the rectangle, since square is inhering from rectangle 
                    table.AddRow(rectangle.ShapeId, rectangle.Length, rectangle.Width, 
                                rectangle.Opacity, rectangle.Area().ToString("F2"), rectangle.Diameter().ToString("F2"));
                }
                
            }
            table.Write();
        }


        static void TriangleDetails(List<Shape> shapes)
        {
            Console.WriteLine("\nTriangles: ");
            var table = new ConsoleTable("ID", "A", "B", "C", "Opacity", "Area", "Diameter");
            table.Options.EnableCount = false;
            
            // Filter triangle
            foreach (Shape triangleShapes in shapes)
            {
                if (triangleShapes is Triangle triangle)
                {
                    table.AddRow(triangle.ShapeId, triangle.SideA, triangle.SideB, triangle.SideC, triangle.Opacity,
                                triangle.Area().ToString("F2"), triangle.Diameter().ToString("F2"));
                }
            }
            table.Write();
        }


        static void SquareDetails(List<Shape> shapes)
        {
            Console.WriteLine("\nSquares: ");
            var table = new ConsoleTable("ID", "Side", "Opacity", "Area", "Diameter");
            table.Options.EnableCount = false;

            // Filter square
            foreach (Shape squareShapes in shapes)
            {
                if (squareShapes is Square square)
                {
                    table.AddRow(square.ShapeId, square.Side, square.Opacity,
                                 square.Area().ToString("F2"), square.Diameter().ToString("F2"));
                }
            }
            table.Write();
        }

        static void AddCircleMenu(List<Shape> shapes)
        {
            try
            {
                Console.Write("\nEnter Circle Radius: ");

                int radius = int.Parse(Console.ReadLine());


                Console.Write("Enter Opacity: ");

                double opacity = double.Parse(Console.ReadLine());

                int circleId = generateId();

                shapes.Add(new Circle(circleId, ShapeTypes.Circle, radius, opacity));

                Console.WriteLine("");
                Console.WriteLine("New Circle Added");

                CircleDetails(shapes);

                Console.WriteLine("");
                Console.Write("Press any key to continue. . .");
            }

            catch (Exception ex)
            {
                Console.Write($"Error! {ex.Message}");
                Console.WriteLine("");
                Console.Write("Press any key to continue. . .");

            }

        }

        static void AddRectangleMenu(List<Shape> shapes)
        {
            try
            {
                Console.Write("\nEnter Length: ");
                int length = int.Parse(Console.ReadLine());

                Console.Write("Enter Width: ");
                int width = int.Parse(Console.ReadLine());

                Console.Write("Enter Opacity: ");
                double opacity = double.Parse(Console.ReadLine());

                int rectangleId = generateId();

                shapes.Add(new Rectangle(rectangleId, ShapeTypes.Rectangle, length, width, opacity));

                Console.WriteLine("");
                Console.WriteLine("New Rectangle Added");

                RectangleDetails(shapes);

                Console.WriteLine("");
                Console.Write("Press any key to continue. . .");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.Message}");
                Console.WriteLine("");
                Console.Write("Press any key to continue. . .");

            }
        }

        static void AddSquareMenu(List<Shape> shapes)
        {
            try
            {
                Console.Write("\nEnter Length of Side: ");
                int side = int.Parse(Console.ReadLine());

                Console.Write("Enter Opacity: ");
                double opacity = double.Parse(Console.ReadLine());

                int squareId = generateId();

                shapes.Add(new Square(squareId, ShapeTypes.Square, side, opacity));

                Console.WriteLine("");
                Console.WriteLine("New Square Added");

                SquareDetails(shapes);

                Console.WriteLine("");
                Console.Write("Press any key to continue. . .");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.Message}");
                Console.WriteLine("");
                Console.Write("Press any key to continue. . .");
            }
        }

        static void AddTriangleMenu(List<Shape> shapes)
        {
            try
            {
                Console.Write("\nEnter Triangle Edge A: ");
                int sideA = int.Parse(Console.ReadLine());

                Console.Write("Enter Triangle Edge B: ");
                int sideB = int.Parse(Console.ReadLine());

                Console.Write("Enter Triangle Edge C: ");
                int sideC = int.Parse(Console.ReadLine());

                Console.Write("Enter Opacity: ");

                double opacity = double.Parse(Console.ReadLine());


                int triangleId = generateId();

                shapes.Add(new Triangle(triangleId, ShapeTypes.Triangle, sideA, sideB, sideC, opacity));

                Console.WriteLine("");
                Console.WriteLine("New Triangle Added");

                TriangleDetails(shapes);

                Console.WriteLine("");
                Console.Write("Press any key to continue. . .");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("");
                Console.Write("Press any key to continue. . .");

            }
        }

        static void AddShapeMenu(List<Shape> shapes)
        {
            Console.Clear();
            Details();

            Console.WriteLine("");
            Console.WriteLine("\tAdd Shape");
            Console.WriteLine("");
            Console.WriteLine("\t1. Add Circle");
            Console.WriteLine("\t2. Add Rectangle");
            Console.WriteLine("\t3. Add Square");
            Console.WriteLine("\t4. Add Triangle");
            Console.WriteLine("\t5. Back to Main Menu");
            Console.WriteLine("");
            Console.Write("Enter your choice: ");


            while (true)
            {
                int addChoice = 0;

                try
                {
                    addChoice = int.Parse(Console.ReadLine());

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid option! {ex.Message}");
                    break;
                }

                switch (addChoice)
                {
                    case 1:
                        AddCircleMenu(shapes);
                        continue;

                    case 2:
                        AddRectangleMenu(shapes);
                        continue;

                    case 3:
                        AddSquareMenu(shapes);
                        continue;

                    case 4:
                        AddTriangleMenu(shapes);
                        continue;

                    case 5:
                        return;

                    default:
                        Console.Write("Invalid choice!");
                        return;


                }
            }

        }

        static void EditShapeMenu(List<Shape> shapes)
        {

            Console.Clear();
            Details();

            Console.WriteLine("");
            Console.WriteLine("\tEdit Shape");
            Console.WriteLine("");
            Console.WriteLine("\t1. Edit Circle");
            Console.WriteLine("\t2. Edit Rectangle");
            Console.WriteLine("\t3. Edit Square");
            Console.WriteLine("\t4. Edit Triangle");
            Console.WriteLine("\t5. Back to Main Menu");
            Console.WriteLine("");
            Console.Write("Enter your choice: ");

            while (true)
            {
                int editChoice = 0;

                try
                {
                    editChoice = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid option! {ex.Message}");
                    break;
                }


                switch (editChoice)
                {
                    case 1:
                        EditCircleMenu(shapes);
                        continue;

                    case 2:
                        EditRectangleMenu(shapes);
                        continue;

                    case 3:
                        EditSquareMenu(shapes);
                        continue;

                    case 4:
                        EditTriangleMenu(shapes);
                        continue;

                    case 5:
                        return;

                    default:
                        Console.Write("Invalid choice!");
                        return;

                }
            }
        }

        static void EditCircleMenu(List<Shape> shapes)
        {
            CircleDetails(shapes);

            Console.WriteLine("\n");
            Console.WriteLine("Editing Circle");
            Console.Write("Enter ID of Circle you want to edit: ");

            bool idFound = false;
            try
            {
                int id = int.Parse(Console.ReadLine());

                for (int i = 0; i < shapes.Count; i++)
                {
                    if (shapes[i].ShapeId == id)
                    {
                        Console.Write("Enter Circle Radius: ");
                        int radius = int.Parse(Console.ReadLine());

                        Console.Write("Enter Opacity: ");
                        double opacity = double.Parse(Console.ReadLine());


                        if (radius < 0 || opacity < 0)
                        {
                            Console.WriteLine("Radius or Opacity can't be less than 0");
                            Console.WriteLine("");
                            Console.Write("Press any key to continue. . .");
                            return;
                        }

                        else
                        {
                            foreach (Shape shape in shapes)
                            {
                                if (shape.ShapeId == id)
                                {
                                    if (shape.TypeOfShapes == ShapeTypes.Circle && shape is Circle circleShapes) // checks and casts it
                                    {
                                        Console.WriteLine($"Circle with ID = {id} updated");
                                        circleShapes.Radius = radius;
                                        circleShapes.OpacityChange(opacity);
                                        idFound = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                if (idFound)
                {
                    CircleDetails(shapes);

                    Console.WriteLine("");
                    Console.Write("Press any key to continue. . .");
                }

                if (!idFound)
                {
                    Console.WriteLine("Id not found!");
                    Console.WriteLine("");
                    Console.Write("Press any key to continue. . .");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.Message}");
                Console.WriteLine("");
                Console.Write("Press any key to continue. . .");
            }
        }

        static void EditRectangleMenu(List<Shape> shapes)
        {
            RectangleDetails(shapes);

            Console.WriteLine("\n");
            Console.WriteLine("Editing Rectangle");
            Console.Write("Enter ID of Rectangle you want to edit: ");

            bool idFound = false;
            try
            {
                int id = int.Parse(Console.ReadLine());

                for (int i = 0; i < shapes.Count; i++)
                {
                    if (shapes[i].ShapeId == id)
                    {
                        Console.Write("Enter length: ");
                        int length = int.Parse(Console.ReadLine());

                        Console.Write("Enter Width: ");
                        int width = int.Parse(Console.ReadLine());

                        Console.Write("Enter Opacity: ");
                        double opacity = double.Parse(Console.ReadLine());

                        if (length < 0 || width < 0 || opacity < 0)
                        {
                            Console.WriteLine("Length, Width or Opacity can't be less than 0");
                            Console.WriteLine("");
                            Console.Write("Press any key to continue. . .");
                            return;
                        }
                        else
                        {
                            foreach (Shape shape in shapes)
                            {
                                if (shape.ShapeId == id)
                                {
                                    if (shape.TypeOfShapes == ShapeTypes.Rectangle && shape is Rectangle rectangleShapes)
                                    {
                                        Console.WriteLine($"Rectangle with ID = {id} updated");
                                        rectangleShapes.Length = length;
                                        rectangleShapes.Width = width;
                                        rectangleShapes.OpacityChange(opacity);
                                        idFound = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }

                }
                if (idFound)
                {
                    RectangleDetails(shapes);

                    Console.WriteLine("");
                    Console.Write("Press any key to continue. . .");
                }

                if (!idFound)
                {
                    Console.WriteLine("Id not found!");
                    Console.WriteLine("");
                    Console.Write("Press any key to continue. . .");

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.Message}");
                Console.WriteLine("");
                Console.Write("Press any key to continue. . .");
            }
        }

        static void EditSquareMenu(List<Shape> shapes)
        {
            SquareDetails(shapes);

            Console.WriteLine("\n");
            Console.WriteLine("Editing Square");
            Console.Write("Enter ID of Square you want to edit: ");

            bool idFound = false;
            try
            {
                int id = int.Parse(Console.ReadLine());

                for (int i = 0; i < shapes.Count; i++)
                {
                    if (shapes[i].ShapeId == id)
                    {
                        Console.Write("Enter Side: ");
                        int side = int.Parse(Console.ReadLine());

                        Console.Write("Enter Opacity: ");
                        double opacity = double.Parse(Console.ReadLine());

                        if (side < 0 || opacity < 0)
                        {
                            Console.WriteLine("Side or Opacity can't be less than 0");
                            Console.WriteLine("");
                            Console.Write("Press any key to continue. . .");

                        }
                        else
                        {
                            foreach (Shape shape in shapes)
                            {
                                if (shape.ShapeId == id)
                                {
                                    if (shape.TypeOfShapes == ShapeTypes.Square && shape is Square squareShapes)
                                    {
                                        Console.WriteLine($"Square with ID = {id} updated");
                                        squareShapes.Side = side;
                                        squareShapes.OpacityChange(opacity);
                                        idFound = true;
                                        break;
                                    }
                                }
                            }

                        }
                    }
                }
                if (idFound)
                {
                    SquareDetails(shapes);

                    Console.WriteLine("");
                    Console.Write("Press any key to continue. . .");
                }

                if (!idFound)
                {
                    Console.WriteLine("Id not found!");
                    Console.WriteLine("");
                    Console.Write("Press any key to continue. . .");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.Message}");
                Console.WriteLine("");
                Console.Write("Press any key to continue. . .");
            }



        }

        static void EditTriangleMenu(List<Shape> shapes)
        {
            TriangleDetails(shapes);

            Console.WriteLine("\n\n");
            Console.WriteLine("Editing Triangle");
            Console.Write("Enter ID of Triangle you want to edit: ");

            bool idFound = false;
            try
            {
                int id = int.Parse(Console.ReadLine());

                for (int i = 0; i < shapes.Count; i++)
                {
                    if (shapes[i].ShapeId == id)
                    {
                        Console.Write("Enter Triangle Edge A: ");
                        int sideA = int.Parse(Console.ReadLine());

                        Console.Write("Enter Triangle Edge B: ");
                        int sideB = int.Parse(Console.ReadLine());

                        Console.Write("Enter Triangle Edge C: ");
                        int sideC = int.Parse(Console.ReadLine());

                        Console.Write("Enter Opacity: ");
                        double opacity = double.Parse(Console.ReadLine());


                        if (sideA < 0 || sideB < 0 || sideC < 0 || sideC < 0 || opacity < 0)
                        {
                            Console.WriteLine("Sides A, B, C or Opacity can't be less than 0");
                            Console.WriteLine("");
                            Console.Write("Press any key to continue. . .");
                        }
                        else
                        {
                            foreach (Shape shape in shapes)
                            {
                                if (shape.ShapeId == id)
                                {
                                    if (shape.TypeOfShapes == ShapeTypes.Triangle && shape is Triangle triangleShapes)
                                    {
                                        Console.WriteLine($"Triangle with ID = {id} updated");
                                        triangleShapes.SideA = sideA;
                                        triangleShapes.SideB = sideB;
                                        triangleShapes.SideC = sideC;
                                        triangleShapes.OpacityChange(opacity);
                                        idFound = true;
                                        break;
                                    }
                                }

                            }

                        }
                    }

                }

                if (idFound)
                {
                    TriangleDetails(shapes);

                    Console.WriteLine("");
                    Console.Write("Press any key to continue. . .");
                }

                if (!idFound)
                {
                    Console.WriteLine("Id not found!");
                    Console.WriteLine("");
                    Console.Write("Press any key to continue. . .");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error! {ex.Message}");
                Console.WriteLine("");
                Console.Write("Press any key to continue. . .");
            }
        }



        static void DeleteShapeMenu(List<Shape> shapes)
        {
            Console.Clear();
            Details();

            Console.WriteLine("");
            Console.WriteLine("\tDelete Shape");
            Console.WriteLine("");
            Console.WriteLine("\t1. Delete Circle");
            Console.WriteLine("\t2. Delete Rectangle");
            Console.WriteLine("\t3. Delete Square");
            Console.WriteLine("\t4. Delete Triangle");
            Console.WriteLine("\t5. Back to Main Menu");
            Console.WriteLine("");
            Console.Write("Enter your choice: ");


            while (true)
            {
                int deleteChoice = 0;

                try
                {
                    deleteChoice = int.Parse(Console.ReadLine());

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid option! {ex.Message}");
                    break;
                }

                switch (deleteChoice)
                {
                    case 1:
                        DeleteCircleMenu(shapes);
                        continue;

                    case 2:
                        DeleteRectangleMenu(shapes);
                        continue;

                    case 3:
                        DeleteSquareMenu(shapes);
                        continue;

                    case 4:
                        DeleteTriangleMenu(shapes);
                        continue;

                    case 5:
                        return;

                    default:
                        Console.Write("Invalid choice!");
                        break;
                }
            }

        }

        static void DeleteCircleMenu(List<Shape> shapes)
        {
            CircleDetails(shapes);

            Console.Write("\n\n");
            Console.WriteLine("Deleting Circle");
            Console.Write("Enter ID of Circle you want to delete: ");
            bool idFound = false;

            try
            {
                int id = int.Parse(Console.ReadLine());

                for (int i = 0; i < shapes.Count; i++)
                {

                    if (id < 0)
                    {
                        throw new Exception("ID must be a positive number!");
                    }


                    if (shapes[i].ShapeId == id)
                    {
                        shapes.RemoveAt(i);
                        Console.WriteLine($"\nCircle with ID {id} deleted.");
                        idFound = true;
                        break;

                    }
                }

                if (idFound)
                {
                    CircleDetails(shapes);

                    Console.WriteLine("");
                    Console.Write("Press any key to continue. . .");
                }

                if (!idFound)
                {
                    Console.WriteLine("Id not found!");
                    Console.WriteLine("");
                    Console.Write("Press any key to continue. . .");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error! {e.Message}");
                Console.WriteLine("");
                Console.Write("Press any key to continue. . .");
            }
        }


        static void DeleteRectangleMenu(List<Shape> shapes)
        {
            RectangleDetails(shapes);

            Console.Write("\n\n");
            Console.WriteLine("Deleting Rectangle");
            Console.Write("Enter ID of Rectangle you want to delete: ");
            bool idFound = false;

            try
            {
                int id = int.Parse(Console.ReadLine());



                for (int i = 0; i < shapes.Count; i++)
                {

                    if (id < 0)
                    {
                        throw new Exception("ID must be a positive number!");
                    }


                    if (shapes[i].ShapeId == id)
                    {
                        shapes.RemoveAt(i);
                        Console.WriteLine($"\nRectangle with ID {id} deleted.");
                        idFound = true;
                        break;
                    }
                }

                if (idFound)
                {
                    RectangleDetails(shapes);

                    Console.WriteLine("");
                    Console.Write("Press any key to continue. . .");
                }

                if (!idFound)
                {
                    Console.WriteLine("Id not found!");
                    Console.WriteLine("");
                    Console.Write("Press any key to continue. . .");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error! {e.Message}");
                Console.WriteLine("");
                Console.Write("Press any key to continue. . .");
            }
        }

        static void DeleteSquareMenu(List<Shape> shapes)
        {
            SquareDetails(shapes);

            Console.Write("\n\n");
            Console.WriteLine("Deleting Square");
            Console.Write("Enter ID of Square you want to delete: ");
            bool idFound = false;

            try
            {
                int id = int.Parse(Console.ReadLine());

                for (int i = 0; i < shapes.Count; i++)
                {

                    if (id < 0)
                    {
                        throw new Exception("ID must be a positive number!");
                    }


                    if (shapes[i].ShapeId == id)
                    {
                        shapes.RemoveAt(i);
                        Console.WriteLine($"\nSquare with ID {id} deleted.");
                        idFound = true;
                        break;
                    }


                }

                if (idFound)
                {
                    SquareDetails(shapes);

                    Console.WriteLine("");
                    Console.Write("Press any key to continue. . .");
                }

                if (!idFound)
                {
                    Console.WriteLine("Id not found!");
                    Console.WriteLine("");
                    Console.Write("Press any key to continue. . .");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error! {e.Message}");
                Console.WriteLine("");
                Console.Write("Press any key to continue. . .");
            }
        }

        static void DeleteTriangleMenu(List<Shape> shapes)
        {
            TriangleDetails(shapes);

            Console.Write("\n\n");
            Console.WriteLine("Deleting Triangle");
            Console.Write("Enter ID of Triangle you want to delete: ");
            bool idFound = false;

            try
            {
                int id = int.Parse(Console.ReadLine());

                for (int i = 0; i < shapes.Count; i++)
                {
                    if (id < 0)
                    {
                        throw new Exception("ID must be a positive number!");
                    }


                    if (shapes[i].ShapeId == id)
                    {

                        shapes.RemoveAt(i);
                        Console.WriteLine($"\nTriangle with ID {id} deleted.");
                        idFound = true;
                        break;
                    }
                }

                if (idFound)
                {
                    TriangleDetails(shapes);

                    Console.WriteLine("");
                    Console.Write("Press any key to continue. . .");
                }

                if (!idFound)
                {
                    Console.WriteLine("Id not found!");
                    Console.WriteLine("");
                    Console.Write("Press any key to continue. . .");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error! {e.Message}");
                Console.WriteLine("");
                Console.Write("Press any key to continue. . .");

            }
        }

        static void Main(string[] args)
        {
            // start of the program

            // premade objects

            List<Shape> shapes = new List<Shape>();

            shapes.Add(new Circle(generateId(), ShapeTypes.Circle, 20, .2));
            shapes.Add(new Circle(generateId(), ShapeTypes.Circle, 12, .2));
            shapes.Add(new Circle(generateId(), ShapeTypes.Circle, 35, .3));

            shapes.Add(new Rectangle(generateId(), ShapeTypes.Rectangle, 5, 10, .1));
            shapes.Add(new Rectangle(generateId(), ShapeTypes.Rectangle, 3, 7, .10));

            shapes.Add(new Triangle(generateId(), ShapeTypes.Triangle, 1, 2, 3, .1));
            shapes.Add(new Triangle(generateId(), ShapeTypes.Triangle, 3, 7, 9, .3));

            shapes.Add(new Square(generateId(), ShapeTypes.Square, 7, .30));

            while (true)
            {
                Console.Clear();

                Details();

                DisplayMenu(); // displays the menu

                int choice;

                try
                {
                    choice = int.Parse(Console.ReadLine());

                    if (choice < 1 || choice > 5)
                    {
                        throw new Exception("Choice out of bounds! Only choose from 1 - 5");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid input: {ex.Message}");
                    break;
                }

                switch (choice)
                {
                    case 1:
                        AddShapeMenu(shapes);
                        continue;

                    case 2:
                        EditShapeMenu(shapes);
                        continue;

                    case 3:
                        DeleteShapeMenu(shapes);
                        continue;

                    case 4:
                        ViewShapes(shapes); // here we are passing the list that way we can access it 
                        continue;

                    case 5:
                        Console.WriteLine("Exiting program!");
                        return;

                    default:
                        Console.WriteLine("Invalid option, only options 1-5 are available.");
                        return;

                }

            }
        }
    }
}
