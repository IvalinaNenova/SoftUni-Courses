using System;
using System.Reflection;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    [Test]
    public void CreateMethodShouldThrowExceptionIfHeroIsNull()
    {
        Hero hero = null;
        HeroRepository repository = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() => repository.Create(hero));
    }

    [Test]
    public void CreateMethodShouldThrowExceptionIfHeroAlreadyExists()
    {
        Hero hero = new Hero("John", 100);
        HeroRepository repository = new HeroRepository();
        repository.Create(hero);
        
        Assert.Throws<InvalidOperationException>(() => repository.Create(hero));
    }

    [Test]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase(null)]
    public void RemoveMethodShouldThrowExceptionIfNameIsNullOrWhiteSpace(string name)
    {
        HeroRepository repository = new HeroRepository();
        repository.Create(new Hero("John", 50));
        Assert.Throws<ArgumentNullException>(() => repository.Remove(name));
    }

    [Test]
    public void RemoveMethodShouldRemoveHeroFromRepository()
    {
        HeroRepository repository = new HeroRepository();
        repository.Create(new Hero("John", 50));
        repository.Create(new Hero("Peter", 100));

        bool result = repository.Remove("Peter");

        Assert.IsTrue(result);
        Assert.AreEqual(1, repository.Heroes.Count);
    }

    [Test]
    public void GetHeroWithHighestLevelShouldReturnTheBestHero()
    {
        HeroRepository repository = new HeroRepository();

        Hero hero1 = new Hero("John", 50);
        Hero hero2 = new Hero("Peter", 100);
        Hero hero3 = new Hero("George", 150);

        repository.Create(hero1);
        repository.Create(hero2);
        repository.Create(hero3);

        Hero result = repository.GetHeroWithHighestLevel();

        Assert.AreEqual(hero3, result);
    }

    [Test]
    public void GetHeroMethodShouldReturnTheHeroWithGivenName()
    {
        HeroRepository repository = new HeroRepository();

        Hero hero1 = new Hero("John", 50);
        Hero hero2 = new Hero("Peter", 100);
        Hero hero3 = new Hero("George", 150);

        repository.Create(hero1);
        repository.Create(hero2);
        repository.Create(hero3);

        Hero targetHero = repository.GetHero("Peter");

        Assert.AreEqual(hero2, targetHero);
    }

    [Test]
    public void HeroesPropertyShouldBeReadOnly()
    {
        var type = typeof(HeroRepository);
        PropertyInfo propertyInfo = type.GetProperty("Heroes");

        Assert.That(propertyInfo.CanWrite == false);
    }
}