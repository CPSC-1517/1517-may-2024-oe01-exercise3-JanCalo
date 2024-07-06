
using BookSystem;
using FluentAssertions;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
namespace BooksUnitTestEx1
{
    public class Book_should
    {
        #region Constructor
        [Fact]
        public void Create_Book_WithOut_Reviews_Collection()
        {
            // Arrange
            string isbn = "111-0-7653-2222-4";
            string title = "The Book";
            int publishYear = 2023;
            Author author = new Author("John", "Doe", "http://www.johndoe.com", "Edmonton", "Canada");
            GenreType genre = GenreType.Fiction;
            // Act
            Book actual = new Book(isbn, title, publishYear, author, genre);
            // Assert
            actual.ISBN.Should().Be(isbn);
            actual.Title.Should().Be(title);
            actual.PublishYear.Should().Be(publishYear);
            actual.Author.Should().Be(author);
            actual.Genre.Should().Be(genre);
            actual.Reviews.Should().BeEmpty();
        }
        [Fact]
        public void Create_Book_With_Reviews_Collection()
        {
            // Arrange
            string isbn = "111-0-7653-2222-4";
            string title = "The Notebook";
            int publishYear = 2023;
            Author author = new Author("John", "Doe", "http://www.johndoe.com", "Edmonton", "Canada");
            GenreType genre = GenreType.Fiction;
            Reviewer reviewer = new Reviewer("Jane", "Smith", "jane@smith.com", "Book Club");
            // Act
            Book actual = new Book(isbn, title, publishYear, author, genre);
            actual.Reviews.Add(new Review(isbn, reviewer, RatingType.MustHave, "Excellent book!"));
            actual.Reviews.Add(new Review(isbn, new Reviewer("Bob", "Jones", "bob@jones.com", "Readers Club"), RatingType.Buy, "Good read."));
            actual.Reviews.Add(new Review(isbn, new Reviewer("Alice", "Johnson", "alice@johnson.com", "Book Lovers"), RatingType.Pass, "Not bad."));
            // Assert
            actual.Reviews.Count.Should().Be(3);
        }
        [Theory]
        [InlineData(null, "The Notebook", 2024, "John", "Doe", "http://www.johndoe.com", "Edmonton", "Canada")]
        [InlineData("111-0-7653-2222-4", null, 2024, "John", "Doe", "http://www.johndoe.com", "Edmonton", "Canada")]
        [InlineData("111-0-7653-2222-4", "The Notebook", 2024, null, "Doe", "http://www.johndoe.com", "Edmonton", "Canada")]
        public void Throw_Exception_For_Missing_Data(string isbn, string title, int publishYear, string firstName, string lastName, string contactUrl, string city, string country)
        {
            // Act
            Action action = () => new Book(isbn, title, publishYear, new Author(firstName, lastName, contactUrl, city, country), GenreType.Fiction);
            // Assert
            action.Should().Throw<ArgumentException>().WithMessage("*is required*"); ;
        }
        #endregion

        #region Properties
        [Fact]
        public void Allow_Change_To_PublicationYear()
        {
            // Arrange
            string isbn = "111-0-7653-2222-4";
            string title = "The Book";
            int publishYear = 2023;
            Author author = new Author("John", "Doe", "http://www.johndoe.com", "Edmonton", "Canada");
            GenreType genre = GenreType.Fiction;
            Book actual = new Book(isbn, title, publishYear, author, genre);
            int newPublishYear = 2024;
            // Act
            actual.PublishYear = newPublishYear;
            // Assert
            actual.PublishYear.Should().Be(newPublishYear);
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(999)]
        [InlineData(10000)]
        [InlineData(10)]
        public void Throw_FormatException_For_Invalid_PublishYear(int invalidYear)
        {
            // Arrange
            string isbn = "111-0-7653-2222-4";
            string title = "The Notebook";
            int publishYear = 2023;
            Author author = new Author("John", "Doe", "http://www.johndoe.com", "Edmonton", "Canada");
            GenreType genre = GenreType.Fiction;
            Book book = new Book(isbn, title, publishYear, author, genre);
            // Act
            Action action = () => book.PublishYear = invalidYear;
            // Assert
            action.Should().Throw<FormatException>().WithMessage("PublishYear must be in yyyy format.");
        }
        #endregion
        #region Methods
        #endregion
    }
}