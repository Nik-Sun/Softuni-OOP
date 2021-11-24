using System;
using NUnit.Framework;
[TestFixture]
public class HeroRepositoryTests
{
    [TestCase("Pesho",1)]
    [TestCase("Kiro",-1)]
    public void HeroCtorShouldSetValuesCorrectly(string name,int level)
    {
        //Arrange && Act
        Hero hero = new Hero(name,level);

        //Assert
        Assert.AreEqual(name, hero.Name);
        Assert.AreEqual(level, hero.Level);
    }
    [Test]
    public void CreateShouldThrowExceptionWhenCalledWithNull()
    {
        //Arrange
        Hero hero = null;
        HeroRepository heroRepository = new HeroRepository();

        //Act && Assert
        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(hero));
    }
    [Test]
    public void CreateShouldThrowExceptionWhenCalledWithExisitingHero()
    {
        //Arrange
        Hero hero = new Hero("Pesho",12);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero);

        //Act && Assert
        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero), "Hero with name Pesho already exists");
    }
    [Test]
    public void CreateShouldReturnCorrectData()
    {
        //Arrange
        Hero hero = new Hero("Pesho", 12);
        HeroRepository heroRepository = new HeroRepository();

        //Act
        string expectedMessage = "Successfully added hero Pesho with level 12";
        string returnMessage = heroRepository.Create(hero);


        //Assert
        Assert.AreEqual(expectedMessage,returnMessage);
    }
    [TestCase("")]
    [TestCase(null)]
    public void RemoveShoudlThrowExceptionWhenCalledWithEmptyOrNullName(string name)
    {
        //Arrange
        HeroRepository heroRepository = new HeroRepository();

        //Act && Assert
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(name),"Name cannot be null");
    }
    [Test]
    public void RemoveShouldReturnTrueForExistingHero()
    {
        //Arrange
        Hero hero = new Hero("Pesho",12);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero);

        //Act
        bool actual = heroRepository.Remove("Pesho");

        //Assert
        Assert.IsTrue(actual);
    }
    [Test]
    public void RemoveShouldReturnFalseForNonExistingHero()
    {
        //Arrange
        Hero hero = new Hero("Pesho", 12);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero);

        //Act
        bool actual = heroRepository.Remove("Ivan");

        //Assert
        Assert.IsFalse(actual);
    }
    [Test]
    public void GetHeroWithHighestLevelShouldReturnHighestLevelHero()
    {
        //Arrange
        Hero hero = new Hero("Pesho", 1);
        Hero hero1 = new Hero("Ivan", 2);
        Hero heroHighest = new Hero("Gosho", 3);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero);
        heroRepository.Create(heroHighest);
        heroRepository.Create(hero1);

        //Act
        Hero returned = heroRepository.GetHeroWithHighestLevel();

        //Assert
        Assert.AreEqual(heroHighest, returned);
    }
    [Test]
    public void GetHeroWithHighestLevelShouldReturnTheOnlyHeroOnRepositoryWithOneHero()
    {
        //Arrange
        Hero hero = new Hero("Pesho", 1);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero);
       
        //Act
        Hero returned = heroRepository.GetHeroWithHighestLevel();

        //Assert
        Assert.AreEqual(hero, returned);
    }
    [Test]
    public void GetHeroShouldReturnTheHeroWithGivenName()
    {
        //Arrange
        Hero hero = new Hero("Pesho", 2);
        Hero hero1 = new Hero("Ivan", 2);
        Hero heroExpected = new Hero("Gosho", 2);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero);
        heroRepository.Create(hero1);
        heroRepository.Create(heroExpected);

        //Act
        Hero returned = heroRepository.GetHero("Gosho");

        //Assert
        Assert.AreEqual(heroExpected, returned);
    }
    [Test]
    public void GetHeroShouldReturnNullWhenGivenNameDoesNotExist()
    {
        //Arrange
        Hero hero = new Hero("Pesho", 2);
        Hero hero1 = new Hero("Ivan", 2);
        Hero heroExpected = new Hero("Gosho", 2);
        HeroRepository heroRepository = new HeroRepository();
        heroRepository.Create(hero);

        //Act
        Hero returned = heroRepository.GetHero("Misho");

        //Assert
        Assert.IsNull(returned);
    }
}