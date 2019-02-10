namespace YiSoTranslator
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// represent a Translations Group with the translations list
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public class TranslationsGroup : IComparable, IEquatable<TranslationsGroup>
    {
        #region private fields

        private IList<Translation> _translationsList;
        private string _name;

        #endregion

        #region Public Prop

        /// <summary>
        /// the name of the translations Group
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("the given name is not valid. Because is null, empty, or whiteSpace");

                _name = value;
            }
        }

        /// <summary>
        /// list of the translations in the group
        /// </summary>
        public IEnumerable<Translation> TranslationsList { get => _translationsList; }

        /// <summary>
        /// get the count of translations 
        /// </summary>
        public int Count { get => _translationsList.Count; }

        #endregion

        #region Events

        /// <summary>
        /// Event Raised when the List of translation changed
        /// </summary>
        public event EventHandler<TranslationsListChangedEventArgs> TranslationsListChanged;

        #endregion

        #region Constructors

        /// <summary>
        /// construct an instance of the <see cref="TranslationsGroup"/> class, with the specified name
        /// </summary>
        /// <param name="name">the name of the group</param>
        public TranslationsGroup(string name)
        {
            Name = name;
            _translationsList = new List<Translation>();
        }

        #endregion

        #region Translation list manipulation methods

        /// <summary>
        /// check if the TranslationsGroup has the given language
        /// </summary>
        /// <param name="language">the language to check</param>
        /// <returns>true if exist</returns>
        public bool HasLanguage(Languages language)
            => HasLanguage(language.Code());

        /// <summary>
        /// check if the TranslationsGroup has the given language
        /// </summary>
        /// <param name="languageCode">the language to check</param>
        /// <returns>true if exist</returns>
        public bool HasLanguage(string languageCode)
            => _translationsList.Any(t => t.LanguageCode == languageCode);

        /// <summary>
        /// find the Translation with given language code
        /// </summary>
        /// <param name="Code">the code of the language</param>
        /// <returns>return the Translation if exist, null if nothing found</returns>
        public Translation Find(string Code)
            => _translationsList.FirstOrDefault(t => t.LanguageCode.ToLower() == Code.ToLower());

        /// <summary>
        /// get the index of the translation in the translations list
        /// </summary>
        /// <param name="translation">translation to find</param>
        /// <returns>the index of the translation</returns>
        public int IndexOf(Translation translation)
            => _translationsList.IndexOf(translation);

        /// <summary>
        /// add the translation to the list, if the translation already exist an exception will be thrown
        /// </summary>
        /// <param name="translation">the translation added</param>
        /// <returns>The Added Translation</returns>
        /// <exception cref="TranslationAlreadyExistExceptions">if the Translation Already Exist in the list</exception>
        public TranslationsGroup Add(Translation translation)
        {
            var t = Find(translation.LanguageCode);

            if (t != null)
                throw new TranslationAlreadyExistExceptions(Name, translation.LanguageCode);

            _translationsList.Add(translation);
            OnAddTranlsation(translation);
            return this;
        }

        /// <summary>
        /// remove the given translation from the list
        /// </summary>
        /// <param name="translation">the translation to be removed</param>
        /// <exception cref="TranslationNotExistExceptions">if the Translation Not Found</exception>
        public void DeleteTranslation(Translation translation)
            => DeleteTranslation(translation.LanguageCode);

        /// <summary>
        /// remove the translation from the list that has the given LanguageCode
        /// </summary>
        /// <param name="LanguageCode">language code of the translation to be removed</param>
        /// <exception cref="TranslationNotExistExceptions">if the Translation Not Found</exception>
        public bool DeleteTranslation(string LanguageCode)
        {
            var t = Find(LanguageCode)
                ?? throw new TranslationNotExistExceptions(Name, LanguageCode);

            if (_translationsList.Remove(t))
                OnDeleteTranslation(t);

            return false;
        }

        /// <summary>
        /// update the old translation with the new values
        /// if the New Translation already exist we just gonna update it the value
        /// </summary>
        /// <param name="OldTranslationLanguageCode">the old translation Language code</param>
        /// <param name="NewTranslation">the new translation</param>
        /// <exception cref="TranslationNotExistExceptions">if the Old Translation Not Found</exception>
        public void UpdateTranslation(string OldTranslationLanguageCode, Translation NewTranslation)
        {
            var ot = Find(OldTranslationLanguageCode)
                ?? throw new TranslationNotExistExceptions(Name, OldTranslationLanguageCode);
            var nt = Find(NewTranslation.LanguageCode);

            if (nt == null)
            {
                // if the new values not exist, than we will override the values for the old translation
                ot.Value = NewTranslation.Value;
                ot.LanguageCode = NewTranslation.LanguageCode;
                OnUpdateTranslation(IndexOf(ot), NewTranslation, ot);
            }
            else
            {
                // the new values passed as NewTranslation exist, this mean that the user need to update
                // only the value of the translation, so that we don't have tow translations for the same language
                nt.Value = NewTranslation.Value;
                OnUpdateTranslation(IndexOf(nt), NewTranslation, nt);
            }
        }

        /// <summary>
        /// update the translation list with the new list
        /// </summary>
        /// <param name="translations">the new translation list</param>
        public void ChangeTranslationList(List<Translation> translations)
        {
            _translationsList = translations;
            OnTranslationsListChanged();
        }

        #endregion

        #region Private methods

        private void OnTranslationsListChanged()
        {
            TranslationsListChanged?.Invoke(this, new TranslationsListChangedEventArgs(ListChangedType.NewRefrence, -1, null, null));
        }

        private void OnUpdateTranslation(int index, Translation NewTranslation, Translation OldTranslation)
        {
            TranslationsListChanged?.Invoke(this, new TranslationsListChangedEventArgs(ListChangedType.Update, index, OldTranslation, NewTranslation));
        }

        private void OnAddTranlsation(Translation translation)
        {
            TranslationsListChanged?.Invoke(this, new TranslationsListChangedEventArgs(ListChangedType.Add, IndexOf(translation), null, translation));
        }

        private void OnDeleteTranslation(Translation translation)
        {
            TranslationsListChanged?.Invoke(this, new TranslationsListChangedEventArgs(ListChangedType.Delete, -1, translation, null));
        }

        #endregion

        #region Overrides

        /// <summary>
        /// return the name of the object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => $"Name : {Name}, Translation Count : {Count}";

        /// <summary>
        /// compare the two objects
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (!(obj is TranslationsGroup tg))
                return 1;

            return Name.CompareTo(tg.Name);
        }

        /// <summary>
        /// prevent the Serializations of the Count Prop
        /// </summary>
        /// <returns>false</returns>
        public bool ShouldSerializeCount()
        {
            return false;
        }

        /// <summary>
        /// check if the given obj equals this instant
        /// </summary>
        /// <param name="obj">the object to compare to</param>
        /// <returns>true if equals</returns>
        public override bool Equals(object obj)
            => Equals(obj as TranslationsGroup);

        /// <summary>
        /// check if the translationsGroup are equals
        /// </summary>
        /// <param name="translationsGroup">the object to compare to</param>
        /// <returns>true if equals</returns>
        public bool Equals(TranslationsGroup translationsGroup)
            => translationsGroup != null &&
                   Name == translationsGroup.Name
                   && Count == translationsGroup.Count;

        /// <summary>
        /// get the hash code
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode()
            => 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);

        /// <summary>
        /// implement the equality operator
        /// </summary>
        /// <param name="group1"></param>
        /// <param name="group2"></param>
        /// <returns>true if equals</returns>
        public static bool operator ==(TranslationsGroup group1, TranslationsGroup group2)
            => EqualityComparer<TranslationsGroup>.Default.Equals(group1, group2);

        /// <summary>
        /// implement the non equality operator
        /// </summary>
        /// <param name="group1"></param>
        /// <param name="group2"></param>
        /// <returns>true if not equals</returns>
        public static bool operator !=(TranslationsGroup group1, TranslationsGroup group2)
            => !(group1 == group2);
        
        #endregion
    }
}
