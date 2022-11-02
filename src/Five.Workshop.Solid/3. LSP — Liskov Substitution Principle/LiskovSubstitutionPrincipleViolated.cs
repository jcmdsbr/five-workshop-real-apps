namespace Five.Workshop.Solid._3._LSP___Liskov_Substitution_Principle;

public class LiskovSubstitutionPrincipleViolated
{
    public class Rectangle
    {
        public virtual double Height { get; set; }
        public virtual double Width { get; set; }
        public double Area => Height * Width;
    }

    public class Square : Rectangle
    {
        public override double Height
        {
            set => base.Height = base.Width = value;
        }

        public override double Width
        {
            set => base.Height = base.Width = value;
        }
    }

    public class Program
    {
        public void Main()
        {
            var rectangle = new Rectangle
            {
                Height = 10,
                Width = 5
            };

            GetArea(rectangle); // retorna 50

            // Não impede setar valores diferentes
            var square = new Square
            {
                Height = 10,
                Width = 5
            };

            GetArea(square); // o método pode retornar 100 ou 25 dependendo da ordem que as propriedades foram setadas.
        }

        public void GetArea(Rectangle rectangle)
        {
            Console.WriteLine(rectangle.Height + " * " + rectangle.Width);
            Console.WriteLine();
            Console.WriteLine(rectangle.Area);
        }
    }
}