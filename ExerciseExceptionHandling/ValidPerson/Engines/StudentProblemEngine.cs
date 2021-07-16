using System;
using System.Collections.Generic;
using System.Text;
using ValidPerson.Engines;
using ValidPerson.Interfaces;
using ValidPerson.Exceptions;
using ValidPerson.Modules;

namespace ValidPerson.Engines
{
    class StudentProblemEngine : IEngine
    {
        public void Run()
        {
            try
            {
                Student gosho = new Student("gin40", "gosho@trepacha.kur");
            }
            catch (InvalidPersonNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
