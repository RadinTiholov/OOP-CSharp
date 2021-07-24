using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestFixture]
    class AxeTests
    {
        private Dummy dummy;
        private Axe axe;
        [SetUp]
        public void Initialize()
        {
            dummy = new Dummy(17, 2);
            axe = new Axe(5, 2);
        }
        [Test]
        public void WeaponLosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(1));
        }
        [Test]
        public void AttackingWithABrokenWeapon() 
        {
            axe.Attack(dummy);
            axe.Attack(dummy);

            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}
