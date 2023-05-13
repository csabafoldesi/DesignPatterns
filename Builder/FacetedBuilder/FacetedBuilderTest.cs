namespace Builder.FacetedBuilder
{
    public class Person
    {
        // address
        public string StreetAddress, PostCode, City;

        // employment
        public string CompanyName, Position;
        public int AnnualIncome;
    }

    public class PersonBuilder //facade
    {
        // reference!
        protected Person person = new Person();

        public PersonJobBuilder Works => new PersonJobBuilder(person);

        public PersonAddressBuilder Lives => new PersonAddressBuilder(person);

        public static implicit operator Person(PersonBuilder personBuilder)
        {
            return personBuilder.person;
        }
    }

    public class PersonJobBuilder: PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int amount)
        {
            person.AnnualIncome = amount;
            return this;
        }
    }

    public class PersonAddressBuilder: PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }
        
        public PersonAddressBuilder WithPostcode(string postCode)
        {
            person.PostCode = postCode;
            return this;
        }
        
        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }
    }


    public class FacetedBuilderTest
    {
        public static void Run()
        {
            var personBuilder = new PersonBuilder();
            Person person = personBuilder
                .Works.At("Company")
                      .AsA("Engineer")
                      .Earning(20000)
                .Lives.At("123 London Road")
                      .In("London")
                      .WithPostcode("AS1236");

        }
    }
}
