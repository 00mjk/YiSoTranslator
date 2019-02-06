namespace YiSoTranslator
{
    using System;

    /// <summary>
    /// class for defining the List change event argument
    /// </summary>
    public class TranslationsGroupsListChangedEventArgs : EventArgs
    {
        /// <summary>
        /// type of the change
        /// </summary>
        public ListChangedType OperationType { get; }

        /// <summary>
        /// index of where the change occur
        /// </summary>
        public int ChangedIndex { get; }

        /// <summary>
        /// the old item in the list null in case of ADD
        /// </summary>
        public TranslationsGroup OldRecord { get; }

        /// <summary>
        /// the new item in the list, null in case of Delete and Update
        /// </summary>
        public TranslationsGroup NewRecord { get; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="type">the type of the change</param>
        /// <param name="changedIndex">index of where the change occur</param>
        /// <param name="oldRecord">the old item in the list</param>
        /// <param name="newRecord">the new item in the list</param>
        public TranslationsGroupsListChangedEventArgs
            (ListChangedType type, int changedIndex, TranslationsGroup oldRecord, TranslationsGroup newRecord)
        {
            OperationType = type;
            ChangedIndex = changedIndex;
            OldRecord = oldRecord;
            NewRecord = newRecord;
        }
    }
}