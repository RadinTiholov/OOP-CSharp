using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }

        [Test]
        public void CtorWroksFine()
        {
            Assert.That(raceEntry.Counter, Is.EqualTo(0));
        }
        [Test]
        public void CountGetterWorksFine()
        {
            UnitCar car = new UnitCar("asd", 10, 12.3);
            UnitDriver driver = new UnitDriver("Gosho", car);
            UnitCar car1 = new UnitCar("aaddssd", 110, 122.3);
            UnitDriver driver1 = new UnitDriver("Misho", car1);
            raceEntry.AddDriver(driver);
            raceEntry.AddDriver(driver1);
            Assert.That(raceEntry.Counter, Is.EqualTo(2));
        }
        [Test]
        public void AddDriverThrowsExceptionWhenNull()
        {
            Assert.That(() => raceEntry.AddDriver(null), Throws.InvalidOperationException);
        }
        [Test]
        public void AddDriverThrowsExceptionWhenAlreadyExists()
        {
            UnitCar car = new UnitCar("asd", 10, 12.3);
            UnitDriver driver = new UnitDriver("Gosho", car);
            raceEntry.AddDriver(driver);

            UnitCar car1 = new UnitCar("aaddssd", 110, 122.3);
            UnitDriver driver1 = new UnitDriver("Gosho", car1);

            Assert.That(() => raceEntry.AddDriver(driver1), Throws.InvalidOperationException);
        }
        [Test]
        public void AddDriverWorksFine()
        {
            UnitCar car = new UnitCar("asd", 10, 12.3);
            UnitDriver driver = new UnitDriver("Gosho", car);
            string firstResult = raceEntry.AddDriver(driver);

            UnitCar car1 = new UnitCar("asdaa", 20, 12.3);
            UnitDriver driver1 = new UnitDriver("GoshoPPP", car1);
            string secondResult = raceEntry.AddDriver(driver1);

            Assert.That(firstResult, Is.EqualTo("Driver Gosho added in race."));
            Assert.That(secondResult, Is.EqualTo("Driver GoshoPPP added in race."));
            Assert.That(raceEntry.Counter, Is.EqualTo(2));
            Assert.That(raceEntry.CalculateAverageHorsePower, Is.EqualTo(15));
        }
        [Test]
        public void CalculateAverageHorsePowerThrowsExceptionWhenDontPassMin() 
        {
            UnitCar car = new UnitCar("asd", 10, 12.3);
            UnitDriver driver = new UnitDriver("Gosho", car);
            string firstResult = raceEntry.AddDriver(driver);

            Assert.That(raceEntry.CalculateAverageHorsePower, Throws.InvalidOperationException);
        }
        [Test]
        public void CalculateAverageHorsePowerWorksFine()
        {
            UnitCar car = new UnitCar("asd", 10, 12.3);
            UnitDriver driver = new UnitDriver("Gosho", car);
            string firstResult = raceEntry.AddDriver(driver);

            UnitCar car1 = new UnitCar("asdaa", 20, 12.3);
            UnitDriver driver1 = new UnitDriver("GoshoPPP", car1);
            string secondResult = raceEntry.AddDriver(driver1);

            UnitCar car2 = new UnitCar("asdaa", 30, 12.3);
            UnitDriver driver2 = new UnitDriver("GoshoASSS", car2);
            string thirdResult = raceEntry.AddDriver(driver2);

            Assert.That(raceEntry.CalculateAverageHorsePower, Is.EqualTo(20));
        }
        [Test]
        public void UnitDriverNameThrowsException()
        {
            UnitCar car2 = new UnitCar("asdaa", 30, 12.3);
            UnitDriver driver = null;
            Assert.That(() => driver = new UnitDriver(null,car2), Throws.ArgumentNullException);
        }
    }
}