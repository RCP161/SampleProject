using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Base.Core
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class IgnoreOnStateAttribute : Attribute
    {
        public IgnoreOnStateAttribute()
        {

        }
    }
}
