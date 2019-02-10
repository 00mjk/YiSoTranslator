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
        public TranslationsGroupManager Manager { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// construct a new <see cref="Translator"/> object, with the given translationProvider
        /// </summary>
        /// <param name="translationProvider">the translation provider, that contains the translation</param>
        public Translator(IYiSoTranslationProvider translationProvider)
        {
            Manager = new TranslationsGroupManager(translationProvider);
            LanguageSetting = LanguageSetting.Instant;

            LanguageSetting.CurrentLanguageChanged += Setting_CurrentLanguageChanged;
            LanguageSetting.DefaultLanguageChanged += Setting_DefaultLanguageChanged;
            Manager.TranslationsGroupsListChanged += Manager_ListChanged;
            Manager.DataSourceChanged += TranslationsManager_DataSourceChanged; ;
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
        /// Event Raised when the Data Source Changed
        /// </summary>
        public event EventHandler<DataSourceChangedEventArgs> DataSourceChanged;

        #endregion
    }
}
