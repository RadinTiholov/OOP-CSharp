using FightingArena;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void CtorWorksAsItShould()
        {
            List<Warrior> list = new List<Warrior>();
            Assert.That(list, Is.EqualTo(arena.Warriors));
        }
        [Test]
        public void WarriorsGetterWorks()
        {
            Warrior warrior = new Warrior("Pesho", 40, 100);
            List<Warrior> list = new List<Warrior>();
            list.Add(warrior);

            arena.Enroll(warrior);
            Assert.That(list, Is.EqualTo(arena.Warriors));
        }
        [Test]
        public void CountGetterWorks()
        {
            Warrior warrior = new Warrior("Pesho", 40, 100);
            Warrior warrior1 = new Warrior("Pesho123", 420, 1010);
            arena.Enroll(warrior);
            arena.Enroll(warrior1);

            Assert.That(arena.Count, Is.EqualTo(2));
        }
        [Test]
        public void EnrollWorksCorrectly()
        {
            Warrior warrior = new Warrior("Pesho", 40, 100);
            Warrior warrior1 = new Warrior("Pesho123", 420, 1010);
            Warrior warrior2 = new Warrior("Pesqqho123", 60, 110);
            arena.Enroll(warrior);
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);

            Assert.That(arena.Count, Is.EqualTo(3));
        }
        [Test]
        public void EnrollThrowExceptionWhenInvalidData()
        {
            Warrior warrior = new Warrior("Pesho", 40, 100);
            Warrior warrior1 = new Warrior("Pesho", 420, 1010);
            arena.Enroll(warrior);

            Assert.That(() => arena.Enroll(warrior1), Throws.InvalidOperationException);
        }
        [Test]
        public void FightWorksCorrectly()
        {
            Warrior warrior = new Warrior("Pesho", 40, 100);
            Warrior warrior1 = new Warrior("Misho", 60, 80);
            arena.Enroll(warrior);
            arena.Enroll(warrior1);

            arena.Fight("Pesho", "Misho");
            List<Warrior> warriors = (List<Warrior>)arena.Warriors;
            Assert.That(warriors[0].HP, Is.EqualTo(40));
            Assert.That(warriors[1].HP, Is.EqualTo(40));
        }
        [Test]
        [TestCase("Pesho",null)]
        [TestCase(null,"Misho")]
        public void FightThrowsExceptionWhenInvalidData(string firstName, string secondName)
        {
            Assert.That(() => arena.Fight(firstName, secondName), Throws.InvalidOperationException);
        }
        [Test]
        [TestCase("Pesho", "Misho23")]
        [TestCase("Pesho69", "Misho")]
        public void FightThrowsExceptionWhenArenaDoesntContainsFighters(string firstName, string secondName)
        {
            Warrior warrior = new Warrior("Pesho", 40, 100);
            Warrior warrior1 = new Warrior("Misho", 60, 80);
            arena.Enroll(warrior);
            arena.Enroll(warrior1);
            Assert.That(() => arena.Fight(firstName, secondName), Throws.Exception);
        }

    }
}
