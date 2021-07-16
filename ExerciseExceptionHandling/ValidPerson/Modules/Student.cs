using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValidPerson.Exceptions;

namespace ValidPerson.Modules
{
    public class Student
    {
        public Student(string firstName, string email)
        {
            this.FirstName = firstName;
            this.Email = email;
        }
        private string firstName;
        private string email;
        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new FormatException("The name was too short or too long.");
                }
                if (value.Any(char.IsDigit))
                {
                    throw new InvalidPersonNameException();
                }
                firstName = value;
            }
        }
        public string Email
        {
            get { return email; }
            private set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new FormatException("The email is wrong");
                }
                email = value;
            }
        }
    }
}
