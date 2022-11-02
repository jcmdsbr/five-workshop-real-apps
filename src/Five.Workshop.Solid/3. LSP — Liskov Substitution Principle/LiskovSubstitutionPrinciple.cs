namespace Five.Workshop.Solid._3._LSP___Liskov_Substitution_Principle;

public class LiskovSubstitutionPrinciple
{
    public class Parallelogram
    {
        public Parallelogram(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height { get; set; }
        public double Width { get; set; }
        public double Area => Height * Width;
    }

    public class Square : Parallelogram
    {
        public Square(double height, double width) : base(height, width)
        {
            if (height != width)
                throw new ArgumentException("Os dois lados do quadrado precisam ser iguais");
        }
    }

    public class Rectangle : Parallelogram
    {
        public Rectangle(double height, double width) : base(height, width)
        {
        }
    }

    public class Program
    {
        public void Main()
        {
            var quad = new Square(5, 5);
            var ret = new Rectangle(10, 5);

            GetArea(quad);
            GetArea(ret);
        }

        public void GetArea(Parallelogram parallelogram)
        {
            Console.WriteLine(parallelogram.Height + " * " + parallelogram.Width);
            Console.WriteLine();
            Console.WriteLine(parallelogram.Area);
        }
    }
}