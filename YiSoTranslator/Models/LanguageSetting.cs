namespace YiSoTranslator
{
    using System;

    /// <summary>
    /// Class to work with the language Setting
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public class LanguageSetting
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
        /// return the current and Default Language
        /// </summary>
        /// <returns>the name of the obj</returns>
        public override string ToString()
        {
            return $"Current Language : '{CurrentLanguage}', Default Language : '{DefaultLanguage}'";
        }

        /// <summary>
        /// check if the objects are equals base on the value of the Current and Default Language
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>the boolean value of the comparison</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            if ((obj as LanguageSetting).DefaultLanguage != DefaultLanguage ||
                (obj as LanguageSetting).CurrentLanguage != CurrentLanguage)
                return false;

            return true;
        }

        /// <summary>
        /// get the hash value
        /// </summary>
        /// <returns>hash value</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
