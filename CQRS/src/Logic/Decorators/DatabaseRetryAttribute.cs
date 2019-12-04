using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Decorators
{
    class DatabaseRetryAttribute : Attribute
    {
        public DatabaseRetryAttribute()
        {
        }
    }
}
