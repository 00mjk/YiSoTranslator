namespace YiSoTranslator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// represent a Translations Group that holds the list translations
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public partial class TranslationsGroup : ITranslationsGroup
    {
        /// <summary>
        /// construct an instance of the <see cref="TranslationsGroup"/> class, with the specified name
        /// </summary>
        /// <param name="name">the name of the group</param>
        public TranslationsGroup(string name)
        {
            Name = name;
            _translationsList = new List<ITranslation>();
        }

        /// <summary>
        /// the name of the translations Group
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                if (!value.IsValid())
                    throw new ArgumentException("the given name is not valid. Because is null, empty, or whiteSpace");

                _name = value;
            }
        }

        /// <summary>
        /// get the count of translations 
        /// </summary>
        public int Count { get => _translationsList.Count; }

        /// <summary>
        /// Gets a value indicating whether the System.Collections.Generic.ICollection`1
        /// is read-only.
        /// </summary>
        public bool IsReadOnly => _translationsList.IsReadOnly;

        /// <summary>
        /// Event Raised when the List of translation changed
        /// </summary>
        public event EventHandler<TranslationsListChangedEventArgs> TranslationsListChanged;

        /// <summary>
        /// change the list of translations with new list
        /// this list will override the current list
        /// </summary>
        /// <param name="translations">the new translations list</param>
        public void ChangeTranslationList(IEnumerable<ITranslation> translations)
        {
            _translationsList = translations as IList<ITranslation>;
            OnTranslationsListChanged();
        }

        /// <summary>
        /// find the translation with the given language code
        /// </summary>
        /// <param name="Code">the language code of the translation to retrieve</param>
        /// <returns>the matched translation, null if not found</returns>
        public ITranslation Find(string Code)
            => _translationsList.FirstOrDefault(t => t.Language.Code.Equals(Code, StringComparison.OrdinalIgnoreCase));

        /// <summary>
        /// find the translation with the given language code
        /// </summary>
        /// <param name="Code">the language code of the translation to retrieve</param>
        /// <returns>the matched translation, null if not found</returns>
        public ITranslation Find(Language language)
            => Find(language.Code);

        /// <summary>
        /// find the translation with the given language code
        /// </summary>
        /// <param name="Code">the language code of the translation to retrieve</param>
        /// <returns>the matched translation, null if not found</returns>
        public ITranslation Find(Languages language)
            => Find(language.Code());

        /// <summary>
        /// the index of the given translation
        /// </summary>
        /// <param name="translation">the translation to retrieve the index for it</param>
        /// <returns>the index</returns>
        public int IndexOf(ITranslation translation)
            => _translationsList.IndexOf(translation);

        /// <summary>
        /// update the translation that has the language of the new translation, with new value
        /// </summary>
        /// <param name="NewTranslation">the new translation</param>
        /// <exception cref="ArgumentNullException">if NewTranslation is null</exception>
        /// <exception cref="TranslationNotExistExceptions">if the Old Translation Not Found</exception>
        public void UpdateTranslation(ITranslation NewTranslation)
        {
            if (NewTranslation is null)
                throw new ArgumentNullException(nameof(NewTranslation));

            var ot = Find(NewTranslation.Language)
                ?? throw new TranslationNotExistExceptions(Name, NewTranslation.Language.Code);

            ot.Value = NewTranslation.Value;
            OnUpdateTranslation(IndexOf(ot), NewTranslation, ot);
        }

        /// <summary>
        /// add the translation to the list of translation
        /// </summary>
        /// <param name="item">the translation to add</param>
        /// <exception cref="TranslationAlreadyExistExceptions">if the translation already exist</exception>
        public ITranslationsGroup Add(ITranslation item)
        {
            var translation = Find(item.Language.Code);

            if (translation != null)
                throw new TranslationAlreadyExistExceptions(Name, item.Language.Code);

            _translationsList.Add(item);
            OnAddTranlsation(item);

            return this;
        }

        /// <summary>
        /// add the translation to the list of translation
        /// </summary>
        /// <param name="item">the translation to add</param>
        /// <exception cref="TranslationAlreadyExistExceptions">if the translation already exist</exception>
        void ICollection<ITranslation>.Add(ITranslation item)
            => Add(item);

        /// <summary>
        /// clear the list of the translations
        /// </summary>
        public void Clear()
            => _translationsList.Clear();

        /// <summary>
        /// check if the list of the translations contains the given translation
        /// </summary>
        /// <param name="item">the translation to check</param>
        /// <returns>true if exist, false if not</returns>
        public bool Contains(ITranslation item)
            => _translationsList.Contains(item);

        /// <summary>
        /// copy the list of the translation to given array
        /// </summary>
        /// <param name="array">the array to copy the list to it</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(ITranslation[] array, int arrayIndex)
            => _translationsList.CopyTo(array, arrayIndex);

        /// <summary>
        /// remove the translation with the given code
        /// </summary>
        /// <param name="LanguageCode">the translation language code</param>
        /// <returns>true if removed, false if not</returns>
        /// <exception cref="TranslationNotExistExceptions">if there is no translation with the given language</exception>
        public bool Remove(string LanguageCode)
        {
            var t = Find(LanguageCode)
               ?? throw new TranslationNotExistExceptions(Name, LanguageCode);

            if (_translationsList.Remove(t))
                OnDeleteTranslation(t);

            return false;
        }

        /// <summary>
        /// remove the given translation from the list
        /// </summary>
        /// <param name="translation">the translation to be removed</param>
        /// <exception cref="TranslationNotExistExceptions">if the Translation Not Found</exception>
        public bool Remove(ITranslation item)
            => Remove(item.Language.Code);

        /// <summary>
        /// remove the translation with the given code
        /// </summary>
        /// <param name="LanguageCode">the translation language</param>
        /// <returns>true if removed, false if not</returns>
        /// <exception cref="TranslationNotExistExceptions">if there is no translation with the given language</exception>
        public bool Remove(Language language)
            => Remove(language.Code);

        /// <summary>
        /// remove the translation with the given code
        /// </summary>
        /// <param name="LanguageCode">the translation language</param>
        /// <returns>true if removed, false if not</returns>
        /// <exception cref="TranslationNotExistExceptions">if there is no translation with the given language</exception>
        public bool Remove(Languages language)
            => Remove(language.Code());

        /// <summary>
        ///  Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<ITranslation> GetEnumerator()
            => _translationsList.GetEnumerator();

        /// <summary>
        ///  Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
            => _translationsList.GetEnumerator();

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
            => _translationsList.Any(t => t.Language.Code == languageCode);
    }
    
    /// <summary>
    /// the partial class for <see cref="TranslationsGroup"/>
    /// </summary>
    public partial class TranslationsGroup
    {
        private IList<ITranslation> _translationsList;
        private string _name;

        private void OnTranslationsListChanged()
        {
            TranslationsListChanged?.Invoke(this, new TranslationsListChangedEventArgs(ListChangedType.NewRefrence, -1, null, null));
        }

        private void OnUpdateTranslation(int index, ITranslation NewTranslation, ITranslation OldTranslation)
        {
            TranslationsListChanged?.Invoke(this, new TranslationsListChangedEventArgs(ListChangedType.Update, index, OldTranslation, NewTranslation));
        }

        private void OnAddTranlsation(ITranslation translation)
        {
            TranslationsListChanged?.Invoke(this, new TranslationsListChangedEventArgs(ListChangedType.Add, IndexOf(translation), null, translation));
        }

        private void OnDeleteTranslation(ITranslation translation)
        {
            TranslationsListChanged?.Invoke(this, new TranslationsListChangedEventArgs(ListChangedType.Delete, -1, translation, null));
        }

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
            => Equals(obj as ITranslationsGroup);

        /// <summary>
        /// check if the translationsGroup are equals, the comparison is based on the group name
        /// </summary>
        /// <param name="translationsGroup">the object to compare to</param>
        /// <returns>true if equals</returns>
        public bool Equals(ITranslationsGroup translationsGroup)
            => translationsGroup != null && Name.Equals(translationsGroup.Name, StringComparison.OrdinalIgnoreCase);

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

        /// <summary>
        /// implement the equality operator
        /// </summary>
        /// <param name="group1"></param>
        /// <param name="group2"></param>
        /// <returns>true if equals</returns>
        public static bool operator ==(TranslationsGroup group1, ITranslationsGroup group2)
            => EqualityComparer<TranslationsGroup>.Default.Equals(group1, group2 as TranslationsGroup);

        /// <summary>
        /// implement the non equality operator
        /// </summary>
        /// <param name="group1"></param>
        /// <param name="group2"></param>
        /// <returns>true if not equals</returns>
        public static bool operator !=(TranslationsGroup group1, ITranslationsGroup group2)
            => !(group1 == group2);
    }
}
