using NameValuePairs.Core.Entities;

namespace NameValuePairs.Core.Constraints
{
    /// <summary>
    /// Constrains on the NameValuePair entity
    /// </summary>
    public interface INameValuePairConstraints
    {
        /// <summary>
        /// Retrieves the target for fluent use. Throws exceptions if different constrains are not met
        /// </summary>
        NameValuePair Match(NameValuePair target);
    }
}
