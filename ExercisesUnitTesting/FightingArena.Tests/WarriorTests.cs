using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;
        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Pesho", 20, 100);
        }

        [Test]
        public void CtorWorksCorrectly()
        {
            Assert.That(warrior.Name, Is.EqualTo("Pesho"));
            Assert.That(warrior.Damage, Is.EqualTo(20));
            Assert.That(warrior.HP, Is.EqualTo(100));
        }
        [Test]
        [TestCase("", 12, 100)]
        [TestCase(null, 12, 100)]
        [TestCase("asda", 0, 100)]
        [TestCase("asda", -123, 100)]
        [TestCase("asda", 12, -123)]
        public void CtorThrowsExceptionWhenIncorectDataIsEntered(string name, int damage, int hp)
        {
            Assert.That(() => warrior = new Warrior(name, damage, hp), Throws.ArgumentException);
        }
        [Test]
        public void NameGetterWorksCorrectly()
        {
            string name = warrior.Name;
            Assert.That(name, Is.EqualTo("Pesho"));
        }
        [Test]
        public void DamageGetterWorksCorrectly()
        {
            int damage = warrior.Damage;
            Assert.That(damage, Is.EqualTo(20));
        }
        [Test]
        public void HpGetterWorksCorrectly()
        {
            int hp = warrior.HP;
            Assert.That(hp, Is.EqualTo(100));
        }
        [Test]
        [TestCase(30)]
        [TestCase(10)]
        public void TooLowXPThrowsException(int hp)
        {
            Warrior warrior1 = new Warrior("Aihan", 10, 100);
            warrior = new Warrior("Pesho", 10, hp);
            Assert.That(()=>warrior.Attack(warrior1), Throws.InvalidOperationException);
        }
        [Test]
        [TestCase(30)]
        [TestCase(10)]
        public void TooLowEnemyXPThrowsException(int hp)
        {
            Warrior warrior1 = new Warrior("Aihan", 10, hp);
            Assert.That(() => warrior.Attack(warrior1), Throws.InvalidOperationException);
        }
        [Test]
        public void TooHighEnemyDamageThrowsException()
        {
            Warrior warrior1 = new Warrior("Aihan", 120, 100);
            Assert.That(() => warrior.Attack(warrior1), Throws.InvalidOperationException);
        }
        [Test]
        [TestCase(40, 100)]
        [TestCase(40, 31)]
        public void AttackWorksCorrectly(int damage, int hp)
        {
            Warrior warrior1 = new Warrior("Aihan", damage, hp);
            if (hp == 31)
            {
                warrior = new Warrior("asdasd", 50, 100);
                warrior.Attack(warrior1);
                Assert.That(warrior1.HP, Is.EqualTo(0));
            }
            else
            {
                warrior.Attack(warrior1);
                Assert.That(warrior.HP, Is.EqualTo(60));
                Assert.That(warrior1.HP, Is.EqualTo(80));
            }
        }
    }
}