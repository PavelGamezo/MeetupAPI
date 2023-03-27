using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException(string objName) : base($"Object {objName} not found")
        {
        }
    }
}
