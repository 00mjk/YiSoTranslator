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
        IEnumerable<TranslationsGroup> TranslationsGroupsList { get; }

        /// <summary>
        /// the count of the items in the list
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Event Raised when the Translations Groups List Changed
        /// </summary>
        event EventHandler<TranslationsGroupsListChangedEventArgs> TranslationsGroupsListChanged;

        /// <summary>
        /// Event Raised when the Data Source Changed
        /// </summary>
        event EventHandler<DataSourceChangedEventArgs> DataSourceChanged;

        /// <summary>
        /// Add the translations group to the list
        /// </summary>
        /// <param name="translationsGroup">translation group to be added</param>
        TranslationsGroup Add(TranslationsGroup translationsGroup);

        /// <summary>
        /// Add the translations groups to the list
        /// </summary>
        /// <param name="translationsGroups">translation groups to be added</param>
        void AddRange(params TranslationsGroup[] translationsGroups);

        /// <summary>
        /// update the old TranslationGroup name with the new name
        /// </summary>
        /// <param name="oldTranslationsGroupName">the old translation Croup name</param>
        /// <param name="newTranslationsGroupName">the new translation Group</param>
        /// <returns>the updated TranslationGroup</returns>
        TranslationsGroup Update(string oldTranslationsGroupName, string newTranslationsGroupName);

        /// <summary>
        /// update the old TranslationGroup name with the new name
        /// </summary>
        /// <param name="oldTranslationGroup">the old translation Croup name</param>
        /// <param name="newTranslationGroup">the new translation Group</param>
        /// <returns>the updated TranslationGroup</returns>
        TranslationsGroup Update(TranslationsGroup oldTranslationGroup, TranslationsGroup newTranslationGroup);

        /// <summary>
        /// delete the translations Group from the list
        /// </summary>
        /// <param name="item">translation group to be removed</param>
        /// <returns>true if the item deleted, false if not</returns>
        /// <exception cref="TranslationsGroupNotExistException">if the translation group not exist</exception>
        bool Remove(TranslationsGroup item);

        /// <summary>
        /// delete the translations Group from the list
        /// </summary>
        /// <param name="TranslationGroupName">Name of translation group to be removed</param>
        /// <returns>true if the item deleted, false if not</returns>
        /// <exception cref="TranslationsGroupNotExistException">if the translation group not exist</exception>
        bool Remove(string TranslationGroupName);

        /// <summary>
        /// remove all TranslationsGroups from the list
        /// </summary>
        void Clear();

        /// <summary>
        /// re read the translation from the source
        /// note that the function has a flag to discard Changes
        /// by default is set to false, so that if you have unsaved changes 
        /// you will get an exception
        /// </summary>
        /// <exception cref="UnsavedChangesExceptions">if you have unsaved changes</exception>
        void Reload(bool discardChanges = false);

        /// <summary>
        /// save the translations to the dataSource
        /// </summary>
        /// <returns>true if data is saved, false if not</returns>
        bool SaveChanges();

        /// <summary>
        /// save the translations to the dataSource
        /// </summary>
        /// <returns>true if data is saved, false if not</returns>
        System.Threading.Tasks.Task<bool> SaveChangesAsync();

        /// <summary>
        /// Export the translations to the file
        /// </summary>
        /// <param name="file">file where translations will be exported</param>
        bool SaveToFile(IYiSoTranslationFile file);

        /// <summary>
        /// Export the translations to the file 
        /// </summary>
        /// <param name="file">file where translations will be exported</param>
        System.Threading.Tasks.Task<bool> SaveToFileAsync(IYiSoTranslationFile file);

        /// <summary>
        /// get the list of translations from the File and 
        /// populate the database of translations with the data
        /// </summary>
        /// <param name="file">the file to read the translations from</param>
        void ReadFromFile(IYiSoTranslationFile file);

        /// <summary>
        /// check if there is a translationsGroup with the given name
        /// </summary>
        /// <param name="name">the name of translationsGroup</param>
        /// <returns>true if exist, false if not</returns>
        bool IsExist(string name);

        /// <summary>
        /// look for a translations group in the list by name
        /// </summary>
        /// <param name="name">the name of the translations group</param>
        /// <returns>the translation Group if exist, null if nothing found</returns>
        TranslationsGroup Find(string name);

        /// <summary>
        /// look for a translations group in the list by a predicate
        /// </summary>
        /// <param name="predicate">the predicate to look with</param>
        /// <returns>the list of translations Group if exist, null if nothing found</returns>
        IEnumerable<TranslationsGroup> Find(Func<TranslationsGroup, bool> predicate);

        /// <summary>
        /// determine whether the element exist in the list
        /// </summary>
        /// <param name="item">the TranslationsGroup to look for</param>
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
