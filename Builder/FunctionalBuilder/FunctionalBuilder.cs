namespace Builder.FunctionalBuilder
{
    public class Person
    {
        public string Name, Position;
        public int Age;
    }

    public abstract class FunctionalBuilder<TSubject, TSelf> where TSelf : FunctionalBuilder<TSubject, TSelf>
        where TSubject : new()
    {
        public readonly List<Func<TSubject, TSubject>> actions = new();

        public TSelf Do(Action<TSubject> action) => AddAction(action);

        public TSubject Build() => actions.Aggregate(new TSubject(), (p, f) => f(p));

        private TSelf AddAction(Action<TSubject> action)
        {
            actions.Add(
                p =>
                {
                    action(p);
                    return p;
                });
            return (TSelf) this;
        }
    }

    public sealed class PersonBuilder : FunctionalBuilder<Person, PersonBuilder>
    {
        public PersonBuilder Called(string name) => Do(p => p.Name = name);

        public PersonBuilder Aged(int age) => Do(p => p.Age = age);
    }

    /*public sealed class PersonBuilder
    {
        public readonly List<Func<Person, Person>> actions = new List<Func<Person, Person>>();

        public PersonBuilder Called(string name) => Do(p => p.Name = name);

        public PersonBuilder Do(Action<Person> action) => AddAction(action);

        public Person Build() => actions.Aggregate(new Person(), (p, f) => f(p));

        private PersonBuilder AddAction(Action<Person> action)
        {
            actions.Add(p =>
            {
                action(p);
                return p;
            });
            return this;
        }
    }*/

    public static class PersonBuilderExtensions
    {
        public static PersonBuilder WorksAs(this PersonBuilder builder, string position) => 
            builder.Do(p => p.Position = position);

        public static PersonBuilder DoubleAge(this PersonBuilder builder) => 
            builder.Do(p => p.Age *= 2);
    }

    public class FunctionalBuilderTest
    {
        public static void Run()
        {
            var person = new PersonBuilder()
                .Called("Sarah")
                .WorksAs("Developer")
                .Aged(10)
                .DoubleAge()
                .Build();
        }
    }
}
