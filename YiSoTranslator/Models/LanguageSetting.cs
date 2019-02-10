namespace YiSoTranslator
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class to work with the language Setting
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public class LanguageSetting : IEquatable<LanguageSetting>
    {
        #region private members

        private Language _currentLanguage;
        private Language _defaultLanguage;

        private static readonly Lazy<LanguageSetting> lazy 
            = new Lazy<LanguageSetting>(() => new LanguageSetting());

        #endregion

        /// <summary>
        /// the Current selected language for the application to be displayed
        /// </summary>
        public Language CurrentLanguage
        {
            get => _currentLanguage;
            set
            {
                var tempVar = _currentLanguage;
                _currentLanguage = value;
                CurrentLanguageChanged?.Invoke(this, new LanguageChangedEventArgs(tempVar, value));
            }
        }

        /// <summary>
        /// the default language of the application, used as the fall back value
        /// </summary>
        public Language DefaultLanguage
        {
            get => _defaultLanguage;
            set
            {
                var tempVar = _defaultLanguage;
                _defaultLanguage = value;
                DefaultLanguageChanged?.Invoke(this, new LanguageChangedEventArgs(tempVar, value));
            }
        }

        /// <summary>
        /// get an Instant of the LanguageSetting object
        /// </summary>
        public static LanguageSetting Instant { get { return lazy.Value; } }

        /// <summary>
        /// event raised when the CurrentLanguage is changed
        /// </summary>
        public event EventHandler<LanguageChangedEventArgs> CurrentLanguageChanged;

        /// <summary>
        /// event raised when the DefaultLanguage is changed
        /// </summary>
        public event EventHandler<LanguageChangedEventArgs> DefaultLanguageChanged;

        /// <summary>
        /// construct a new <see cref="LanguageSetting"/> object with the default language and current Language
        /// initialized to English_UnitedStates
        /// </summary>
        private LanguageSetting()
        {
            _defaultLanguage = _currentLanguage = Language.GetByEnum(Languages.English_UnitedStates);
        }

        #region Overrides

        /// <summary>
        /// return the string representation
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
            => $"Current Language : '{CurrentLanguage}', Default Language : '{DefaultLanguage}'";

        /// <summary>
        /// check if the given object is equal to this instant
        /// </summary>
        /// <param name="obj">the object to compare to</param>
        /// <returns>true if equals</returns>
        public override bool Equals(object obj)
            => obj is LanguageSetting && Equals(obj as LanguageSetting);

        /// <summary>
        /// check if the given languageSetting is equal to this instant
        /// </summary>
        /// <param name="languageSetting">the languageSetting to compare to</param>
        /// <returns>true if equals</returns>
        public bool Equals(LanguageSetting languageSetting)
            => languageSetting != null &&
                   CurrentLanguage.Equals(languageSetting.CurrentLanguage) &&
                   DefaultLanguage.Equals(languageSetting.DefaultLanguage);

        /// <summary>
        /// get the hash code of the object
        /// </summary>
        /// <returns>the hash code</returns>
        public override int GetHashCode()
        {
            var hashCode = -424535100;
            hashCode = hashCode * -1521134295 + EqualityComparer<Language>.Default.GetHashCode(CurrentLanguage);
            hashCode = hashCode * -1521134295 + EqualityComparer<Language>.Default.GetHashCode(DefaultLanguage);
            return hashCode;
        }

        /// <summary>
        /// implement the equality operator
        /// </summary>
        /// <param name="setting1"></param>
        /// <param name="setting2"></param>
        /// <returns>true if equals</returns>
        public static bool operator ==(LanguageSetting setting1, LanguageSetting setting2)
            => EqualityComparer<LanguageSetting>.Default.Equals(setting1, setting2);

        /// <summary>
        /// implement the non equality operator
        /// </summary>
        /// <param name="setting1"></param>
        /// <param name="setting2"></param>
        /// <returns>true if not equals</returns>
        public static bool operator !=(LanguageSetting setting1, LanguageSetting setting2)
            => !(setting1 == setting2);

        #endregion
    }
}
