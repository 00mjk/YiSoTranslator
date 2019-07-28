namespace YiSoTranslator
{
    /// <summary>
    /// class for defining the Translations List change event argument
    /// </summary>
    public class TranslationsListChangedEventArgs
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
        public ITranslation OldTranslation { get; }

        /// <summary>
        /// the new item in the list, null in case of Delete
        /// </summary>
        public ITranslation NewTranslation { get; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="type">the type of the change</param>
        /// <param name="changedIndex">index of where the change occur</param>
        /// <param name="oldTranslation">the old item in the list</param>
        /// <param name="newTranslation">the new item in the list</param>
        public TranslationsListChangedEventArgs
            (ListChangedType type, int changedIndex, ITranslation oldTranslation, ITranslation newTranslation)
        {
            OperationType = type;
            ChangedIndex = changedIndex;
            OldTranslation = oldTranslation;
            NewTranslation = newTranslation;
        }
    }
}