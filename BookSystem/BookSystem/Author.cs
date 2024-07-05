using System.Text.RegularExpressions;

namespace BookSystem
{
    public class Author
    {
        #region Data Members
        private string _firstName;
        private string _lastName;
        private string _contactUrl;
        private string _residentCity;
        private string _residentCountry;
        #endregion

        #region Properties
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                //first name is required
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("FirstName is required.");
                }
                _firstName = value.Trim();
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                //last name is required
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("LastName is required.");
                }
                _lastName = value.Trim();
            }
        }
        public string ContactUrl
        {
            get { return _contactUrl; }
            set
            {
                string pattern = @"^(https?://www\.)?[a-zA-Z0-9]+(\.[a-zA-Z0-9]+)*\.\w{2,}$";
                if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, pattern))
                {
                    throw new ArgumentException("ContactUrl is required to match acceptable URL pattern");
                }
                _contactUrl = value.Trim();
            }
        }

        public string ResidentCity
        {
            get { return _residentCity; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("ResidentCity is required.");
                }
                _residentCity = value.Trim();
            }
        }
        public string ResidentCountry
        {
            get { return _residentCountry; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("ResidentCountry is required");
                }
                _residentCountry = value.Trim();
            }
        }
        public string AuthorName => $"{LastName}, {FirstName}";
        #endregion
        #region Constructor
  
        public Author(string firstName, string lastName, string contactUrl, string residentCity, string residentCountry)
        {
            FirstName = firstName;
            LastName = lastName;
            ContactUrl = contactUrl;
            ResidentCity = residentCity;
            ResidentCountry = residentCountry;
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"{FirstName},{LastName},{ContactUrl},{ResidentCity},{ResidentCountry}";
        }
        #endregion
    }
}
