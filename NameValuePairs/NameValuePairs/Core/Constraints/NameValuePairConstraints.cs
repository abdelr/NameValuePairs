using NameValuePairs.Core.Entities;
using NameValuePairs.Exceptions;

namespace NameValuePairs.Core.Constraints
{
    /// <summary>
    /// Constrains on the NameValuePair entity
    /// </summary>
    public class NameValuePairConstraints : INameValuePairConstraints
    {
        /// <summary>
        /// Retrieves the target for fluent use. Throws exceptions if different constrains are not met
        /// </summary>
        /// <exception cref="Core.Exceptions.NameException">
        /// Thrown when the name does not match alphanumeric restriction
        /// </exception>
        /// <exception cref="Core.Exceptions.ValueException">
        /// Thrown when the value does not match alphanumeric restriction
        /// </exception>
        public NameValuePair Match(NameValuePair target)
        {
            target.Name = target.Name.Trim();
            target.Value = target.Value.Trim();
            if (!System.Text.RegularExpressions.Regex.IsMatch(target.Name, @"^[a-zA-Z0-9]+$"))
                throw new NameException();
            if (!System.Text.RegularExpressions.Regex.IsMatch(target.Value, @"^[a-zA-Z0-9]+$"))
                throw new ValueException();
            return target;
        }
    }
}
