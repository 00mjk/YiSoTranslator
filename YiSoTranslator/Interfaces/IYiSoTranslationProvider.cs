namespace YiSoTranslator
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// interface to describe the IYiSoTranslationProvider functionality
    /// </summary>
    public interface IYiSoTranslationProvider
    {
        /// <summary>
        /// return the list of translations from the dataSource
        /// </summary>
        IEnumerable<TranslationsGroup> TranslationsGroupList { get; }

        /// <summary>
        /// the count of the items in the list
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Event Raised when the Translations Groups List Changed
        /// </summary>
        event EventHandler<TranslationsGroupsListChangedEventArgs> TranslationsGroupsListChanged;

        /// <summary>
        /// Event Raised when the Translations List Changed
        /// </summary>
        event EventHandler<TranslationListChangedEventArgs> TranslationsListChanged;

        /// <summary>
        /// Event Raised when the Data Source Changed
        /// </summary>
        event EventHandler<DataSourceChangedEventArgs> DataSourceChanged;

        /// <summary>
        /// Add the translation group to the list
        /// </summary>
        /// <param name="translationGroup">translation group to be added</param>
        TranslationsGroup Add(TranslationsGroup translationGroup);

        /// <summary>
        /// Add the translation groups to the list
        /// </summary>
        /// <param name="translationGroups">translation groups to be added</param>
        void AddRange(IEnumerable<TranslationsGroup> translationGroups);

        /// <summary>
        /// update the old TranslationGroup name with the new name
        /// </summary>
        /// <param name="oldTranslationGroupName">the old translation Croup name</param>
        /// <param name="newTranslationGroupName">the new translation Group</param>
        /// <returns>the updated TranslationGroup</returns>
        TranslationsGroup Update(string oldTranslationGroupName, string newTranslationGroupName);

        /// <summary>
        /// delete the translations Group from the list
        /// </summary>
        /// <param name="item">translation group to be removed</param>
        /// <returns>true if the item deleted, false if not</returns>
        /// <exception cref="TranslationGroupNotExistException">if the translation group not exist</exception>
        bool Remove(TranslationsGroup item);

        /// <summary>
        /// delete the translations Group from the list
        /// </summary>
        /// <param name="TranslationGroupName">Name of translation group to be removed</param>
        /// <returns>true if the item deleted, false if not</returns>
        /// <exception cref="TranslationGroupNotExistException">if the translation group not exist</exception>
        bool Remove(string TranslationGroupName);

        /// <summary>
        /// remove all elements from the list
        /// </summary>
        void Clear();

        /// <summary>
        /// save the translations to the dataSource
        /// </summary>
        /// <returns>true if data is saved, false if not</returns>
        bool SaveChanges();

        /// <summary>
        /// Export the translations to the file
        /// </summary>
        /// <param name="file">file where translations will be exported</param>
        bool SaveToFile(IYiSoTranslationFile file);

        /// <summary>
        /// get the list of translations from the File and 
        /// populate the database of translations with the data
        /// </summary>
        /// <param name="file">the file to read the translations from</param>
        void ReadFromFile(IYiSoTranslationFile file);

        /// <summary>
        /// check if there is a translationGroup with the given name
        /// </summary>
        /// <param name="name">the name of translationGroup</param>
        /// <returns>true if exist, false if not</returns>
        bool IsExist(string name);

        /// <summary>
        /// look for a translation group in the list by name
        /// </summary>
        /// <param name="name">the name of the translation group</param>
        /// <returns>the translation Group if exist, null if nothing found</returns>
        TranslationsGroup Find(string name);

        /// <summary>
        /// look for a translation group in the list by a predicate
        /// </summary>
        /// <param name="predicate">the predicate to look with</param>
        /// <returns>the list of translation Group if exist, null if nothing found</returns>
        IEnumerable<TranslationsGroup> Find(Func<TranslationsGroup, bool> predicate);

        /// <summary>
        /// determine whether the element exist in the list
        /// </summary>
        /// <param name="item">the TranslationGroup to look for</param>
        /// <returns>true if exist, false if not </returns>
        bool Contains(TranslationsGroup item);

        /// <summary>
        /// get the index of the given item
        /// </summary>
        /// <param name="item">the translation Group</param>
        /// <returns>the index</returns>
        int IndexOf(TranslationsGroup item);
    }
}
