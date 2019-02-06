namespace YiSoTranslator
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// class for managing translations
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public class TranslationGroupManager
    {
        #region Public Properties

        /// <summary>
        /// list holder of Translation Groups
        /// </summary>
        public IEnumerable<TranslationsGroup> TranslationGroupsList
        {
            get => TranslationProvider.TranslationsGroupList;
        }

        /// <summary>
        /// the count of the items in the list
        /// </summary>
        public int Count => TranslationProvider.Count;

        /// <summary>
        /// the translation provider associated with this TranslationGroupManager
        /// </summary>
        public IYiSoTranslationProvider TranslationProvider { get; }

        #endregion

        #region Events

        /// <summary>
        /// Event Raised when the List of translation Groups changed
        /// </summary>
        public event EventHandler<TranslationsGroupsListChangedEventArgs> TranslationsGroupsListChanged;

        /// <summary>
        /// Event Raised when the Translations List Changed
        /// </summary>
        public event EventHandler<TranslationListChangedEventArgs> TranslationsListChanged;

        /// <summary>
        /// Event Raised when the Data Source Changed
        /// </summary>
        public event EventHandler<DataSourceChangedEventArgs> DataSourceChanged;

        #endregion

        #region Constructors

        /// <summary>
        /// initialize the provider to the given provider
        /// </summary>
        /// <param name="translationProvider"></param>
        public TranslationGroupManager(IYiSoTranslationProvider translationProvider)
        {
            TranslationProvider = translationProvider;
            TranslationProvider.TranslationsGroupsListChanged += Provider_TranslationsGroupsListChanged;
            TranslationProvider.TranslationsListChanged += Provider_TranslationsListChanged;
            TranslationProvider.DataSourceChanged += Provider_DataSourceChanged; ;
        }

        #endregion

        #region LookUp Methods

        /// <summary>
        /// look for a translation group in the list by name
        /// </summary>
        /// <param name="name">the name of the translation group</param>
        /// <returns>the translation Group if exist, null if nothing found</returns>
        public TranslationsGroup Find(string name)
        {
            return TranslationProvider.Find(name);
        }

        /// <summary>
        /// look for a translation group in the list by a predicate
        /// </summary>
        /// <param name="predicate">the predicate to look with</param>
        /// <returns>the translation Group if exist, null if nothing found</returns>
        public IEnumerable<TranslationsGroup> Find(Func<TranslationsGroup, bool> predicate)
        {
            return TranslationProvider.Find(predicate);
        }

        /// <summary>
        /// get the index of the given item
        /// </summary>
        /// <param name="item">the translation Group</param>
        /// <returns></returns>
        public int IndexOf(TranslationsGroup item)
        {
            return TranslationProvider.IndexOf(item);
        }

        #endregion

        #region TranslationGroup Data Manipulation

        #region Saving and reading data

        /// <summary>
        /// read translation from the given file,
        /// the non existing translations will be add to the list of translation,
        /// others will be escaped
        /// </summary>
        /// <param name="file">file to read from</param>
        public void GetTranslationsFromFile(IYiSoTranslationFile file)
        {
            TranslationProvider.ReadFromFile(file);
        }

        /// <summary>
        /// export the translations to the file ASYNC
        /// </summary>
        /// <param name="file">the Translation File where to save the translations</param>
        /// <returns>true if the content is saved, false if any problem</returns>
        /// <exception cref="TranslationFileNotSpecifiedExceptions">if file is null or invalid</exception>
        /// <exception cref="TranslationFileMissingExceptions">if the file not exist</exception>
        /// <exception cref="NonValidTranslationFileExtensionExceptions">if the doesn't have a .json extension</exception>
        public async Task<bool> SaveToFileAsync(IYiSoTranslationFile file)
        {
            return await Task.Run(() =>
            {
                return SaveToFile(file);
            });
        }

        /// <summary>
        /// export the translations to the file
        /// </summary>
        /// <returns>true if the content is saved, false if any problem</returns>
        /// <exception cref="TranslationFileNotSpecifiedExceptions">if file is null or invalid</exception>
        /// <exception cref="TranslationFileMissingExceptions">if the file not exist</exception>
        /// <exception cref="NonValidTranslationFileExtensionExceptions">if the doesn't have a .json extension</exception>
        public bool SaveToFile(IYiSoTranslationFile file)
        {
            return TranslationProvider.SaveToFile(file);
        }

        /// <summary>
        /// save the translations to the dataSource
        /// </summary>
        /// <returns>true if data is saved, false if not</returns>
        public bool SaveChanges()
        {
            return TranslationProvider.SaveChanges();
        }

        #endregion

        /// <summary>
        /// Add the translation group to the list
        /// </summary>
        /// <param name="item">translation group to be added</param>
        /// <exception cref="TranslationGroupAlreadyExistException">if the item Already exist in the list</exception>
        public TranslationsGroup Add(TranslationsGroup item)
        {
            return TranslationProvider.Add(item);
        }

        /// <summary>
        /// remove all elements from the list
        /// </summary>
        public void Clear()
        {
            TranslationProvider.Clear();
        }

        /// <summary>
        /// determine whether the element exist in the list
        /// </summary>
        /// <param name="item">the TranslationGroup to look for</param>
        /// <returns>true if exist, false if not </returns>
        public bool Contains(TranslationsGroup item)
        {
            return TranslationProvider.Contains(item);
        }

        /// <summary>
        /// delete the translations Group from the list
        /// </summary>
        /// <param name="item">translation group to be removed</param>
        /// <returns>true if the item deleted, false if not</returns>
        /// <exception cref="TranslationGroupNotExistException">if the translation group not exist</exception>
        public bool Remove(TranslationsGroup item)
        {
            return Remove(item.Name);
        }

        /// <summary>
        /// delete the translations Group from the list
        /// </summary>
        /// <param name="TranslationGroupName">Name of translation group to be removed</param>
        /// <returns>true if the item deleted, false if not</returns>
        /// <exception cref="TranslationGroupNotExistException">if the translation group not exist</exception>
        public bool Remove(string TranslationGroupName)
        {
            return TranslationProvider.Remove(TranslationGroupName);
        }

        /// <summary>
        /// update the old TranslationGroup name with the new name
        /// </summary>
        /// <param name="oldTranslationGroupName">the old translation Croup name</param>
        /// <param name="newTranslationGroupName">the new translation Group</param>
        /// <returns>the updated TranslationGroup</returns>
        /// <exception cref="TranslationGroupNotExistException">If the old translationGroup is not found</exception>
        /// <exception cref="TranslationGroupAlreadyExistException">If the new translationGroup is Already Exist</exception>
        public TranslationsGroup Update(string oldTranslationGroupName, string newTranslationGroupName)
        {
            return TranslationProvider.Update(oldTranslationGroupName, newTranslationGroupName);
        }

        #endregion

        #region Private methods

        private void Provider_TranslationsGroupsListChanged
            (object sender, TranslationsGroupsListChangedEventArgs e)
            => TranslationsGroupsListChanged?.Invoke(sender, e);

        private void Provider_DataSourceChanged
            (object sender, DataSourceChangedEventArgs e)
            => DataSourceChanged?.Invoke(sender, e);

        private void Provider_TranslationsListChanged
            (object sender, TranslationListChangedEventArgs e)
            => TranslationsListChanged?.Invoke(sender, e);

        #endregion
    }
}
