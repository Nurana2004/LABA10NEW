using System.Collections.Generic;

namespace ClockLibrary
{
    public class ClockComparer :   IComparer<Clock>
    {
        public int Compare(Clock x, Clock y)
        {
            return x.Year.CompareTo(y.Year);
        }
    }
}
