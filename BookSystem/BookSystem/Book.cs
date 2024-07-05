using System;
using System.Collections.Generic;
using System.Linq;

namespace BookSystem
{
    public class Book
    {
        #region Data Members
        private string _isbn;
        private string _title;
        private int _publishYear;
        private Author _author;
        #endregion

        #region Properties
        public string ISBN
        {
            get { return _isbn; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("ISBN is required and cannot be null.");
                }
                _isbn = value.Trim();
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title is required and cannot be null.");
                }
                _title = value.Trim();
            }
        }

        public int PublishYear
        {
            get { return _publishYear; }
            set
            {
                if (value <= 1000 || value > 9999)
                {
                    throw new FormatException("PublishYear must be in yyyy format.");
                }
                _publishYear = value;
            }
        }

        public Author Author
        {
            get { return _author; }
            set
            {
                _author = value ?? throw new ArgumentNullException("Author is required.");
            }
        }

        public GenreType Genre { get; set; }

        public List<Review> Reviews { get; set; } = new List<Review>();

        public int TotalReviews => Reviews.Count;
        #endregion

        #region Constructor
        public Book(string isbn, string title, int publishYear, Author author, GenreType genre, List<Review> reviews = null)
        {
            ISBN = isbn;
            Title = title;
            PublishYear = publishYear;
            Author = author;
            Genre = genre;
            if (reviews != null)
            {
                Reviews = reviews;
            }
        }
        #endregion

        #region Methods
        public void AddReview(string isbn, Review review)
        {
            if (isbn == null)
            {
                throw new ArgumentNullException("ISBN required");
            }

            if (review == null)
            {
                throw new ArgumentNullException("Review required");
            }

            if (isbn != ISBN)
            {
                throw new ArgumentException($"Review ISBN does not match the book's ISBN. Review ISBN: {isbn}");
            }

            if (Reviews.Any(r => r.Reviewer.Email == review.Reviewer.Email))
            {
                throw new ArgumentException($"This reviewer ({review.Reviewer.ReviewerName}) has already provided a review for this book.");
            }

            Reviews.Add(review);
        }

        public override string ToString()
        {
            return $"{ISBN},{Title},{PublishYear},{Author.AuthorName},{Genre},{TotalReviews}";
        }
        #endregion
    }
}
