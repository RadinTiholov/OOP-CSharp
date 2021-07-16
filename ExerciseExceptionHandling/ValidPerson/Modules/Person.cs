using System;
using System.Collections.Generic;
using System.Text;

namespace ValidPerson.Modules
{
    public class Person
    {
        public Person(string firstName, string lastname, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastname;
            this.Age = age;
        }
        private string firstName;
        private string lastName;
        private int age;

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new FormatException("The first name was too short or too long.");
                }
                firstName = value;
            }
        }
        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new FormatException("The last name was too short or too long.");
                }
                lastName = value;
            }
        }
        public int Age
        {
            get { return age; }
            private set
            {
                if (value < 1 || value > 130)
                {
                    throw new ArgumentException("Age can't br negative or greather than 130 years.");
                }
                age = value;
            }
        }

    }
}
