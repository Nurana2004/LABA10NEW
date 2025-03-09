using System;

namespace Lab9lib
{
    public class RectangleArray
    {
        private Rectangle[] arr;

        // Конструктор без параметров
        public RectangleArray()
        {
            arr = new Rectangle[0];
        }

        // Конструктор с параметрами, заполняющий элементы случайными значениями
        public RectangleArray(int size)
        {
            Random rand = new Random();
            arr = new Rectangle[size];
            for (int i = 0; i < size; i++)
            {
                double length = rand.NextDouble() * 46340.9499;
                double width = rand.NextDouble() * 46340.9499;
                arr[i] = new Rectangle(length, width);
            }
        }

        // Конструктор копирования
        public RectangleArray(RectangleArray other)
        {
            arr = new Rectangle[other.arr.Length];
            for (int i = 0; i < other.arr.Length; i++)
            {
                arr[i] = new Rectangle(other.arr[i].Length, other.arr[i].Width);
            }
        }

        // Метод для получения длины массива
        public int GetLength()
        {
            return arr.Length;
        }
        // Метод для просмотра элементов массива
        public void Display()
        {
            foreach (var rect in arr)
            {
                rect.Display();
            }
        }

        // Индексатор для доступа к элементам коллекции
        public Rectangle this[int index]
        {
            get
            {
                if (index < 0 || index >= arr.Length)
                    throw new IndexOutOfRangeException("Index is out of range");
                return arr[index];
            }
            set
            {
                if (index < 0 || index >= arr.Length)
                    throw new IndexOutOfRangeException("Index is out of range");
                arr[index] = value;
            }
        }

        // Метод для нахождения среднего арифметического площадей описанных окружностей
        public double AverageCircumscribedCircleArea()
        {
            double sum = 0;
            foreach (var rect in arr)
            {
                sum += (double)rect;
            }
            return Math.Round(sum / arr.Length, 4);
        }
    }
}
