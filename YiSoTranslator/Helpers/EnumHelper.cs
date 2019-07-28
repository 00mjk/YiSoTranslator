namespace YiSoTranslator
{
    /// <summary>
    /// helper class for ENUMS
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public static class EnumHelper
    {
        /// <summary>
        /// get the language code of the ENUM
        /// </summary>
        /// <param name="language">the language to get the code for</param>
        /// <returns>the language code</returns>
        public static string Code(this Languages language)
            => Language.GetByEnum(language).Code;

        /// <summary>
        /// get the language of the ENUM
        /// </summary>
        /// <param name="language">the language to get the language for</param>
        /// <returns>the language</returns>
        public static Language ToLanguage(this Languages language)
            => Language.GetByEnum(language);
    }
}
