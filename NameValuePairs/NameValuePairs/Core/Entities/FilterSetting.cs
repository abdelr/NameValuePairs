namespace NameValuePairs.Core.Entities
{
    /// <summary>
    /// Filter setting Entity
    /// </summary>
    public class FilterSetting
    {
        /// <summary>
        /// Filter on
        /// </summary>
        public enum ValueType
        {
            NAME,
            VALUE
        }

        /// <summary>
        /// Whether to filter on name or value
        /// </summary>
        public ValueType Type { get; set; }

        /// <summary>
        /// Value to match
        /// </summary>
        public string Value { get; set; }
    }
}
