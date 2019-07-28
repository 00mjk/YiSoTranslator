using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YiSoTranslator.Test
{
    public class InMemoryTranslationProvider : IYiSoTranslationsProvider
    {
        private readonly InMemoryProvider _db;
        private bool _unsavedChanges;

        #region Public Prop

        public IEnumerable<ITranslationsGroup> TranslationsGroupsList
             => _db.TranslationsGroups;

        public int Count => _db.TranslationsGroups.Count;

        public string Name => "InMemoryProvider";

        public event EventHandler<TranslationsGroupsListChangedEventArgs> TranslationsGroupsListChanged;

        public event EventHandler<DataSourceChangedEventArgs> DataSourceChanged;

        #endregion

        #region Constructors

        public InMemoryTranslationProvider()
        {
            _db = new InMemoryProvider();
            _unsavedChanges = false;
        }

        #endregion

        #region LookUp Methods

        /// <summary>
        /// look for a translation group in the list by name
        /// </summary>
        /// <param name="name">the name of the translation group</param>
        /// <returns>the translation Group if exist, null if nothing found</returns>
        public ITranslationsGroup Find(string name)
        {
            return _db.TranslationsGroups.FirstOrDefault(t => t.Name.ToLower() == name.ToLower());
        }

        /// <summary>
        /// look for a translation group in the list by a predicate
        /// </summary>
        /// <param name="predicate">the predicate to look with</param>
        /// <returns>the list of translation Group if exist, null if nothing found</returns>
        public IEnumerable<ITranslationsGroup> Find(Func<ITranslationsGroup, bool> predicate)
        {
            return _db.TranslationsGroups.Where(predicate);
        }

        /// <summary>
        /// get the index of the given item
        /// </summary>
        /// <param name="item">the translation Group</param>
        /// <returns>the index</returns>
        public int IndexOf(ITranslationsGroup item)
        {
            return _db.TranslationsGroups.IndexOf(item);
        }

        /// <summary>
        /// determine whether the element exist in the list
        /// </summary>
        /// <param name="item">the TranslationGroup to look for</param>
        /// <returns>true if exist, false if not </returns>
        public bool Contains(ITranslationsGroup item)
        {
            return _db.TranslationsGroups.Contains(item);
        }

        #endregion

        #region Read and save data

        /// <summary>
        /// save the translations to the dataSource
        /// </summary>
        /// <returns>true if data is saved, false if not</returns>
        public bool SaveChanges()
        {
            _unsavedChanges = false;
            return _db.SaveChanges();
        }

        #endregion

        #region DataManipilation

        /// <summary>
        /// Add the translation group to the list
        /// </summary>
        /// <param name="translationGroup">translation group to be added</param>
        /// <exception cref="TranslationGroupAlreadyExistException">if the translation group Already Exist</exception>
        public ITranslationsGroup Add(ITranslationsGroup translationGroup)
        {
            var tg = Find(translationGroup.Name);

            if (tg != null)
                throw new TranslationsGroupAlreadyExistException(translationGroup.Name);

            _db.TranslationsGroups.Add(translationGroup);


            OnDataChanged(ListChangedType.Add, Count - 1, null, translationGroup);
            return translationGroup;
        }

        /// <summary>
        /// Add the translation groups to the list, only non existing one will be add, others will be escaped
        /// </summary>
        /// <param name="translationGroups">translation groups to be added</param>
        public void AddRange(params ITranslationsGroup[] translationGroups)
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
        public ITranslationsGroup Update(string oldTranslationGroupName, string newTranslationGroupName)
        {
            var old = Find(oldTranslationGroupName)
                ?? throw new TranslationsGroupNotExistException(oldTranslationGroupName);

            var newT = Find(newTranslationGroupName);

            if (!(newT is null))
                throw new TranslationsGroupAlreadyExistException(newTranslationGroupName);

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
        public bool Remove(ITranslationsGroup item)
            => Remove(item.Name);

        /// <summary>
        /// delete the translations Group from the list
        /// </summary>
        /// <param name="TranslationGroupName">Name of translation group to be removed</param>
        /// <returns>true if the item deleted, false if not</returns>
        /// <exception cref="TranslationGroupNotExistException">if the translation group not exist</exception>
        public bool Remove(string TranslationGroupName)
        {
            var TG = Find(TranslationGroupName)
                ?? throw new TranslationsGroupNotExistException(TranslationGroupName);

            _db.TranslationsGroups.Remove(TG);
            OnDataChanged(ListChangedType.Delete, Count - 1, TG, null);
            return true;
        }

        /// <summary>
        /// remove all elements from the list
        /// </summary>
        public void Clear()
            => _db.TranslationsGroups.Clear();

        #endregion

        #region Private Methods

        /// <summary>
        /// Raise the DataSourceChanged Event
        /// </summary>
        /// <param name="listChangedType">the change type</param>
        /// <param name="index">index where the change occur</param>
        /// <param name="oldRecord">the old record</param>
        /// <param name="newRecord">the new record</param>
        private void OnDataChanged(ListChangedType listChangedType, int index, ITranslationsGroup oldRecord, ITranslationsGroup newRecord)
        {
            _unsavedChanges = true;
            TranslationsGroupsListChanged?
                .Invoke(this, new TranslationsGroupsListChangedEventArgs(listChangedType, index, oldRecord, newRecord));
        }

        public bool IsExist(string name)
            => _db.TranslationsGroups.Any(t => t.Name == name);

        public ITranslationsGroup Update(ITranslationsGroup oldTranslationGroup, ITranslationsGroup newTranslationGroup)
        {
            var old = Find(oldTranslationGroup.Name)
                ?? throw new TranslationsGroupNotExistException(oldTranslationGroup.Name);

            var newT = Find(newTranslationGroup.Name);

            if (!(newT is null))
                throw new TranslationsGroupAlreadyExistException(newTranslationGroup.Name);

            _db.TranslationsGroups[IndexOf(old)] = newTranslationGroup;

            OnDataChanged(ListChangedType.Update, IndexOf(old), old, newTranslationGroup);
            return old;
        }

        public Task<bool> SaveChangesAsync()
            => Task.Run(() => SaveChanges());

        public void Reload(bool discardChanges = false)
        {
            if (_unsavedChanges && !discardChanges)
                throw new UnsavedChangesExceptions();

            _db.Reload();
        }

        public ITranslationsGroup Update(ITranslationsGroup newTranslationGroup)
        {
            var old = Find(newTranslationGroup.Name)
                ?? throw new TranslationsGroupNotExistException(newTranslationGroup.Name);

            _db.TranslationsGroups[IndexOf(old)] = newTranslationGroup;

            OnDataChanged(ListChangedType.Update, IndexOf(old), old, newTranslationGroup);
            return old;
        }

        #endregion
    }
}
