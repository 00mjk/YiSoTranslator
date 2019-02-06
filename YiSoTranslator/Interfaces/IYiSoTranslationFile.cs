namespace YiSoTranslator
{
    /// <summary>
    /// defines the translation file
    /// </summary>
    public interface IYiSoTranslationFile
    {
        /// <summary>
        /// the name of the file, with extension (ex: main.json)
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// the full name of the file
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// the type of the file
        /// </summary>
        FileType Type { get; }
    }
}
