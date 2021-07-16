using System;
using System.Collections.Generic;
using System.Text;

namespace ValidPerson.Exceptions
{
    public class InvalidPersonNameException:Exception
    {
        public override string Message => "The person name is invalid!";
    }
}
