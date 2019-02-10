namespace YiSoTranslator
{
    /// <summary>
    /// class for managing the YiSo Translator setting
    /// </summary>
    static class TranslatorConfig
    {
        /// <summary>
        /// initializer 
        /// </summary>
        public static void Initialize()
        {
            LanguageSetting.Instant.DefaultLanguage = GetDefaultLanguage();
            LanguageSetting.Instant.CurrentLanguage = GetCurrentLanguage();
        }

        /// <summary>
        /// get the Default language
        /// </summary>
        /// <returns>current language</returns>
        private static Language GetDefaultLanguage()
        {
            //ToDo : implement your own logic for retrieving the Current language
            return Language.GetByEnum(Languages.English_UnitedStates);
        }

        /// <summary>
        /// get the current language
        /// </summary>
        /// <returns>current language</returns>
        public static Language GetCurrentLanguage()
        {
            //ToDo : implement your own logic for retrieving the Current language
            return Language.GetByEnum(Languages.Arabic_Morocco);
        }

        /// <summary>
        /// change the current language
        /// </summary>
        /// <param name="language">the language to change the Current Language to</param>
        public static void ChangeCurrentLanguage(Language language)
        {
            //ToDo: implement your own logic for storing the Current language
            LanguageSetting.Instant.CurrentLanguage = language;
        }

        /// <summary>
        /// Get the Translation Provider
        /// </summary>
        /// <returns>instance of <see cref="IYiSoTranslationProvider"/>the translation Provider</returns>
        public static IYiSoTranslationProvider GetTranslationProvider()
        {
            //ToDo: Add reference to the provider you need to work with
            return null;
        }

        /// <summary>
        /// Use this method to add translations at run time
        /// </summary>
        /// <param name="manager">the manager on the Translator Object</param>
        public static void AddTranslations(TranslationsGroupManager manager)
        {
            manager.Add(new TranslationsGroup("Email_text"))
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"));

            manager.Add(new TranslationsGroup("phone_text"))
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your phone Number!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre numéro de téléphone!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل رقم الهاتف الخاص بك"));

            manager.SaveChanges();
        }
    }
}
