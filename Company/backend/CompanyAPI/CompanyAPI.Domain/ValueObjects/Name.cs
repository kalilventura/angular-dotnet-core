namespace CompanyAPI.Domain.ValueObjects
{
    public class Name
    {
        public Name()
        {

        }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get;   set; }
        public string LastName { get;   set; }

        public string fullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
