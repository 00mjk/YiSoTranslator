namespace YiSoTranslator
{
    /// <summary>
    /// class for defining the Translation List change event argument
    /// </summary>
    public class TranslationListChangedEventArgs
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
        public Translation OldTranslation { get; }

        /// <summary>
        /// the new item in the list, null in case of Delete and Update
        /// </summary>
        public Translation NewTranslation { get; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="type">the type of the change</param>
        /// <param name="changedIndex">index of where the change occur</param>
        /// <param name="oldTranslation">the old item in the list</param>
        /// <param name="newTranslation">the new item in the list</param>
        public TranslationListChangedEventArgs
            (ListChangedType type, int changedIndex, Translation oldTranslation, Translation newTranslation)
        {
            OperationType = type;
            ChangedIndex = changedIndex;
            OldTranslation = oldTranslation;
            NewTranslation = newTranslation;
        }
    }
}