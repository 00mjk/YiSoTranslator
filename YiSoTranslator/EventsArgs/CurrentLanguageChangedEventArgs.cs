namespace YiSoTranslator
{
    using System;

    /// <summary>
    /// a LanguageChanged Event Argument Class
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public class LanguageChangedEventArgs : EventArgs
    {
        /// <summary>
        /// the old value
        /// </summary>
        public Language OldLanguage { get; }

        /// <summary>
        /// the new value
        /// </summary>
        public Language NewLanguage { get; }

        /// <summary>
        /// constructor for LanguageChangedEventArgs
        /// </summary>
        /// <param name="oldLanguage">the old Language</param>
        /// <param name="newLanguage">the new Language</param>
        public LanguageChangedEventArgs(Language oldLanguage, Language newLanguage)
        {
            OldLanguage = oldLanguage;
            NewLanguage = newLanguage;
        }
    }
}
