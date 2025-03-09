using System;
using System.Threading;

namespace ClockLibrary
{
    public class Clock : IRandomCreate, IInit, IClonable //общее
    {
        private Random random = new Random();//иначе при рандоме все числа одинаковые
        private int year;
        public String Brand { get; set; }
        public int Year
        {
            get
            { return year; }
            set
            {
                if (value > 0) year = value;
            }
        }

        public Clock(String brand, int year, IdNumber idNumber) //конструктор base
        {
            Brand = brand;
            Year = year;
            Id = idNumber;
        }
        public Clock()
        {
            Brand = "";
            Year = 0;
            Id = new IdNumber(0);
        }
        public IdNumber Id { get; set; }

        public virtual void Show()
        {
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("Тип класса: " + this.GetType().Name + this.ToString());
        }

        public void ShowTypeNotVirtual()
        {
            Console.WriteLine("Тип класса - Часы"); //сугубо для демонстрации механизма переопределения невиртуального метода
        }
        public virtual void Init()
        {
            Console.WriteLine("Введите бренд часов");
            Brand = Console.ReadLine();

            Console.WriteLine("Введите год изготовления");
            Year = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Введите ID номера");
            Id.Number = int.Parse(Console.ReadLine());
        }
        public virtual object RandomCreate()
        {
            String[] brandsForRandom = { "Картье", "Касио", "Свотч", "Яблоко", "Груша", "Сяоми", "Мибэнд" };
            Brand = brandsForRandom[random.Next(brandsForRandom.Length)];
            Year = random.Next(1, DateTime.Now.Year);
            Thread.Sleep(100);//Иначе генерация слишком одинаковых чисел
            Id = new IdNumber(random.Next(1000));
            return this;
        }
        public virtual String ToString()
        {
            return "\tБренд: " + Brand + "\t|Год изготовления: " + Year + "\t|" + Id;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            Clock secondClock = obj as Clock;
            if (!Brand.Equals(secondClock.Brand)) return false;
            if (!year.Equals(secondClock.Year)) return false;
            return true;
        }

        public object Clone()
        {
            return new Clock(this.Brand, this.Year, new IdNumber(Id.Number));
        }

        public Clock ShallowCopy()
        {
            return (Clock)this.MemberwiseClone();
        }
    }
}
