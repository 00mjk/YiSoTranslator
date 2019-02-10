namespace YiSoTranslator
{
    using System.Threading.Tasks;

    public partial class Translator
    {
        #region Public Methods

        /// <summary>
        /// get the translation of the given name for the current language
        /// </summary>
        /// <param name="name">the name of the translation</param>
        /// <returns>the translation of the given name</returns>
        public async Task<string> GetTextAsync(string name)
            => await GetTextAsync(name, LanguageSetting.CurrentLanguage);

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
            => await FindTextInJsonAsync(name, language.Code);

        /// <summary>
        /// get the translation of the given name for the given language
        /// </summary>
        /// <param name="name">the name of the translation</param>
        /// <param name="language">the translation language</param>
        /// <returns>the translation of the given name</returns>
        public async Task<string> GetTextAsync(string name, string language)
            => await FindTextInJsonAsync(name, language);

        /// <summary>
        /// get the translation of the given name for the current language
        /// </summary>
        /// <param name="name">the name of the translation</param>
        /// <returns>the translation of the given name</returns>
        public string GetText(string name)
            => GetText(name, LanguageSetting.CurrentLanguage);

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

        #endregion

        #region Private Methods

        /// <summary>
        /// Find the translation of the given name for specified language
        /// </summary>
        /// <param name="name">the name of the translation</param>
        /// <param name="language">the language of the translation</param>
        /// <returns>the translation</returns>
        private async Task<string> FindTextInJsonAsync(string name, string language)
            => await Task.Run(() => FindText(name, language));

        /// <summary>
        /// Find the translation of the given name for specified language
        /// </summary>
        /// <param name="name">the name of the translation</param>
        /// <param name="language">the language of the translation</param>
        /// <returns>the translation</returns>
        private string FindText(string name, string language)
        {
            if (string.IsNullOrEmpty(language) || string.IsNullOrEmpty(name))
                return null;

            var TranslationGroup = Manager.Find(name) 
                ?? throw new TranslationsGroupNotExistException(name);

            var translation = TranslationGroup.Find(language)
                ?? TranslationGroup.Find(LanguageSetting.DefaultLanguage.Code)
                ?? throw new TranslationNotExistExceptions();

            return translation.Value;
        }

        private void Setting_DefaultLanguageChanged(object sender, LanguageChangedEventArgs e)
            => DefaultLanguageChanged?.Invoke(sender, e);

        private void Setting_CurrentLanguageChanged(object sender, LanguageChangedEventArgs e)
            => CurrentLanguageChanged?.Invoke(sender, e);

        private void Manager_ListChanged(object sender, TranslationsGroupsListChangedEventArgs e)
            => TranslationGroupsListChanged?.Invoke(sender, e);

        private void TranslationsManager_DataSourceChanged(object sender, DataSourceChangedEventArgs e)
            => DataSourceChanged?.Invoke(sender, e);

        #endregion
    }
}
