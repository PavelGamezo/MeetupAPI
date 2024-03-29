﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Domain.Exceptions
{
    public class ObjectNotFoundException : Exception
    {
        public ObjectNotFoundException(object objectName) : base($"Object {objectName} not found")
        {
        }
    }
}
