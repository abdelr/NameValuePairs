using System;

namespace NameValuePairs.Exceptions
{
    /// <summary>
    /// Exception to represent a non-alphanumeric value
    /// </summary>
    public class ValueException : Exception
    {
        public ValueException() : base("Error on Value field. Check that you are only using alphanumeric characters") { }
    }
}
