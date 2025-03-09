
using ClockLibrary;

namespace TestProject
{
    [TestClass]
    public class ClockTests
    {
        [TestMethod]
        public void Clock_Constructor_InitializesProperties()
        {
            IdNumber id = new IdNumber(123);
            Clock clock = new Clock("Casio", 2023, id);

            Assert.AreEqual("Casio", clock.Brand);
            Assert.AreEqual(2023, clock.Year);
            Assert.AreEqual(id, clock.Id);
        }

        [TestMethod]
        public void Clock_Equals_ReturnsTrueForSameObjects()
        {
            IdNumber id = new IdNumber(123);
            Clock clock1 = new Clock("Casio", 2023, id);
            Clock clock2 = new Clock("Casio", 2023, id);

            Assert.IsTrue(clock1.Equals(clock2));
        }

        [TestMethod]
        public void Clock_Equals_ReturnsFalseForDifferentObjects()
        {
            Clock clock1 = new Clock("Casio", 2023, new IdNumber(123));
            Clock clock2 = new Clock("Rolex", 2023, new IdNumber(456));

            Assert.IsFalse(clock1.Equals(clock2));
        }


        [TestMethod]
        public void Clock_RandomCreate_GeneratesValidObject()
        {
            Clock clock = new Clock();
            clock.RandomCreate();

            Assert.IsNotNull(clock.Brand);
            Assert.IsTrue(clock.Year > 0);
            Assert.IsNotNull(clock.Id);
        }

        [TestMethod]
        public void Clock_Clone_CreatesDeepCopy()
        {
            Clock clock = new Clock("Casio", 2023, new IdNumber(123));
            Clock clone = (Clock)clock.Clone();

            Assert.AreEqual(clock.Brand, clone.Brand);
            Assert.AreEqual(clock.Year, clone.Year);
            Assert.AreEqual(clock.Id.Number, clone.Id.Number);
        }

        [TestMethod]
        public void Clock_ShallowCopy_CreatesShallowCopy()
        {
            Clock clock = new Clock("Casio", 2023, new IdNumber(123));
            Clock shallowCopy = clock.ShallowCopy();

            Assert.AreEqual(clock.Brand, shallowCopy.Brand);
            Assert.AreEqual(clock.Year, shallowCopy.Year);
            Assert.AreEqual(clock.Id.Number, shallowCopy.Id.Number);
        }
    }
    [TestClass]
    public class ClassicWatchTests
    {
        [TestMethod]
        public void ClassicWatch_Constructor_InitializesProperties()
        {
            IdNumber id = new IdNumber(123);
            ClassicWatch classicWatch = new ClassicWatch("Casio", 2023, "Классический", id);

            Assert.AreEqual("Casio", classicWatch.Brand);
            Assert.AreEqual(2023, classicWatch.Year);
            Assert.AreEqual("Классический", classicWatch.Style);
            Assert.AreEqual(id, classicWatch.Id);
        }

        [TestMethod]
        public void ClassicWatch_Equals_ReturnsTrueForSameObjects()
        {
            IdNumber id = new IdNumber(123);
            ClassicWatch classicWatch1 = new ClassicWatch("Casio", 2023, "Классический", id);
            ClassicWatch classicWatch2 = new ClassicWatch("Casio", 2023, "Классический", id);

            Assert.IsTrue(classicWatch1.Equals(classicWatch2));
        }

        [TestMethod]
        public void ClassicWatch_Equals_ReturnsFalseForDifferentObjects()
        {
            ClassicWatch classicWatch1 = new ClassicWatch("Casio", 2023, "Классический", new IdNumber(123));
            ClassicWatch classicWatch2 = new ClassicWatch("Rolex", 2023, "Ретро", new IdNumber(456));

            Assert.IsFalse(classicWatch1.Equals(classicWatch2));
        }

        [TestMethod]
        public void ClassicWatch_RandomCreate_GeneratesValidObject()
        {
            ClassicWatch classicWatch = new ClassicWatch();
            classicWatch.RandomCreate();

            Assert.IsNotNull(classicWatch.Brand);
            Assert.IsTrue(classicWatch.Year > 0);
            Assert.IsNotNull(classicWatch.Style);
            Assert.IsNotNull(classicWatch.Id);
        }
    }
    [TestClass]
    public class SmartWatchTests
    {
        [TestMethod]
        public void SmartWatch_Constructor_InitializesProperties()
        {
            IdNumber id = new IdNumber(123);
            SmartWatch smartWatch = new SmartWatch("Apple", 2023, id, "WatchOS", true);

            Assert.AreEqual("Apple", smartWatch.Brand);
            Assert.AreEqual(2023, smartWatch.Year);
            Assert.AreEqual("WatchOS", smartWatch.OperatingSystem);
            Assert.IsTrue(smartWatch.isPulseSensor);
            Assert.AreEqual(id, smartWatch.Id);
        }

        [TestMethod]
        public void SmartWatch_Equals_ReturnsTrueForSameObjects()
        {
            IdNumber id = new IdNumber(123);
            SmartWatch smartWatch1 = new SmartWatch("Apple", 2023, id, "WatchOS", true);
            SmartWatch smartWatch2 = new SmartWatch("Apple", 2023, id, "WatchOS", true);

            Assert.IsTrue(smartWatch1.Equals(smartWatch2));
        }

