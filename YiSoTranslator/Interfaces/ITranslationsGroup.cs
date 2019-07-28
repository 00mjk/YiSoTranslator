namespace YiSoTranslator
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// the translation group, it hold the list of translation grouped by a unique name
    /// </summary>
    public interface ITranslationsGroup 
        : ICollection<ITranslation>, IComparable, IEquatable<ITranslationsGroup>
    {
        /// <summary>
        /// the unique name of the group
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// event raised when the list of the translations has been changed
        /// </summary>
        event EventHandler<TranslationsListChangedEventArgs> TranslationsListChanged;

        /// <summary>
        /// change the list of translations with new list
        /// this list will override the current list
        /// </summary>
        /// <param name="translations">the new translations list</param>
        void ChangeTranslationList(IEnumerable<ITranslation> translations);

        /// <summary>
        /// add the translation to the list of translation
        /// </summary>
        /// <param name="item">the translation to add</param>
        /// <exception cref="TranslationAlreadyExistExceptions">if the translation already exist</exception>
        new ITranslationsGroup Add(ITranslation item);

        /// <summary>
        /// remove the translation with the given code
        /// </summary>
        /// <param name="LanguageCode">the translation language code</param>
        /// <returns>true if removed, false if not</returns>
        bool Remove(string LanguageCode);

        /// <summary>
        /// remove the translation with the given code
        /// </summary>
        /// <param name="language">the translation language</param>
        /// <returns>true if removed, false if not</returns>
        bool Remove(Language language);

        /// <summary>
        /// remove the translation with the given code
        /// </summary>
        /// <param name="language">the translation language</param>
        /// <returns>true if removed, false if not</returns>
        bool Remove(Languages language);

        /// <summary>
        /// find the translation with the given language code
        /// </summary>
        /// <param name="Code">the language code of the translation to retrieve</param>
        /// <returns>the matched translation, null if not found</returns>
        ITranslation Find(string Code);

        /// <summary>
        /// find the translation with the given language code
        /// </summary>
        /// <param name="Code">the language code of the translation to retrieve</param>
        /// <returns>the matched translation, null if not found</returns>
        ITranslation Find(Language language);

        /// <summary>
        /// find the translation with the given language code
        /// </summary>
        /// <param name="Code">the language code of the translation to retrieve</param>
        /// <returns>the matched translation, null if not found</returns>
        ITranslation Find(Languages language);

        /// <summary>
        /// check if the current translation list has a translation with the given language
        /// </summary>
        /// <param name="language">the language</param>
        /// <returns>true if exist, false if not</returns>
        bool HasLanguage(Languages language);

        /// <summary>
        /// check if the current translation list has a translation with the given language code
        /// </summary>
        /// <param name="language">the language</param>
        /// <returns>true if exist, false if not</returns>
        bool HasLanguage(string languageCode);

        /// <summary>
        /// the index of the given translation
        /// </summary>
        /// <param name="translation">the translation to retrieve the index for it</param>
        /// <returns>the index</returns>
        int IndexOf(ITranslation translation);

        /// <summary>
        /// update the translation that has the language of the new translation, with new value
        /// </summary>
        /// <param name="NewTranslation">the new translation</param>
        /// <exception cref="ArgumentNullException">if NewTranslation is null</exception>
        /// <exception cref="TranslationNotExistExceptions">if the Old Translation Not Found</exception>
        void UpdateTranslation(ITranslation NewTranslation);
    }
}