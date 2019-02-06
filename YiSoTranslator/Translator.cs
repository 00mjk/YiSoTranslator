namespace YiSoTranslator
{
    using System;

    /// <summary>
    /// the translator class for handling the translations
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public partial class Translator
    {
        #region Public Props

        /// <summary>
        /// Language Setting of the application
        /// </summary>
        public LanguageSetting LanguageSetting { get; set; }

        /// <summary>
        /// the Translation manager, hold the translations
        /// </summary>
        public TranslationGroupManager TranslationsManager { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// construct a new <see cref="Translator"/> object, with the given translationProvider
        /// </summary>
        /// <param name="translationProvider">the translation provider, that contains the translation</param>
        public Translator(IYiSoTranslationProvider translationProvider)
        {
            TranslationsManager = new TranslationGroupManager(translationProvider);
            LanguageSetting = LanguageSetting.Instant;

            LanguageSetting.CurrentLanguageChanged += Setting_CurrentLanguageChanged;
            LanguageSetting.DefaultLanguageChanged += Setting_DefaultLanguageChanged;
            TranslationsManager.TranslationsGroupsListChanged += Manager_ListChanged;
            TranslationsManager.TranslationsListChanged += TranslationsManager_TranslationsListChanged; ;
            TranslationsManager.DataSourceChanged += TranslationsManager_DataSourceChanged; ;
        }
        
        #endregion

        #region Events

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
        /// Event Raised when the Translations List Changed
        /// </summary>
        public event EventHandler<TranslationListChangedEventArgs> TranslationsListChanged;

        /// <summary>
        /// Event Raised when the Data Source Changed
        /// </summary>
        public event EventHandler<DataSourceChangedEventArgs> DataSourceChanged;

        private void Setting_DefaultLanguageChanged(object sender, LanguageChangedEventArgs e)
        {
            DefaultLanguageChanged?.Invoke(sender, e);
        }

        private void Setting_CurrentLanguageChanged(object sender, LanguageChangedEventArgs e)
        {
            CurrentLanguageChanged?.Invoke(sender, e);
        }

        private void Manager_ListChanged(object sender, TranslationsGroupsListChangedEventArgs e)
        {
            TranslationGroupsListChanged?.Invoke(sender, e);
        }

        private void TranslationsManager_DataSourceChanged(object sender, DataSourceChangedEventArgs e)
        {
            DataSourceChanged?.Invoke(sender, e);
        }

        private void TranslationsManager_TranslationsListChanged(object sender, TranslationListChangedEventArgs e)
        {
            TranslationsListChanged?.Invoke(sender, e);
        }

        #endregion
    }
}
