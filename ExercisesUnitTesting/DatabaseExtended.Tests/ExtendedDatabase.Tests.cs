using NUnit.Framework;
using System.Linq;
using ExtendedDatabase;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;
        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void ConstructorWorksAsItShould()
        {
            Person person1 = new Person(121, "Pesho");
            Person person2 = new Person(121123, "PeshoD");
            Person person3 = new Person(121112323, "PeshoDC");
            database = new ExtendedDatabase.ExtendedDatabase(person1, person2, person3);
            Assert.That(database.Count, Is.EqualTo(3));
            Person person = database.FindById(121);
            Assert.That(person.UserName, Is.EqualTo("Pesho"));
        }
        [Test]
        public void ThrowsExceptionIfItIsTooBig()
        {
            Person person1 = new Person(121, "Peshocc");
            Person person2 = new Person(121123, "PeshoD");
            Person person3 = new Person(121112323, "PeshoDC");
            Person person4 = new Person(12143, "Peshoasd");
            Person person5 = new Person(121234123, "PeshoDasd");
            Person person6 = new Person(121122123, "PeshoDaaasdC");
            Person person7 = new Person(112321, "Pesfgho");
            Person person8 = new Person(45121, "PeshjhhoD");
            Person person9 = new Person(44121112323, "PeskljkhoDC");
            Person person10 = new Person(44512143, "Pesholakaasd");
            Person person11 = new Person(66121234123, "PesghjhoDasd");
            Person person12 = new Person(5121122323, "PeshfghfgoDasdC");
            Person person13 = new Person(177721, "Peasdssho");
            Person person14 = new Person(45645121123, "PeccshoD");
            Person person15 = new Person(7861211123, "PeshoDasdC");
            Person person16 = new Person(696912143, "Pesho;axxsd");
            Person person17 = new Person(16921234123, "PeszzxhoDasd");
            Assert.That(() => database = new ExtendedDatabase.ExtendedDatabase(person1, person2, person3, person4, person5, person6, person7, person8, person9, person10, person11, person12, person13, person14, person15, person16, person17), Throws.ArgumentException);
        }
        [Test]
        public void AddsElementAtTheNextCell()
        {
            Person person14 = new Person(45645121123, "PeccshoD");
            database.Add(person14);
            Person person = database.FindById(45645121123);

            Assert.That(database.Count, Is.EqualTo(1));
            Assert.That(person.UserName, Is.EqualTo("PeccshoD"));
        }
        [Test]
        public void ThrowsExceptionIfAddSeventeenthElement()
        {
            Person person14 = new Person(45645121123, "PeccshoD");
            AddSixteenElements();
            Assert.That(() => database.Add(person14), Throws.InvalidOperationException);
        }
        [Test]
        public void RemoveElementFromLastPosition()
        {
            AddSixteenElements();
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(15));
        }
        [Test]
        public void ThrowsExceptionIfRemoveFromEmpty()
        {
            Assert.That(() => database.Remove(), Throws.InvalidOperationException);
        }
        [Test]
        public void CountReturnsZeroWhenIsEmpty()
        {
            Assert.That(database.Count, Is.EqualTo(0));
        }
        [Test]
        public void ThrowsExceptionIfPersonWithSameNameExist()
        {
            Person person = new Person(111, $"Pesho");
            Person person1 = new Person(11121, $"Pesho");
            database.Add(person);
            Assert.That(() => database.Add(person1), Throws.InvalidOperationException);

        }
        [Test]
        public void ThrowsExceptionIfPersonWithSameIDExist()
        {
            Person person = new Person(111, $"Pesho");
            Person person1 = new Person(111, $"Pesho123");
            database.Add(person);
            Assert.That(() => database.Add(person1), Throws.InvalidOperationException);

        }
        [Test]
        public void ThrowsExceptionThereIsNoUserWithThisName()
        {
            Assert.That(() => database.FindByUsername("Aihan"), Throws.InvalidOperationException);
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ThrowsExceptionIfItIsNullOrEmpty(string username)
        {
            Assert.That(() => database.FindByUsername(username), Throws.ArgumentNullException);
            Assert.That(() => database.FindByUsername(username), Throws.ArgumentNullException);
        }
        [Test]
        public void ThrowsExceptionIfItIsCaseSensitive()
        {
            Person person1 = new Person(111, $"Pesho123");
            database.Add(person1);
            Assert.That(() => database.FindByUsername("pesho123"), Throws.InvalidOperationException);
        }
        [Test]
        public void FindByNameReturnsTheCorectResult()
        {
            Person person1 = new Person(111, $"Pesho123");
            database.Add(person1);
            Person person = database.FindByUsername("Pesho123");
            Assert.That(person, Is.EqualTo(person1));
        }
        [Test]
        public void ThrowsExceptionThereIsNoUserWithThisID()
        {
            Assert.That(() => database.FindById(111), Throws.InvalidOperationException);
        }
        [Test]
        [TestCase(-12)]
        [TestCase(-3232)]
        //warning
        public void ThrowsExceptionThereIsNegativeID(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id));
        }
        [Test]
        public void FindByIdReturnsTheCorectResult()
        {
            Person person1 = new Person(111, $"Pesho123");
            database.Add(person1);
            Person person = database.FindById(111);
            Assert.That(person, Is.EqualTo(person1));
        }
        public void AddSixteenElements()
        {
            for (int i = 0; i < 15; i++)
            {
                Person person = new Person(121+i, $"Pesho{i}");
                database.Add(person);
            }
            Person person2 = new Person(111, $"PeshoP");
            database.Add(person2);
        }
    }
}