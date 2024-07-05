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
        private string _isbn;
        private string _comment;
        private Reviewer _reviewer;
        #endregion
        #region Properties
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
        public Reviewer Reviewer
        {
            get { return _reviewer; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Reviewer is required.");
                }
                _reviewer = value;
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
        public Review(string isbn, Reviewer reviewer, RatingType rating, string comment)
        {
            ISBN = isbn;
            Reviewer = reviewer;
            Rating = rating;
            Comment = comment;
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"{ISBN},{Reviewer},{Rating},{Comment}";
        }
        #endregion
    }
}
