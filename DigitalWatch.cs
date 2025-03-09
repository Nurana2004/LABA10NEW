using System;

namespace ClockLibrary
{
    public class DigitalWatch : Clock //частное от общего Clock, наследует все от него добавляя свои уникальные свойства
    {
        public string DisplayType;

        public DigitalWatch(string brand, int year, IdNumber id, string displayType) : base(brand, year, id)  // Вызов конструктора базового класса, c помощью base
        {
            DisplayType = displayType; //После вызова конструктора базового класса инициализируются поля, специфичные для производного класса.
        }

        public DigitalWatch() : base()
        {
            DisplayType = "";
        }

        public override void Init() //Виртуальные методы могут быть переопределены в производных классах.
        {
            base.Init();
            Console.WriteLine("Введите тип дисплея (LED, LCD, OLED и т. д.)"); //Виртуальные методы поддерживают полиморфизм. Это значит, что метод, вызванный через ссылку на базовый класс, будет выполнять реализацию из производного класса.
            DisplayType = Console.ReadLine(); //Их вызов разрешается на этапе выполнения (динамически), что немного медленнее, чем у не виртуальных методов.
        }

        public override string ToString()
        {
            string outStr = base.ToString();
            outStr += "\t|Тип дисплея: " + DisplayType;
            return outStr;
        }

        public override bool Equals(object? obj) //Программа без виртуальных методов работает быстрее, так как вызов методов разрешается на этапе компиляции.
        {
            if (obj == null) return false;
            DigitalWatch other = obj as DigitalWatch;
            if (other == null || !this.DisplayType.Equals(other.DisplayType)) return false;

            return base.Equals(obj);
        }

        public override object RandomCreate()
        {
            base.RandomCreate();
            String[] displayTypes = { "LED", "LCD", "OLED" };
            Random random = new Random();
            DisplayType = displayTypes[random.Next(displayTypes.Length)];
            return this;
        }

        public void ShowTypeNotVirtual()
        {
            Console.WriteLine("Тип класса - Электронные часы");
        }

        public object Clone()
        {
            return new DigitalWatch(this.Brand, this.Year, new IdNumber(Id.Number), this.DisplayType);
        }

        public DigitalWatch ShallowCopy()
        {
            return (DigitalWatch)this.MemberwiseClone();
        }
    }

}
