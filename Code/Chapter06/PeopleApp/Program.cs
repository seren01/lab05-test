using System;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine($"5! is {gu.Factorial(5)}");

            gu.Shout = GuYun_Shout;

            gu.Poke();
            gu.Poke();
            gu.Poke();
            gu.Poke();

            Person[] people =
            {
                new Person { Name = "Simon" },
                new Person { Name = "Jenny" },
                new Person { Name = "Adam" },
                new Person { Name = "Richard" }
            };
            
            WriteLine("Initial list of people:");
            foreach (var person in people)
            {
                WriteLine($"{person.Name}");
            }

            WriteLine("Use Person's IComparable implementation to sort:");
            Array.Sort(people);
            foreach (var person in people)
            {
                WriteLine($"{person.Name}");
            }

            WriteLine("Use PersonComparer's IComparer implementation to sort:");
            Array.Sort(people, new PersonComparer());
            foreach (var person in people)
            {
                WriteLine($"{person.Name}");
            }

            var t1 = new Thing();
            t1.Data = 42;
            WriteLine($"Thing with an integer: {t1.Process(42)}");
            
            var t2 = new Thing();
            t2.Data = "apple";
            WriteLine($"Thing with a string: {t2.Process("apple")}");

            var gt1 = new GenericThing<int>();
            gt1.Data = 42;
            WriteLine($"GenericThing with an integer:
            {gt1.Process(42)}");
            
            var gt2 = new GenericThing<string>();
            gt2.Data = "apple";
            WriteLine($"GenericThing with a string:
            {gt2.Process("apple")}");

            string number1 = "4";
            WriteLine("{0} squared is {1}",
                arg0: number1,
                arg1: Squarer.Square<string>(number1));
            
            byte number2 = 3;
            WriteLine("{0} squared is {1}",
                arg0: number2,
                arg1: Squarer.Square(number2));

            var dv1 = new DisplacementVector(3, 5);
            var dv2 = new DisplacementVector(-2, 7);
            var dv3 = dv1 + dv2;
            WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) =
            ({dv3.X}, {dv3.Y})");

            Employee john = new Employee
            {
                Name = "John Jones",
                DateOfBirth = new DateTime(1990, 7, 28)
            };
            john.WriteToConsole();

            john.EmployeeCode = "JJ001";
            john.HireDate = new DateTime(2014, 11, 23);
            WriteLine($"{john.Name} was hired on
            {john.HireDate:dd/MM/yy}");

            WriteLine(john.ToString());

            Employee aliceInEmployee = new Employee
            { Name = "Alice", EmployeeCode = "AA123" };
            Person aliceInPerson = aliceInEmployee;
            aliceInEmployee.WriteToConsole();
            aliceInPerson.WriteToConsole();
            WriteLine(aliceInEmployee.ToString());
            WriteLine(aliceInPerson.ToString());

            Employee explicitAlice = (Employee)aliceInPerson;

            if (aliceInPerson is Employee)
            {
                WriteLine($"{nameof(aliceInPerson)} IS an Employee");
                Employee explicitAlice = (Employee)aliceInPerson;
                // действия с explicitAlice
            }

            if (aliceAsEmployee != null)
            {
                WriteLine($"{nameof(aliceInPerson)} AS an Employee");
                // действия с aliceAsEmployee
            }

            try
            {
                e1.TimeTravel(new DateTime(1999, 12, 31));
                e1.TimeTravel(new DateTime(1950, 12, 25));
            }
            catch (PersonException ex)
            {
                WriteLine(ex.Message);
            }

            string email1 = "pamela@test.com";
            string email2 = "ian&test.com";

            WriteLine(
                "{0} is a valid e-mail address: {1}",
                arg0: email1,
                arg1: StringExtensions.IsValidEmail(email1));
            
            WriteLine(
                "{0} is a valid e-mail address: {1}",
                arg0: email2,
                arg1: StringExtensions.IsValidEmail(email2)); 

            WriteLine(
                "{0} is a valid e-mail address: {1}",
                arg0: email1,
                arg1: email1.IsValidEmail());

            WriteLine(
                "{0} is a valid e-mail address: {1}",
                arg0: email2,
                arg1: email2.IsValidEmail());
        }

        private static void Harry_Shout(object sender, EventArgs e)
        {
            Person p = (Person)sender;
            WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
        }

        public void TimeTravel(DateTime when)
            {
                if (when <= DateOfBirth)
                {
                    throw new PersonException("If you travel back in time to a date earlier
                    than your own birth then the universe will explode!");
                }
                else
                {
                    WriteLine($"Welcome to {when:yyyy}!");
                }
            }
    }
}
