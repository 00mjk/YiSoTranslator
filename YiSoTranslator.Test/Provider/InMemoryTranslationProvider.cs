using System;
using System.Collections.Generic;
using System.Linq;

namespace YiSoTranslator.Test
{
    public class InMemoryTranslationProvider : IYiSoTranslationProvider
    {
        #region Private fields

        private readonly InMemoryProvider _db;

        #endregion

        #region Public Prop

        /// <summary>
        /// the collection of translations
        /// </summary>
        public IEnumerable<TranslationsGroup> TranslationsGroupList
        {
            get => _db.TranslationsGroups;
        }

        /// <summary>
        /// the total number of translations in the list
        /// </summary>
        public int Count { get => _db.TranslationsGroups.Count; }

        /// <summary>
        /// event raised when the list changed
        /// </summary>
        public event EventHandler<TranslationsGroupsListChangedEventArgs> TranslationsGroupsListChanged;
        public event EventHandler<TranslationListChangedEventArgs> TranslationsListChanged;
        public event EventHandler<DataSourceChangedEventArgs> DataSourceChanged;

        #endregion

        #region Constructors

        /// <summary>
        /// constructor with Translation file
        /// </summary>
        public InMemoryTranslationProvider()
        {
            _db = new InMemoryProvider();
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
            return _db.TranslationsGroups.FirstOrDefault(t => t.Name.ToLower() == name.ToLower());
        }

        /// <summary>
        /// look for a translation group in the list by a predicate
        /// </summary>
        /// <param name="predicate">the predicate to look with</param>
        /// <returns>the list of translation Group if exist, null if nothing found</returns>
        public IEnumerable<TranslationsGroup> Find(Func<TranslationsGroup, bool> predicate)
        {
            return _db.TranslationsGroups.Where(predicate);
        }

        /// <summary>
        /// get the index of the given item
        /// </summary>
        /// <param name="item">the translation Group</param>
        /// <returns>the index</returns>
        public int IndexOf(TranslationsGroup item)
        {
            return _db.TranslationsGroups.IndexOf(item);
        }

        /// <summary>
        /// determine whether the element exist in the list
        /// </summary>
        /// <param name="item">the TranslationGroup to look for</param>
        /// <returns>true if exist, false if not </returns>
        public bool Contains(TranslationsGroup item)
        {
            return _db.TranslationsGroups.Contains(item);
        }

        #endregion

        #region Read and save data

        /// <summary>
        /// dispose the object
        /// </summary>
        public void Dispose()
        {
            _db.Dispose();
        }

        /// <summary>
        /// save the translations to the dataSource
        /// </summary>
        /// <returns>true if data is saved, false if not</returns>
        public bool SaveChanges()
        {
            return _db.SaveChanges();
        }

        #endregion

        #region DataManipilation

        /// <summary>
        /// Add the translation group to the list
        /// </summary>
        /// <param name="translationGroup">translation group to be added</param>
        /// <exception cref="TranslationGroupAlreadyExistException">if the translation group Already Exist</exception>
        public TranslationsGroup Add(TranslationsGroup translationGroup)
        {
            var tg = Find(translationGroup.Name);

            if (tg != null)
                throw new TranslationGroupAlreadyExistException(translationGroup.Name);

            _db.TranslationsGroups.Add(translationGroup);

            OnDataChanged(ListChangedType.Add, Count - 1, null, translationGroup);
            return translationGroup;
        }

        /// <summary>
        /// Add the translation groups to the list, only non existing one will be add, others will be escaped
        /// </summary>
        /// <param name="translationGroups">translation groups to be added</param>
        public void AddRange(IEnumerable<TranslationsGroup> translationGroups)
        {
            foreach (var item in translationGroups)
            {
                if (Find(item.Name) == null)
                {
                    _db.TranslationsGroups.Add(item);
                }
            }
        }

        /// <summary>
        /// update the old TranslationGroup name with the new name
        /// </summary>
        /// <param name="oldTranslationGroupName">the old translation Croup name</param>
        /// <param name="newTranslationGroupName">the new translation Group</param>
        /// <returns>the updated TranslationGroup</returns>
        /// <exception cref="TranslationGroupNotExistException">if the old translation group not exist</exception>
        /// <exception cref="TranslationGroupAlreadyExistException">if the new translation group Already exist</exception>
        public TranslationsGroup Update(string oldTranslationGroupName, string newTranslationGroupName)
        {
            var old = Find(oldTranslationGroupName)
                ?? throw new TranslationGroupNotExistException(oldTranslationGroupName);

            var newT = Find(newTranslationGroupName);

            if (!(newT is null))
                throw new TranslationGroupAlreadyExistException(newTranslationGroupName);

            old.Name = newTranslationGroupName;

            OnDataChanged(ListChangedType.Update, IndexOf(old), null, old);
            return old;
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
            var TG = Find(TranslationGroupName)
                ?? throw new TranslationGroupNotExistException(TranslationGroupName);

            _db.TranslationsGroups.Remove(TG);
            OnDataChanged(ListChangedType.Delete, Count - 1, TG, null);
            return true;
        }

        /// <summary>
        /// remove all elements from the list
        /// </summary>
        public void Clear()
        {
            _db.TranslationsGroups.Clear();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Raise the DataSourceChanged Event
        /// </summary>
        /// <param name="listChangedType">the change type</param>
        /// <param name="index">index where the change occur</param>
        /// <param name="oldRecord">the old record</param>
        /// <param name="newRecord">the new record</param>
        private void OnDataChanged(ListChangedType listChangedType, int index, TranslationsGroup oldRecord, TranslationsGroup newRecord)
        {
            TranslationsGroupsListChanged?
                .Invoke(this, new TranslationsGroupsListChangedEventArgs(listChangedType, index, oldRecord, newRecord));
        }

        public bool SaveToFile(IYiSoTranslationFile file)
        {
            return true;
        }

        public void ReadFromFile(IYiSoTranslationFile file)
        {
        }

        public bool IsExist(string name)
        {
            return _db.TranslationsGroups.Any(t => t.Name == name);
        }

        #endregion
    }
}
