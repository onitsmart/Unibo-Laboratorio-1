using System;

namespace Laboratorio1.Tests.Fundamentals.Models
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool AllowedToDrive { get; set; } = true;

        private bool Driving { get; set; }
        private bool Drinking { get; set; }

        public Person()
        {
            Name = string.Empty;
            DateOfBirth = DateTime.Now;
        }

        public Person(string name)
        {
            Name = name;
            DateOfBirth = DateTime.Now;
        }

        /// <summary>
        /// Overloading di un costruttore
        /// <see href="https://learn.microsoft.com/en-us/dotnet/standard/design-guidelines/member-overloading"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        public Person(string name, bool allowedToDrive, DateTime dateOfBirth)
        {
            Name = name;
            AllowedToDrive = allowedToDrive;
            DateOfBirth = dateOfBirth;
        }

        public string Drive()
        {
            var result = string.Empty;

            if (AllowedToDrive)
            {
                Driving = true;
                result = "Driving...";

                if (DateTime.Now.Year - DateOfBirth.Year < 14)
                    result += "\nThe person is too young to drive! What have you done?\nCrashed!";
            }
            else
            {
                result = "Cannot drive";
            }

            return result;
        }

        public void DrinkAlchool()
        {
            Drinking = true;
        }

        public bool IsDriving()
        {
            return Driving;
        }

        public bool IsDrinking()
        {
            return Drinking;
        }
    }
}
