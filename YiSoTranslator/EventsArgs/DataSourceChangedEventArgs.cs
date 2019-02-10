namespace YiSoTranslator
{
    /// <summary>
    /// class for defining the DataSource changed event argument
    /// </summary>
    public class DataSourceChangedEventArgs
    {
        /// <summary>
        /// type of the change
        /// </summary>
        public DataSourceChanged ChangeType { get; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="type">the type of the change</param>
        public DataSourceChangedEventArgs (DataSourceChanged type)
        {
            ChangeType = type;
        }
    }
}