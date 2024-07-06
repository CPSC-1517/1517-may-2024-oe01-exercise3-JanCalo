using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookSystem
{
    public class Review
    {
        #region Data Members
        private string _author;
        private string _title;
        private string _isbn;
        private string _comment;
        private string _reviewer;
        #endregion

        #region Properties
        public string Author
        {
            get { return _author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Author is required.");
                }
                _author = value.Trim();
            }
        }
        public string Title
        {
            get { return _title; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is required.");
                }
                _title = value.Trim();
            }
        }
        public string ISBN
        {
            get { return _isbn; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("ISBN is required");
                }
                _isbn = value.Trim();
            }
        }

        public string Reviewer
        {
            get { return _reviewer; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Reviewer is required.");
                }
                _reviewer = value.Trim();
            }
        }

        public RatingType Rating { get; set; }

        public string Comment
        {
            get { return _comment; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Comment is required");
                }
                _comment = value.Trim();
            }
        }
        #endregion

        #region Constructor
        public Review(string isbn, string author, string title, string reviewer, RatingType rating, string comment)
        {
            ISBN = isbn;
            Author = author;
            Title = title;
            Reviewer = reviewer;
            Rating = rating;
            Comment = comment;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{ISBN}, {Title}, {Author}, {Reviewer},{Rating},{Comment}";
        }

        public static Review Parse(string item)
        {
            string[] parts = item.Split(',');

            if (parts.Length != 6)
            {
                throw new FormatException($"String not in the expected format. Missing or excessive value(s): {item}");
            }

            string isbn = parts[0];
            string author = parts[1];
            string title = parts[2];
            string reviewer = parts[3];
            RatingType rating = (RatingType)Enum.Parse(typeof(RatingType), parts[4]);
            string comment = parts[5];

            return new Review(isbn, author, title, reviewer, rating, comment);
        }
        #endregion
    }
}