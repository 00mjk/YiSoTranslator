namespace YiSoTranslator
{
    /// <summary>
    /// A class represent a single translation
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public class Translation
    {
        private string _languageCode;

        /// <summary>
        /// the translation Language, only the code of the language
        /// </summary>
        public string LanguageCode
        {
            get => _languageCode;
            set {
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
    }
}
