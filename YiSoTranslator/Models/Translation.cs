using System.Collections.Generic;

namespace YiSoTranslator
{
    /// <summary>
    /// A class represent a single translation
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public class Translation : ITranslation
    {
        private Language _language;

        /// <summary>
        /// the translation Language
        /// </summary>
        public Language Language
        {
            get => _language;
            set
            {
                if (value.HasDefaultValue())
                    throw new InvalidLanguage();

                _language = value;
            }
        }

        /// <summary>
        /// the value of the translation
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// a constructor for initializing a single instant of the <see cref="Translation"/> Class
        /// </summary>
        /// <param name="language">the language</param>
        /// <param name="value">the string of Translation</param>
        public Translation(Language language, string value)
        {
            Language = language;
            Value = value;
        }

        /// <summary>
        /// a constructor for initializing a single instant of the <see cref="Translation"/> Class
        /// </summary>
        /// <param name="language">the language</param>
        /// <param name="value">the string of Translation</param>
        public Translation(Languages language, string value)
            : this(language.ToLanguage(), value) { }

        #region Overrides

        /// <summary>
        /// check if the given object is equal to this instant
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true if equals</returns>
        public override bool Equals(object obj)
            => obj is ITranslation && Equals(obj as ITranslation);

        /// <summary>
        /// check if the given Translation is equal to this instant
        /// </summary>
        /// <param name="translation">the translation to compare to</param>
        /// <returns>true if equals</returns>
        public bool Equals(ITranslation translation)
        => translation != null &&
                   Language == translation.Language &&
                   Value == translation.Value;
        
        /// <summary>
        /// get the hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = -396614724;
            hashCode = hashCode * -1521134295 + System.Collections.Generic.EqualityComparer<string>.Default.GetHashCode(Language.Code);
            hashCode = hashCode * -1521134295 + System.Collections.Generic.EqualityComparer<string>.Default.GetHashCode(Value);
            return hashCode;
        }

        /// <summary>
        /// return the string representation
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
            => $"Language Code : {Language.Code}, Value : {Value}";

        /// <summary>
        /// implement the equality operator
        /// </summary>
        /// <param name="translation">the first object</param>
        /// <param name="translation2">second object</param>
        /// <returns>true if equals</returns>
        public static bool operator ==(Translation translation, Translation translation2)
            => EqualityComparer<Translation>.Default.Equals(translation, translation2);

        /// <summary>
        /// implement the non equality operator
        /// </summary>
        /// <param name="translation">the first object</param>
        /// <param name="translation2">second object</param>
        /// <returns>true if not equals</returns>
        public static bool operator !=(Translation translation, Translation translation2)
            => !(translation == translation2);

        #endregion
    }
}
