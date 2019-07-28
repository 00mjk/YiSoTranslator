namespace YiSoTranslator
{
    /// <summary>
    /// a translation mast have a language and a value
    /// </summary>
    public interface ITranslation : System.IEquatable<ITranslation>
    {
        /// <summary>
        /// the language of the translations
        /// </summary>
        Language Language { get; set; }

        /// <summary>
        /// the value of the translation
        /// </summary>
        string Value { get; set; }
    }
}