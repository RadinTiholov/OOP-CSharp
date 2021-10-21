using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
        }

        [Test]
        public void CtorWorksFine()
        {
            var secondVault = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };
            Assert.That(bankVault.VaultCells, Is.EqualTo(secondVault));
        }
        [Test]
        public void VaultGetterWorksFine()
        {
            Item item = new Item("Gosho", "Aadd2");
            var secondVault = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", item},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };
            bankVault.AddItem("A2", item);
            Assert.That(bankVault.VaultCells, Is.EqualTo(secondVault));
        }
        [Test]
        public void AdditemThrowsExceptionWhenDoesntExist()
        {
            Item item = new Item("Gosho", "Aadd2");
            Assert.That(()=>bankVault.AddItem("Fs2", item), Throws.ArgumentException);
        }
        [Test]
        public void AdditemThrowsExceptionWhenItsAlreadyTaken()
        {
            Item item = new Item("Gosho", "Aadd2");
            Item item2 = new Item("GoshoAA", "Aadd2ss");
            bankVault.AddItem("A1", item);
            Assert.That(() => bankVault.AddItem("A1", item2), Throws.ArgumentException);
        }
        [Test]
        public void AdditemThrowsExceptionWhenItsAlreadyExist()
        {
            Item item = new Item("Gosho", "111");
            Item item2 = new Item("GoshoAA", "111");
            bankVault.AddItem("A1", item);
            Assert.That(() => bankVault.AddItem("A2", item2), Throws.InvalidOperationException);
        }
        [Test]
        public void AdditemWorksFine()
        {
            Item item = new Item("Gosho", "111");
            var secondVault = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", item},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };
            string mess = bankVault.AddItem("A2", item);
            string expectedMess = $"Item:{item.ItemId} saved successfully!";
            Assert.That(mess, Is.EqualTo(expectedMess));
            Assert.That(bankVault.VaultCells, Is.EqualTo(secondVault));
        }
        [Test]
        public void RemoveItemThrowsExceptionWhenDoesntExist()
        {
            Item item = new Item("Gosho", "Aadd2");
            Assert.That(() => bankVault.RemoveItem("Fs2", item), Throws.ArgumentException);
        }
        [Test]
        public void RemoveItemThrowsExceptionWhenItemDoesntExists()
        {
            Item item = new Item("Gosho", "Aadd2");
            Assert.That(() => bankVault.RemoveItem("A2", item), Throws.ArgumentException);
        }
        [Test]
        public void RemoveItemTWorksFine()
        {
            Item item = new Item("Gosho", "Aadd2");
            bankVault.AddItem("A2", item);
            string message = bankVault.RemoveItem("A2", item);
            Assert.That(bankVault.VaultCells["A2"], Is.EqualTo(null));
            Assert.That(message, Is.EqualTo($"Remove item:{item.ItemId} successfully!"));
        }
    }
}