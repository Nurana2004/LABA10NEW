using System;

namespace Lab9lib
{
    public class Rectangle
    {
        // Закрытые атрибуты
        private double length;
        private double width;

        // Статическая переменная для подсчета количества созданных объектов
        private static int count = 0;

        // Конструктор без параметров
        public Rectangle()
        {
            length = 1.0;
            width = 1.0;
            count++;
        }

        // Конструктор с параметрами
        public Rectangle(double length, double width)
        {
            Length = length; // Используем свойство для установки значения
            Width = width;   // Используем свойство для установки значения
            count++;
        }

        // Свойство для длины с проверкой на ограничения
        public double Length
        {
            get { return length; }
            set
            {
                if (value < 0.0001 || value > 46340.9499)
                    throw new ArgumentOutOfRangeException("Length must be between 0.0001 and 46340.9499");
                length = value;
            }
        }

        // Свойство для ширины с проверкой на ограничения
        public double Width
        {
            get { return width; }
            set
            {
                if (value < 0.0001 || value > 46340.9499)
                    throw new ArgumentOutOfRangeException("Width must be between 0.0001 and 46340.9499");
                width = value;
            }
        }

        // Метод для увеличения сторон прямоугольника в N раз
        public Rectangle Multiply(int N)
        {
            return new Rectangle(this.Length * N, this.Width * N);
        }

        // Статический метод для увеличения сторон прямоугольника в N раз
        public static Rectangle Multiply(Rectangle rect, int N)
        {
            return new Rectangle(rect.Length * N, rect.Width * N);
        }

        // Метод для вывода информации о прямоугольнике
        public void Display()
        {
            Console.WriteLine($"Rectangle: Length = {Length}, Width = {Width}");
        }

        // Статический метод для получения количества созданных объектов
        public static int GetCount()
        {
            return count;
        }

        // Перегрузка оператора ++
        public static Rectangle operator ++(Rectangle rect)
        {
            return new Rectangle(rect.Length + 1, rect.Width + 1);
        }

        // Перегрузка оператора --
        public static Rectangle operator --(Rectangle rect)
        {
            return new Rectangle(rect.Length - 1, rect.Width - 1);
        }

        // Перегрузка оператора приведения типа double (явная)
        public static explicit operator double(Rectangle rect)
        {
            double diagonal = Math.Sqrt((rect.Length * rect.Length) + (rect.Width * rect.Width));
            double radius = diagonal / 2;
            double area = Math.PI * (radius * radius);
            return Math.Floor(area * 10000) / 10000;
        }

        // Перегрузка оператора приведения типа bool (неявная)
        public static implicit operator bool(Rectangle rect)
        {
            return rect.Length == rect.Width;
        }

        // Перегрузка оператора +
        public static Rectangle operator +(Rectangle rect, double num)
        {
            return new Rectangle(rect.Length + num, rect.Width + num);
        }

        // Перегрузка оператора -
        public static Rectangle operator -(Rectangle rect, double num)
        {
            return new Rectangle(rect.Length - num, rect.Width - num);
        }

        // Переопределение метода Equals для сравнения двух объектов
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Rectangle other = (Rectangle)obj;
            return this.Length == other.Length && this.Width == other.Width;
        }

        public override int GetHashCode()
        {
            return (Length, Width).GetHashCode();
        }
    }
}
