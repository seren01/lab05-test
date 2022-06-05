using System;

namespace app
{
    abstract class Figure
    {
        public abstract string Area();
        public abstract string Perimeter();
        public abstract string ShapeName();

        public void ShowInfo()
        {
            Console.WriteLine(
                $"Название фигуры: {ShapeName()}\n" +
                $"Площадь: {Area()}\n" +
                $"Периметр: {Perimeter()}"
                );
            Console.WriteLine();
        }
    }

    class Triangle : Figure
    {
        double sideA, sideB, sideC;   // Стороны треугольника

        // Конструктор
        public Triangle(double triangleSideA, double triangleSideB, double triangleSideC)
        {
            SideA = triangleSideA;
            SideB = triangleSideB;
            SideC = triangleSideC;
        }

        // Свойство, проверяем значение на отрицательность.
        // Если значение отрицательное меняем его на аналогичное положительное.
        public double SideA
        {
            get { return sideA; }
            set { sideA = value < 0 ? -value : value; }
        }

        public double SideB
        {
            get { return sideB; }
            set { sideB = value < 0 ? -value : value; }
        }

        public double SideC
        {
            get { return sideC; }
            set { sideC = value < 0 ? -value : value; }
        }

        // Метод для вычисления площади треугольника
        public override string Area()
        {
            double semPer = (sideA + sideB + sideC) / 2;
            return Math.Sqrt(semPer * (semPer - sideA) * (semPer - sideB) * (semPer - sideC)).ToString();
        }

        // Метод для вычисления периметра треугольника
        public override string Perimeter()
        {
            return (sideA + sideB + sideC).ToString();
        }

        // Метод возвращающий наименование фигуры
        public override string ShapeName()
        {
            return "Треугольник";
        }
    }

    class Square : Figure
    {
        double side;   // Сторона квадрата

        // Конструктор
        public Square(double squareSide)
        {
            Side = squareSide;
        }

        // Свойство, проверяем значение на отрицательность.
        public double Side
        {
            get { return side; }
            set { side = value < 0 ? -value : value; }
        }

        // Метод для вычисления площади квадрата
        public override string Area()
        {
            return (side * side).ToString();
        }

        // Метод для вычисления периметра квадрата
        public override string Perimeter()
        {
            return (side * 4).ToString();
        }

        // Метод возвращающий наименование фигуры
        public override string ShapeName()
        {
            return "Квадрат";
        }
    }

    class Rectangle : Figure
    {
        double width;   // Ширина прямоугольника
        double height;   // Высота прямоугольника

        // Конструктор
        public Rectangle(double rectangleWidth, double rectangleHeight)
        {
            Width = rectangleWidth;
            Height = rectangleHeight;
        }

        // Свойство, проверяем значение на отрицательность.
        public double Width
        {
            get { return width; }
            set { width = value < 0 ? -value : value; }
        }

        public double Height
        {
            get { return height; }
            set { height = value < 0 ? -value : value; }
        }

        // Метод для вычисления площади прямоугольника
        public override string Area()
        {
            return (width * height).ToString();
        }

        // Метод для вычисления периметра прямоугольника
        public override string Perimeter()
        {
            return (width * 2 + height * 2).ToString();
        }

        // Метод возвращающий наименование фигуры
        public override string ShapeName()
        {
            return "Прямоугольник";
        }
    }

    class Program
    {
        static void Main()
        {
            Figure figure1 = new Triangle(3, 5, 6);
            figure1.ShowInfo();

            Figure figure2 = new Square(5);
            figure2.ShowInfo();

            Figure figure3 = new Rectangle(5, 6);
            figure3.ShowInfo();

            Console.ReadKey();
        }
    }
}
