using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Decorators
{
    public class DatabaseRetryAttribute : Attribute
    {
        public DatabaseRetryAttribute()
        {
        }
    }
}
