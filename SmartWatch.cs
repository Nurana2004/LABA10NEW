using System;

namespace ClockLibrary
{
    public class SmartWatch : Clock
    {
        public string OperatingSystem;
        public bool isPulseSensor;

        public SmartWatch(string brand, int year, IdNumber id, string operatingSystem, bool isPulseSensor)
            : base(brand, year, id)
        {
            OperatingSystem = operatingSystem;
            this.isPulseSensor = isPulseSensor;
        }

        public SmartWatch() : base()
        {
            OperatingSystem = "";
            isPulseSensor = false;
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите операционную систему");
            OperatingSystem = Console.ReadLine();
            Console.WriteLine("Введите 0 если часы не имеют датчика пульса\nВведите любое другое число если часы имеют датчик пульса");
            int choice = int.Parse(Console.ReadLine());
            isPulseSensor = choice != 0;
        }

        public override string ToString()
        {
            string outStr = base.ToString();
            outStr += "\t|Операционная система: " + OperatingSystem + "\t|";
            outStr += isPulseSensor ? "С пульсометром" : "Без пульсометра";
            return outStr;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            SmartWatch other = obj as SmartWatch;
            if (other == null || !this.OperatingSystem.Equals(other.OperatingSystem) || this.isPulseSensor != other.isPulseSensor)
                return false;

            return base.Equals(obj);
        }

        public override object RandomCreate()
        {
            base.RandomCreate();
            String[] osForRandom = { "Android Wear", "WatchOS", "Garmin" };
            Random random = new Random();
            isPulseSensor = random.Next(2) == 1;
            OperatingSystem = osForRandom[random.Next(osForRandom.Length)];
            return this;
        }

        public void ShowTypeNotVirtual()
        {
            Console.WriteLine("Тип класса - Умные часы");
        }

        public object Clone()
        {
            return new SmartWatch(this.Brand, this.Year, new IdNumber(Id.Number), this.OperatingSystem, this.isPulseSensor);
        }

        public SmartWatch ShallowCopy()
        {
            return (SmartWatch)this.MemberwiseClone();
        }
    }
}
