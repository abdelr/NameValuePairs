using System;

namespace NameValuePairs.Exceptions
{
    /// <summary>
    /// Exception to represent a non-alphanumeric name
    /// </summary>
    public class NameException : Exception
    {
        public NameException() : base("Error on Name field. Check that you are only using alphanumeric characters") { }
    }
}
