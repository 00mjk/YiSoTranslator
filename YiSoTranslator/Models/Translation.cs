namespace YiSoTranslator
{
    /// <summary>
    /// A class represent a single translation
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public class Translation : System.IEquatable<Translation>
    {
        private string _languageCode;

        /// <summary>
        /// the translation Language, only the code of the language
        /// </summary>
        public string LanguageCode
        {
            get => _languageCode;
            set
            {
                if (Language.GetByCode(value) == null)
                    throw new InvalidLanguageCode(value);

                _languageCode = value;
            }
        }

        /// <summary>
        /// the value of the translation
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// a constructor for initializing a single instant of the <see cref="Translation"/> Class
        /// </summary>
        /// <param name="languageCode">the language code</param>
        /// <param name="value">the string of Translation</param>
        public Translation(string languageCode, string value)
        {
            LanguageCode = languageCode;
            Value = value;
        }

        #region Overrides

        /// <summary>
        /// check if the given object is equal to this instant
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true if equals</returns>
        public override bool Equals(object obj)
            => obj is Translation && Equals(obj as Translation);

        /// <summary>
        /// check if the given Translation is equal to this instant
        /// </summary>
        /// <param name="translation">the translation to compare to</param>
        /// <returns>true if equals</returns>
        public bool Equals(Translation translation)
            => translation != null &&
                   LanguageCode == translation.LanguageCode &&
                   Value == translation.Value;

        /// <summary>
        /// get the hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = -396614724;
            hashCode = hashCode * -1521134295 + System.Collections.Generic.EqualityComparer<string>.Default.GetHashCode(LanguageCode);
            hashCode = hashCode * -1521134295 + System.Collections.Generic.EqualityComparer<string>.Default.GetHashCode(Value);
            return hashCode;
        }

        /// <summary>
        /// return the string representation
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
            => $"Language Code : {LanguageCode}, Value : {Value}";

        #endregion
    }
}
