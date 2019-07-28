namespace YiSoTranslator
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// the translator class for handling the translations
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public partial class Translator
    {
        /// <summary>
        /// the Translation manager, hold the translations
        /// </summary>
        public IYiSoTranslationsProvider Provider { get; set; }

        /// <summary>
        /// construct a new <see cref="Translator"/> object, with the given translationProvider
        /// </summary>
        /// <param name="translationProvider">the translation provider, that contains the translation</param>
        public Translator()
        {
            Language.CurrentLanguageChanged += (s, e) 
                => CurrentLanguageChanged?.Invoke(s, e);

            Language.DefaultLanguageChanged += (s, e) 
                => DefaultLanguageChanged?.Invoke(s, e);
        }

        /// <summary>
        /// attach the translation manager to the translator
        /// </summary>
        /// <param name="translationsProvider">the manager</param>
        public void AttachProvider(IYiSoTranslationsProvider translationsProvider)
        {
            if (translationsProvider is null)
                throw new ArgumentNullException(nameof(translationsProvider));

            Provider = translationsProvider;

            Provider.TranslationsGroupsListChanged += (s, e) 
                => TranslationGroupsListChanged?.Invoke(s, e);

            Provider.DataSourceChanged += (s, e) 
                => DataSourceChanged?.Invoke(s, e);
        }

        /// <summary>
        /// event raised when the CurrentLanguage in the Language Setting obj is changed
        /// </summary>
        public event EventHandler<LanguageChangedEventArgs> CurrentLanguageChanged;

        /// <summary>
        /// event raised when the DefaultLanguage in the Language Setting obj is changed
        /// </summary>
        public event EventHandler<LanguageChangedEventArgs> DefaultLanguageChanged;

        /// <summary>
        /// event raised when the TranslationGroups List in the Manager obj is changed
        /// </summary>
        public event EventHandler<TranslationsGroupsListChangedEventArgs> TranslationGroupsListChanged;

        /// <summary>
        /// Event Raised when the Data Source Changed
        /// </summary>
        public event EventHandler<DataSourceChangedEventArgs> DataSourceChanged;

        /// <summary>
        /// get the translation of the given name for the current language
        /// </summary>
        /// <param name="name">the name of the translation</param>
        /// <returns>the translation of the given name</returns>
        public async Task<string> GetTextAsync(string name)
            => await GetTextAsync(name, Language.CurrentLanguage);

        /// <summary>
        /// get the translation of the given name for the given language
        /// </summary>
        /// <param name="name">the name of the translation</param>
        /// <param name="language">the translation language</param>
        /// <returns>the translation of the given name</returns>
        public async Task<string> GetTextAsync(string name, Languages language)
            => await GetTextAsync(name, Language.GetByEnum(language));

        /// <summary>
        /// get the translation of the given name for the given language
        /// </summary>
        /// <param name="name">the name of the translation</param>
        /// <param name="language">the translation language</param>
        /// <returns>the translation of the given name</returns>
        public async Task<string> GetTextAsync(string name, Language language)
            => await FindTextAsync(name, language.Code);

        /// <summary>
        /// get the translation of the given name for the given language
        /// </summary>
        /// <param name="name">the name of the translation</param>
        /// <param name="language">the translation language</param>
        /// <returns>the translation of the given name</returns>
        public async Task<string> GetTextAsync(string name, string language)
            => await FindTextAsync(name, language);

        /// <summary>
        /// get the translation of the given name for the current language
        /// </summary>
        /// <param name="name">the name of the translation</param>
        /// <returns>the translation of the given name</returns>
        public string GetText(string name)
            => GetText(name, Language.CurrentLanguage);

        /// <summary>
        /// get the translation of the given name for the given language
        /// </summary>
        /// <param name="name">the name of the translation</param>
        /// <param name="language">the translation language</param>
        /// <returns>the translation of the given name</returns>
        public string GetText(string name, Languages language)
            => GetText(name, Language.GetByEnum(language));

        /// <summary>
        /// get the translation of the given name for the given language
        /// </summary>
        /// <param name="name">the name of the translation</param>
        /// <param name="language">the translation language</param>
        /// <returns>the translation of the given name</returns>
        public string GetText(string name, Language language)
            => GetText(name, language.Code);

        /// <summary>
        /// get the translation of the given name for the given language
        /// </summary>
        /// <param name="name">the name of the translation</param>
        /// <param name="language">the translation language</param>
        /// <returns>the translation of the given name</returns>
        public string GetText(string name, string language)
            => FindText(name, language);

        /// <summary>
        /// Find the translation of the given name for specified language
        /// </summary>
        /// <param name="name">the name of the translation</param>
        /// <param name="language">the language of the translation</param>
        /// <returns>the translation</returns>
        private async Task<string> FindTextAsync(string name, string language)
            => await Task.Run(() => FindText(name, language));

        /// <summary>
        /// Find the translation of the given name for specified language
        /// </summary>
        /// <param name="name">the name of the translation</param>
        /// <param name="language">the language of the translation</param>
        /// <returns>the translation</returns>
        private string FindText(string name, string language)
        {
            if (Provider is null)
                throw new System.ArgumentNullException("Provider is null, you have to attach a provider");

            if (string.IsNullOrEmpty(language) || string.IsNullOrEmpty(name))
                return null;

            var TranslationGroup = Provider.Find(name)
                ?? throw new TranslationsGroupNotExistException(name);

            var translation = TranslationGroup.Find(language)
                ?? TranslationGroup.Find(Language.DefaultLanguage)
                ?? throw new TranslationNotExistExceptions();

            return translation.Value;
        }
    }
}
