namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        [TestCase("Train",50.00)]
        [TestCase("Phone",122.5)]
        [TestCase("Socks",-0.1)]
        public void PresentCtorShouldSetValuesCorrectly(string name,double magic)
        {
            //Arrange
            Present present = new Present(name,magic);

            //Assert
            Assert.AreEqual(name,present.Name);
            Assert.AreEqual(magic,present.Magic);
        }
        [Test]
        public void CreateShouldThrowExceptionWhenPresentIsNull()
        {
            //Arrange
            Present present = null;
            Bag bag = new Bag();

            //Assert
            Assert.Throws<ArgumentNullException>(() => bag.Create(present), "Present is null");
        }
        [Test]
        public void CreateShouldThrowExceptionWhenAddingExistingPresent()
        {
            //Arrange
            Present present = new Present("Train",50);
            Bag bag = new Bag();
            bag.Create(present);

            //Assert
            Assert.Throws<InvalidOperationException>(() => bag.Create(present), "This present already exists!");
        }
        [Test]
        public void CreateShouldReturnMessageWhenAddingPresent()
        {
            //Arrange
            Present present = new Present("Train", 50);
            Bag bag = new Bag();


            //Assert
            Assert.AreEqual($"Successfully added present { present.Name}.", bag.Create(present));
        }
        [Test]
        public void RemoveShouldReturnTrueWhenSuccsesfullyRemovedPresent()
        {
            //Arrange
            Present present = new Present("Train", 50);
            Bag bag = new Bag();
            bag.Create(present);


            //Assert
            Assert.IsTrue(bag.Remove(present));
        }
        [Test]
        public void RemoveShouldReturnFalseWhenUnsuccsesfull()
        {
            //Arrange
            Present present = new Present("Train", 50);
            Bag bag = new Bag();
           


            //Assert
            Assert.IsFalse(bag.Remove(present));
        }
        [Test]
        public void GetPresentWhitLeastMagicShouldReturnPresentWithTheLeastMagic()
        {
            //Arrange
            Present present = new Present("Train", 50);
            Present present1 = new Present("Phone", 20);
            Present expected= new Present("Socks", 1);
            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(expected);
            bag.Create(present1);



            //Assert
            Assert.AreEqual(expected,bag.GetPresentWithLeastMagic());
        }
        [Test]
        public void GetPresentWhitLeastMagicShouldThrowExceptionOnEmptyBag()
        {
            //Arrange
            
            Bag bag = new Bag();
            

            //Assert
            Assert.Throws<InvalidOperationException>(()=> bag.GetPresentWithLeastMagic());
        }
        [Test]
        public void GetPresentShouldReturnPresentByName()
        {
            //Arrange
            Present present = new Present("Train", 50);
            Present present1 = new Present("Phone", 20);
            Present expected = new Present("Socks", 1);
            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(expected);
            bag.Create(present1);


            //Assert
            Assert.AreEqual(expected, bag.GetPresent("Socks"));
        }
        [Test]
        public void GetPresentShouldReturnNullForNonExistentPresent()
        {
            //Arrange
            Present present = new Present("Train", 50);
            Present present1 = new Present("Phone", 20);
            Present expected = new Present("Socks", 1);
            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(expected);
            bag.Create(present1);


            //Assert
            Assert.IsNull(bag.GetPresent("Fryer"));
        }
        [Test]
        public void GetPresentsShouldReturnAllPresentsAddedAsReadOnlyCollection()
        {
            //Arrange
            Present present = new Present("Train", 50);
            Present present1 = new Present("Phone", 20);
            Present present2 = new Present("Socks", 1);
            Bag bag = new Bag();
            bag.Create(present);
            bag.Create(present2);
            bag.Create(present1);



            //Assert
            Assert.AreEqual(3, bag.GetPresents().Count);
        }
    }
}
