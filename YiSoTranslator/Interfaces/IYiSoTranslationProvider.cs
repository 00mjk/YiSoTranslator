namespace YiSoTranslator
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// interface to describe the IYiSoTranslationProvider functionality
    /// </summary>
    public interface IYiSoTranslationsProvider
    {
        /// <summary>
        /// the name of the provider, should be unique
        /// </summary>
        /// <remarks>
        /// check for the list of available providers to check if you have a unique name
        /// </remarks>
        string Name { get; }
        
        /// <summary>
        /// return the list of translations from the dataSource
        /// </summary>
        IEnumerable<ITranslationsGroup> TranslationsGroupsList { get; }

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
        ITranslationsGroup Add(ITranslationsGroup translationsGroup);

        /// <summary>
        /// Add the translations groups to the list
        /// </summary>
        /// <param name="translationsGroups">translation groups to be added</param>
        void AddRange(params ITranslationsGroup[] translationsGroups);

        /// <summary>
        /// update the old TranslationGroup name with the new name
        /// </summary>
        /// <param name="oldTranslationsGroupName">the old translation Croup name</param>
        /// <param name="newTranslationsGroupName">the new translation Group</param>
        /// <returns>the updated TranslationGroup</returns>
        ITranslationsGroup Update(string oldTranslationsGroupName, string newTranslationsGroupName);

        /// <summary>
        /// update the translations group with the new value,
        /// the old translation group will be retrieved using the Name of the passed in translations group
        /// </summary>
        /// <param name="newTranslationGroup">the updated translations group</param>
        /// <returns>updated version of the translation group</returns>
        /// <exception cref="TranslationsGroupNotExistException">the no translation group with the given name has been fond</exception>
        ITranslationsGroup Update(ITranslationsGroup newTranslationGroup);

        /// <summary>
        /// delete the translations Group from the list
        /// </summary>
        /// <param name="item">translation group to be removed</param>
        /// <returns>true if the item deleted, false if not</returns>
        /// <exception cref="TranslationsGroupNotExistException">if the translation group not exist</exception>
        bool Remove(ITranslationsGroup item);

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
        Task<bool> SaveChangesAsync();

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
        ITranslationsGroup Find(string name);

        /// <summary>
        /// look for a translations group in the list by a predicate
        /// </summary>
        /// <param name="predicate">the predicate to look with</param>
        /// <returns>the list of translations Group if exist, null if nothing found</returns>
        IEnumerable<ITranslationsGroup> Find(Func<ITranslationsGroup, bool> predicate);

        /// <summary>
        /// determine whether the element exist in the list
        /// </summary>
        /// <param name="item">the TranslationsGroup to look for</param>
        /// <returns>true if exist, false if not </returns>
        bool Contains(ITranslationsGroup item);

        /// <summary>
        /// get the index of the given item
        /// </summary>
        /// <param name="item">the translation Group</param>
        /// <returns>the index</returns>
        int IndexOf(ITranslationsGroup item);
    }
}
