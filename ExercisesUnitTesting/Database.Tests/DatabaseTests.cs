using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
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
            database = new ExtendedDatabase.ExtendedDatabase(1, 2, 3);
            int[] firstArrayForComparison = new int[] {1,2,3 };
            int[] secondArrayForcomparison = database.Fetch();
            Assert.That(firstArrayForComparison, Is.EqualTo(secondArrayForcomparison));
        }
        [Test]
        public void ThrowsExceptionIfItIsTooBig()
        {
            Assert.That(() => database = new ExtendedDatabase.ExtendedDatabase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12,13,14,15,16,17), Throws.InvalidOperationException);
        }
        [Test]
        public void AddsElementAtTheNextCell()
        {
            database.Add(1);
            int[] fethcedArr = database.Fetch();
            Assert.That(database.Count, Is.EqualTo(1));
            Assert.That(fethcedArr[0], Is.EqualTo(1));
        }
        [Test]
        public void ThrowsExceptionIfAddSeventeenthElement()
        {
            AddSeventeenElements();
            Assert.That(() => database.Add(2), Throws.InvalidOperationException);
        }
        [Test]
        public void RemoveElementFromLastPosition()
        {
            AddSeventeenElements();
            database.Remove();
            int[] fethcedArr = database.Fetch();
            Assert.That(database.Count, Is.EqualTo(15));
            Assert.That(fethcedArr[fethcedArr.Length-1], Is.EqualTo(5));
        }
        [Test]
        public void ThrwosExceptionIfRemoveFromEmpty()
        {
            Assert.That(()=> database.Remove(), Throws.InvalidOperationException);
        }
        [Test]
        public void CountReturnsZeroWhenIsEmpty()
        {
            Assert.That(database.Count, Is.EqualTo(0));
        }
        [Test]
        public void FetchMethodRetursIntArrayNotReference()
        {
            AddSeventeenElements();
            var firstCopy = database.Fetch();
            database.Remove();
            database.Remove();
            database.Remove();
            var secondCopy = database.Fetch();
            Assert.That(firstCopy, Is.Not.EqualTo(secondCopy));
        }
        public void AddSeventeenElements() 
        {
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(1);
            database.Add(5);
            database.Add(8);
        }
    }
}