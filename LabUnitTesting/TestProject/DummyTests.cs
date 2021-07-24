using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private Axe axe;
        [SetUp]
        public void Initialize()
        {
            dummy = new Dummy(17, 2);
            axe = new Axe(5, 10);
        }
        [Test]
        public void DummyLosesHealthIfAttacked() 
        {
            axe.Attack(dummy);

            Assert.That(dummy.Health, Is.EqualTo(12), "Dummy does't loses health if it is attacked.");
        }
        [Test]
        public void DeadDummyThrowsExeption()
        {
            AttackDummyFourTimes();

            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."), "Dead dummy doesn't trows exeption.");
        }
        [Test]
        public void DeadDummyCangiveXP()
        {
            AttackDummyFourTimes();

            Assert.That(() => dummy.GiveExperience(), Is.EqualTo(2), "Dead dummy can't give XP.");
        }
        [Test]
        public void AliveDummyCantGiveXp() 
        {
            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."), "Alive dummy can give XP.");
        }
        public void AttackDummyFourTimes() 
        {
            axe.Attack(dummy);
            axe.Attack(dummy);
            axe.Attack(dummy);
            axe.Attack(dummy);
        }
    }
}
