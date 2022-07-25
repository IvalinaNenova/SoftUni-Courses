namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        private Book book = null;
        [SetUp] 
        public void Init()
        {
            book = new Book("Lord of the Rings", "J.R.R.Talkin");
            book.AddFootnote(1, "blah blah");
        }
        [Test]
        public void ConstructorShouldCreateBookWithValidData()
        {
            Assert.IsNotNull(book);
            Assert.AreEqual("Lord of the Rings", this.book.BookName);
            Assert.AreEqual("J.R.R.Talkin", this.book.Author);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void BookNameSetterShouldThrowExceptionIfNameNullOrEmpty(string bookName)
        {
            Assert.Throws<ArgumentException>(() => new Book(bookName, "Douglas Adams"));
        }


        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void AuthorSetterShouldThrowExceptionIfNameNullOrEmpty(string authorName)
        {
            Assert.Throws<ArgumentException>(() => new Book("Alice in Wonderland", authorName));
        }

        [Test]
        public void AddFootnoteMethodShouldThrowExceptionIfDuplicateFootnoteNumber()
        {
            Assert.Throws<InvalidOperationException>(() => book.AddFootnote(1, "someText"));
        }

        [Test]
        public void AddFootnoteMethodShouldIncreaseCountOfFootnotes()
        {
            book.AddFootnote(2, "someText");
            book.AddFootnote(3, "someOtherText");

            Assert.AreEqual(3, book.FootnoteCount);
        }

        [Test]
        public void FindFootnoteMethodShouldThrowExceptionIfFootnoteDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => book.FindFootnote(3));
        }

        [Test]
        public void FindFootnoteMethodShouldReturnInformationAboutFootnote()
        {
            string footnote = book.FindFootnote(1);

            Assert.AreEqual("Footnote #1: blah blah", footnote);
        }

        [Test]
        public void AlterFootnoteMethodShouldThrowExceptionIfFootnoteDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(3, "alteredText"));
        }

        [Test]
        public void AlterFootnoteShouldChangeTextOfExistingFootnote()
        {
            book.AlterFootnote(1, "alteredText");

            Assert.AreEqual("Footnote #1: alteredText", book.FindFootnote(1));
        }
    }
}