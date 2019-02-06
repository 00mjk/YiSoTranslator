namespace YiSoTranslator
{
    /// <summary>
    /// List change types
    /// </summary>
    public enum ListChangedType
    {
        /// <summary>
        /// A new Item added to the list
        /// </summary>
        Add,

        /// <summary>
        /// An Item is deleted from the list
        /// </summary>
        Delete,

        /// <summary>
        /// An Item is Update in the list
        /// </summary>
        Update,

        /// <summary>
        /// all items are removed from the list
        /// </summary>
        Clear,

        /// <summary>
        /// the list is assigned to a new list
        /// </summary>
        NewRefrence,
    }
}
