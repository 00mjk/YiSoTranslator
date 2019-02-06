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
        {
            return Language.GetByEnum(language).Code;
        }
    }
}
