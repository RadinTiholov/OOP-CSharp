using NUnit.Framework;
using CarManager;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car("Corsa", "Opel", 10, 90);
        }

        [Test]
        public void CtorWorksAsItShould()
        {
            Assert.That(car.Make, Is.EqualTo("Corsa"));
            Assert.That(car.Model, Is.EqualTo("Opel"));
            Assert.That(car.FuelConsumption, Is.EqualTo(10));
            Assert.That(car.FuelCapacity, Is.EqualTo(90));
            Assert.That(car.FuelAmount, Is.EqualTo(0.0));
        }
        [Test]
        [TestCase("asdas","aasd",-12, 34)]
        [TestCase("asdas","aasd",0, 34)]
        [TestCase("asdas","aasd",12, -34)]
        [TestCase("asdas","aasd",12, 0)]
        [TestCase("","aasd",12, 34)]
        [TestCase(null,"aasd",12, 34)]
        [TestCase("asdasd","",12, 34)]
        [TestCase("asdasd", null,12, 34)]
        public void CtorThrowsExceptionIfInvalidparameters(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.That(() => car = new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException);
        }
        [Test]
        public void MakeGetterWorks()
        {
            string make = car.Make;
            Assert.That(make, Is.EqualTo("Corsa"));
        }
        [Test]
        public void ModelGetterWorks()
        {
            string model = car.Model;
            Assert.That(model, Is.EqualTo("Opel"));
        }
        [Test]
        public void FuelConsumptionGetterWorks()
        {
            double fuelConsumption = car.FuelConsumption;
            Assert.That(fuelConsumption, Is.EqualTo(10));
        }
        [Test]
        public void FuelCapacityGetterWorks()
        {
            double fuelCapacity = car.FuelCapacity;
            Assert.That(fuelCapacity, Is.EqualTo(90));
        }
        [Test]
        public void FuelAmountGetterWorks()
        {
            double fuelAmount = car.FuelAmount;
            Assert.That(fuelAmount, Is.EqualTo(0.0));
        }
        [Test]
        [TestCase(6.7)]
        public void RefuelWorks(double amount)
        {
            car.Refuel(amount);
            Assert.That(car.FuelAmount, Is.EqualTo(6.7));
        }
        [Test]
        [TestCase(100)]
        public void RefuelWorksWhenItIsOverloaded(double amount)
        {
            car.Refuel(amount);
            Assert.That(car.FuelAmount, Is.EqualTo(90));
        }
        [Test]
        [TestCase(0)]
        [TestCase(-23)]
        public void RefuelThrowsExceptionIfZeroOrNegative(double amount)
        {
            Assert.That(()=>car.Refuel(amount), Throws.ArgumentException);
        }
        [Test]
        public void DriveWorksCorrectly()
        {
            car.Refuel(10);
            car.Drive(50);
            Assert.That(car.FuelAmount, Is.EqualTo(5));
        }
        [Test]
        public void DriveThrowsExceptionWhenTooBig()
        {
            car.Refuel(10);
            Assert.That(() => car.Drive(200),Throws.InvalidOperationException);
        }

    }
}