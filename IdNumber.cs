namespace ClockLibrary
{
    public class IdNumber
    {
        private int number;
        public int Number
        {
            get { return number; }
            set { number = value < 0 ? 0 : value; }
        }

        public IdNumber(int number)
        {
            Number = number;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != typeof(IdNumber)) return false;
            IdNumber other = (IdNumber)obj;
            return this.Number == other.Number;
        }

        public override string ToString()
        {
            return $"ID: {Number}";
        }
    }
}
