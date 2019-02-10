namespace YiSoTranslator
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// class for managing translations Groups
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public class TranslationsGroupManager
    {
        #region Public Properties

        /// <summary>
        /// list holder of Translations Groups
        /// </summary>
        public IEnumerable<TranslationsGroup> TranslationsGroupsList
            => TranslationProvider.TranslationsGroupsList;

        /// <summary>
        /// the count of the items in the list
        /// </summary>
        public int Count => TranslationProvider.Count;

        /// <summary>
        /// the translation provider associated with this TranslationsGroupManager
        /// </summary>
        public IYiSoTranslationProvider TranslationProvider { get; }

        #endregion

        #region Events

        /// <summary>
        /// Event Raised when the translations Groups List changed
        /// </summary>
        public event EventHandler<TranslationsGroupsListChangedEventArgs> TranslationsGroupsListChanged;

        /// <summary>
        /// Event Raised when the Data Source Changed
        /// </summary>
        public event EventHandler<DataSourceChangedEventArgs> DataSourceChanged;

        #endregion

        #region Constructors

        /// <summary>
        /// constructor with the provider
        /// </summary>
        /// <param name="translationProvider">the translation provider</param>
        public TranslationsGroupManager(IYiSoTranslationProvider translationProvider)
        {
            TranslationProvider = translationProvider;
            TranslationProvider.TranslationsGroupsListChanged += Provider_TranslationsGroupsListChanged;
            TranslationProvider.DataSourceChanged += Provider_DataSourceChanged; ;
        }

        #endregion

        #region LookUp Methods

        /// <summary>
        /// look for a translations group in the list by name
        /// </summary>
        /// <param name="name">the name of the translations group</param>
        /// <returns>the translations Group if exist, null if nothing found</returns>
        public TranslationsGroup Find(string name)
            => TranslationProvider.Find(name);

        /// <summary>
        /// look for a translation group in the list by a predicate
        /// </summary>
        /// <param name="predicate">the predicate to look with</param>
        /// <returns>the translation Group if exist, null if nothing found</returns>
        public IEnumerable<TranslationsGroup> Find(Func<TranslationsGroup, bool> predicate)
            => TranslationProvider.Find(predicate);

        /// <summary>
        /// get the index of the given item
        /// </summary>
        /// <param name="item">the translation Group</param>
        /// <returns></returns>
        public int IndexOf(TranslationsGroup item)
            => TranslationProvider.IndexOf(item);

        /// <summary>
        /// check if there is a translationsGroup with the given name
        /// </summary>
        /// <param name="name">the name of translationsGroup</param>
        /// <returns>true if exist, false if not</returns>
        public bool IsExist(string name)
            => TranslationProvider.IsExist(name);

        /// <summary>
        /// determine whether the element exist in the list
        /// </summary>
        /// <param name="item">the TranslationsGroup to look for</param>
        /// <returns>true if exist, false if not </returns>
        public bool Contains(TranslationsGroup item)
            => TranslationProvider.Contains(item);

        #endregion

        #region Saving and reading data

        /// <summary>
        /// read translations Groups from the given file,
        /// the non existing translations will be add to the list of translation,
        /// others will be escaped
        /// </summary>
        /// <param name="file">file to read from</param>
        public void GetTranslationsFromFile(IYiSoTranslationFile file)
            => TranslationProvider.ReadFromFile(file);

        /// <summary>
        /// export the translations to the file
        /// </summary>
        /// <returns>true if the content is saved, false if any problem</returns>
        /// <exception cref="TranslationFileNotSpecifiedExceptions">if file is null or invalid</exception>
        /// <exception cref="TranslationFileMissingExceptions">if the file not exist</exception>
        /// <exception cref="NonValidTranslationFileExtensionExceptions">if the doesn't have a .json extension</exception>
        public bool SaveToFile(IYiSoTranslationFile file)
            => TranslationProvider.SaveToFile(file);

        /// <summary>
        /// export the translations to the file ASYNC
        /// </summary>
        /// <param name="file">the Translations File where to save the translations</param>
        /// <returns>true if the content is saved, false if any problem</returns>
        /// <exception cref="TranslationFileNotSpecifiedExceptions">if file is null or invalid</exception>
        /// <exception cref="TranslationFileMissingExceptions">if the file not exist</exception>
        /// <exception cref="NonValidTranslationFileExtensionExceptions">if the doesn't have a .json extension</exception>
        public async Task<bool> SaveToFileAsync(IYiSoTranslationFile file)
            => await TranslationProvider.SaveToFileAsync(file);

        /// <summary>
        /// save the translations to the dataSource
        /// </summary>
        /// <returns>true if data is saved, false if not</returns>
        public bool SaveChanges()
            => TranslationProvider.SaveChanges();
        
        /// <summary>
        /// save the translations to the dataSource
        /// </summary>
        /// <returns>true if data is saved, false if not</returns>
        public async Task<bool> SaveChangesAsync()
            => await TranslationProvider.SaveChangesAsync();

        #endregion

        #region TranslationsGroup Data Manipulation

        /// <summary>
        /// Add the translations group to the list
        /// </summary>
        /// <param name="item">translations group to be added</param>
        /// <exception cref="TranslationsGroupAlreadyExistException">if the item Already exist in the list</exception>
        public TranslationsGroup Add(TranslationsGroup item)
            => TranslationProvider.Add(item);

        /// <summary>
        /// Add the translations groups to the list
        /// </summary>
        /// <param name="translationsGroups">translation groups to be added</param>
        public void AddRange(params TranslationsGroup[] translationsGroups)
            => TranslationProvider.AddRange(translationsGroups);

        /// <summary>
        /// remove all TranslationsGroups from the list
        /// </summary>
        public void Clear()
            => TranslationProvider.Clear();

        /// <summary>
        /// Remove the translations Group from the list
        /// </summary>
        /// <param name="item">translations group to be removed</param>
        /// <returns>true if the item deleted, false if not</returns>
        /// <exception cref="TranslationsGroupNotExistException">if the translation group not exist</exception>
        public bool Remove(TranslationsGroup item)
            => Remove(item.Name);

        /// <summary>
        /// delete the translations Group from the list
        /// </summary>
        /// <param name="TranslationsGroupName">Name of translations group to be removed</param>
        /// <returns>true if the item deleted, false if not</returns>
        /// <exception cref="TranslationsGroupNotExistException">if the translations group not exist</exception>
        public bool Remove(string TranslationsGroupName)
            => TranslationProvider.Remove(TranslationsGroupName);

        /// <summary>
        /// update the old TranslationsGroup name with the new name
        /// </summary>
        /// <param name="oldTranslationsGroupName">the old translation Croup name</param>
        /// <param name="newTranslationsGroupName">the new translation Group</param>
        /// <returns>the updated TranslationsGroup</returns>
        /// <exception cref="TranslationsGroupNotExistException">If the old TranslationsGroup is not found</exception>
        /// <exception cref="TranslationsGroupAlreadyExistException">If the new TranslationsGroup is Already Exist</exception>
        public TranslationsGroup Update(string oldTranslationsGroupName, string newTranslationsGroupName)
            => TranslationProvider.Update(oldTranslationsGroupName, newTranslationsGroupName);

        /// <summary>
        /// update the old TranslationGroup name with the new name
        /// </summary>
        /// <param name="oldTranslationGroup">the old translation Croup name</param>
        /// <param name="newTranslationGroup">the new translation Group</param>
        /// <returns>the updated TranslationGroup</returns>
        public TranslationsGroup Update(TranslationsGroup oldTranslationGroup, TranslationsGroup newTranslationGroup)
            => TranslationProvider.Update(oldTranslationGroup, newTranslationGroup);

        #endregion

        #region Private methods

        private void Provider_TranslationsGroupsListChanged
            (object sender, TranslationsGroupsListChangedEventArgs e)
            => TranslationsGroupsListChanged?.Invoke(sender, e);

        private void Provider_DataSourceChanged
            (object sender, DataSourceChangedEventArgs e)
            => DataSourceChanged?.Invoke(sender, e);

        #endregion
    }
}
