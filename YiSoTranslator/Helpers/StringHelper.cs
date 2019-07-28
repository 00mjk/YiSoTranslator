namespace YiSoTranslator
{
    /// <summary>
    /// a class that holds string extension methods
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// check if the given string value is valid
        /// this method checks if the string is null or empty or whitespace
        /// </summary>
        /// <param name="value">the string value to check</param>
        /// <returns>true if valid, false if not</returns>
        public static bool IsValid(this string value)
            => !(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value));
    }
}
