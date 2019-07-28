namespace YiSoTranslator
{
    using System;

    /// <summary>
    /// the language setting
    /// </summary>
    public interface ILanguageSettings : IEquatable<ILanguageSettings>
    {
        /// <summary>
        /// the current language
        /// </summary>
        Language CurrentLanguage { get; set; }

        /// <summary>
        /// the default language
        /// </summary>
        Language DefaultLanguage { get; set; }

        /// <summary>
        /// event raised with the current language is changed
        /// </summary>
        event EventHandler<LanguageChangedEventArgs> CurrentLanguageChanged;

        /// <summary>
        /// event raised with the default language is changed
        /// </summary>
        event EventHandler<LanguageChangedEventArgs> DefaultLanguageChanged;
    }
}