using System;

namespace ClockLibrary
{
    public class ClassicWatch : Clock
    {
        public string Style { get; set; }

        public ClassicWatch(String brand, int year, string style, IdNumber idNumber) : base(brand, year, idNumber)
        {
            Style = style;
        }

        public ClassicWatch() : base()
        {
            Style = "";
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите стиль часов (классический, ретро, винтаж и т. д.)");
            Style = Console.ReadLine();
        }
        public void ShowTypeNotVirtual()
        {
            Console.WriteLine("Тип класса - Классические часы");
        }
        public override String ToString()
        {
            String outStr = base.ToString();
            outStr += "\t|Стиль: " + Style;
            return outStr;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            ClassicWatch other = obj as ClassicWatch;
            if (other == null || !this.Style.Equals(other.Style)) return false;

            return base.Equals(obj as Clock);
        }

        public override object RandomCreate()
        {
            base.RandomCreate();
            String[] styles = { "Классический", "Ретро", "Винтаж" };
            Random random = new Random();
            Style = styles[random.Next(styles.Length)];
            return this;
        }

        public int CompareTo(ClassicWatch other)
        {
            return this.Id.Number.CompareTo(other.Id.Number);
        }

        public object Clone()
        {
            return new ClassicWatch(this.Brand, this.Year, this.Style, new IdNumber(Id.Number));
        }

        public ClassicWatch ShallowCopy()
        {
            return (ClassicWatch)this.MemberwiseClone();
        }

    }
}