        [TestMethod]
        public void SmartWatch_Equals_ReturnsFalseForDifferentObjects()
        {
            SmartWatch smartWatch1 = new SmartWatch("Apple", 2023, new IdNumber(123), "WatchOS", true);
            SmartWatch smartWatch2 = new SmartWatch("Samsung", 2023, new IdNumber(456), "Android Wear", false);

            Assert.IsFalse(smartWatch1.Equals(smartWatch2));
        }

        [TestMethod]
        public void SmartWatch_RandomCreate_GeneratesValidObject()
        {
            SmartWatch smartWatch = new SmartWatch();
            smartWatch.RandomCreate();

            Assert.IsNotNull(smartWatch.Brand);
            Assert.IsTrue(smartWatch.Year > 0);
            Assert.IsNotNull(smartWatch.OperatingSystem);
            Assert.IsNotNull(smartWatch.Id);
        }
    }
    [TestClass]
    public class DigitalWatchTests
    {
        [TestMethod]
        public void DigitalWatch_Constructor_InitializesProperties()
        {
            IdNumber id = new IdNumber(123);
            DigitalWatch digitalWatch = new DigitalWatch("Casio", 2023, id, "LED");

            Assert.AreEqual("Casio", digitalWatch.Brand);
            Assert.AreEqual(2023, digitalWatch.Year);
            Assert.AreEqual("LED", digitalWatch.DisplayType);
            Assert.AreEqual(id, digitalWatch.Id);
        }

        [TestMethod]
        public void DigitalWatch_Equals_ReturnsTrueForSameObjects()
        {
            IdNumber id = new IdNumber(123);
            DigitalWatch digitalWatch1 = new DigitalWatch("Casio", 2023, id, "LED");
            DigitalWatch digitalWatch2 = new DigitalWatch("Casio", 2023, id, "LED");

            Assert.IsTrue(digitalWatch1.Equals(digitalWatch2));
        }

        [TestMethod]
        public void DigitalWatch_Equals_ReturnsFalseForDifferentObjects()
        {
            DigitalWatch digitalWatch1 = new DigitalWatch("Casio", 2023, new IdNumber(123), "LED");
            DigitalWatch digitalWatch2 = new DigitalWatch("Rolex", 2023, new IdNumber(456), "LCD");

            Assert.IsFalse(digitalWatch1.Equals(digitalWatch2));
        }

        [TestMethod]
        public void DigitalWatch_RandomCreate_GeneratesValidObject()
        {
            DigitalWatch digitalWatch = new DigitalWatch();
            digitalWatch.RandomCreate();

            Assert.IsNotNull(digitalWatch.Brand);
            Assert.IsTrue(digitalWatch.Year > 0);
            Assert.IsNotNull(digitalWatch.DisplayType);
            Assert.IsNotNull(digitalWatch.Id);
        }
    }
    [TestClass]
    public class IdNumberTests
    {
        [TestMethod]
        public void IdNumber_Constructor_InitializesNumberCorrectly()
        {
            IdNumber id = new IdNumber(123);
            Assert.AreEqual(123, id.Number);
        }

        [TestMethod]
        public void IdNumber_Equals_ReturnsTrueForSameNumbers()
        {
            IdNumber id1 = new IdNumber(123);
            IdNumber id2 = new IdNumber(123);

            Assert.IsTrue(id1.Equals(id2));
        }

        [TestMethod]
        public void IdNumber_Equals_ReturnsFalseForDifferentNumbers()
        {
            IdNumber id1 = new IdNumber(123);
            IdNumber id2 = new IdNumber(456);

            Assert.IsFalse(id1.Equals(id2));
        }
        [TestMethod]
        public void IdNumber_Number_SetNegativeValue_DefaultsToZero()
        {
            IdNumber id = new IdNumber(123);
            id.Number = -10;

            Assert.AreEqual(0, id.Number);
        }

        [TestMethod]
        public void IdNumber_Number_SetPositiveValue_UpdatesCorrectly()
        {
            IdNumber id = new IdNumber(123);
            id.Number = 456;

            Assert.AreEqual(456, id.Number);
        }
    }
    [TestClass]
    public class ClockComparerTests
    {
        [TestMethod]
        public void ClockComparer_Compare_ReturnsNegativeForEarlierYear()
        {
            ClockComparer comparer = new ClockComparer();
            Clock clock1 = new Clock("Casio", 2020, new IdNumber(1));
            Clock clock2 = new Clock("Rolex", 2023, new IdNumber(2));

            int result = comparer.Compare(clock1, clock2);
            Assert.IsTrue(result < 0);
        }

        [TestMethod]
        public void ClockComparer_Compare_ReturnsZeroForSameYear()
        {
            ClockComparer comparer = new ClockComparer();
            Clock clock1 = new Clock("Casio", 2023, new IdNumber(1));
            Clock clock2 = new Clock("Rolex", 2023, new IdNumber(2));

            int result = comparer.Compare(clock1, clock2);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ClockComparer_Compare_ReturnsPositiveForLaterYear()
        {
            ClockComparer comparer = new ClockComparer();
            Clock clock1 = new Clock("Rolex", 2023, new IdNumber(1));
            Clock clock2 = new Clock("Casio", 2020, new IdNumber(2));

            int result = comparer.Compare(clock1, clock2);
            Assert.IsTrue(result > 0);
        }
    }
}
