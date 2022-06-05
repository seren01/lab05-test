using System;
using System.Collections.Generic;
using static System.Console;
using Packt.Shared;
using static System.Console;
using System.Threading;

namespace Packt.Shared
{
    public class Person : IComparable<Person>
    {
        // поля
        public string Name;
        public DateTime DateOfBirth;
        public List<Person> Children = new List<Person>();
        // методы
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
        }

        // статический метод «размножения»
        public static Person Procreate(Person p1, Person p2)
        {
            var baby = new Person
            {
            Name = $"Baby of {p1.Name} and {p2.Name}"
            };
            p1.Children.Add(baby);
            p2.Children.Add(baby);
            return baby;
        }

        // метод «размножения» экземпляра класса
        public Person ProcreateWith(Person partner)
        {
            return Procreate(this, partner);
        }

        var gu = new Person { Name = "Gu Yun" };
        var chang = new Person { Name = "Chang Geng" };
        var shen = new Person { Name = "Shen Yi" };
        
        // вызов метода экземпляра
        var baby1 = chang.ProcreateWith(gu);
        
        // вызов статического метода
        var baby2 = Person.Procreate(gu, shen);
        WriteLine($"{gu.Name} has {gu.Children.Count} children.");
        WriteLine($"{chang.Name} has {chang.Children.Count} children.");
        WriteLine($"{shen.Name} has {shen.Children.Count} children.");
        WriteLine(
            format: "{0}'s first child is named \"{1}\".",
            arg0: gu.Name,
            arg1: gu.Children[0].Name);

        // операция «размножения»
        public static Person operator *(Person p1, Person p2)
        {
            return Person.Procreate(p1, p2);
        }

        // вызов статического метода
        var baby2 = Person.Procreate(gu, shen);

        // вызов операции
        var baby3 = gu * chang;

        // метод с локальной функцией
        public int Factorial(int number)
        {
            if (number < 0)
            {
            throw new ArgumentException(
            $"{nameof(number)} cannot be less than zero.");
            }
            return localFactorial(number);

            int localFactorial(int localNumber) // локальная функция
            {
                if (localNumber < 1) return 1;
                return localNumber * localFactorial(localNumber – 1);
            }
        }

        // создание экземпляра делегата, который указывает на метод
        var d = new DelegateWithMatchingSignature(p1.MethodIWantToCall);
        // вызов делегата, который вызывает метод
        int answer2 = d("Frog");

        // событие
        public event EventHandler Shout;

        // поле
        public int AngerLevel;

        // метод
        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                // если что-то случается...
                if (Shout != null)
                {
                    // ...то вызывается делегат
                    Shout(this, EventArgs.Empty);
                }
            }
        }

        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);
        }

        public int Compare(Person x, Person y)
        {
            // сравнение длины имени...
            int result = x.Name.Length
            .CompareTo(y.Name.Length);
            /// ...если равны...
            if (result == 0)
            {
                // ... затем сравниваем по именам...
                return x.Name.CompareTo(y.Name);
            }
            else
            {
                // ... в противном случае сравниваем по длине
                return result;
            }
        }

        // переопределенные методы
        public override string ToString()
        {
            return $"{Name} is a {base.ToString()}";
        }
    }

    public static class Squarer
    {
        public static double Square<T>(T input)
        where T : IConvertible
        {
            // конвертирует, используя текущие настройки
            double d = input.ToDouble(
            Thread.CurrentThread.CurrentCulture);
            return d * d;
        }
    }
}
