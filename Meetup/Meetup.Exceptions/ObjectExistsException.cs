using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Exceptions
{
    public class ObjectExistsException : Exception
    {
        public ObjectExistsException(string objectName) : base($"Object {objectName} exists") 
        {
        }
    }
}
