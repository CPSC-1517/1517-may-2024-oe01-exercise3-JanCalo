using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookSystem
{
    public class Reviewer
    {

        #region Data Members
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _organization;
        #endregion

        #region Properties
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name is required.");
                }
                _firstName = value.Trim();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name is required.");
                }
                _lastName = value.Trim();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, pattern))
                {
                    throw new ArgumentException("Email is required acceptable email address pattern.");
                }
                _email = value.Trim();
            }
        }

        public string Organization
        {
            get { return _organization; }
            set
            {
              _organization = value;
            }
        }

        public string ReviewerName => $"{LastName}, {FirstName}";
        #endregion

        #region Constructor
        public Reviewer(string firstName, string lastName, string email, string organization = "")
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Organization = organization;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{FirstName},{LastName},{Email},{Organization}";
        }
        #endregion
    }
}
