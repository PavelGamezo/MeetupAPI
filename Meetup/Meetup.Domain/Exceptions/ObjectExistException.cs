using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Domain.Exceptions
{
    public class ObjectExistException : Exception
    {
        public ObjectExistException(string objectName) : base($"Object {objectName} exists")
        {
        }
    }
}
