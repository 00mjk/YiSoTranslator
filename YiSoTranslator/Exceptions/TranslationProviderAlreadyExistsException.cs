namespace YiSoTranslator
{
    using System;

    /// <summary>
    /// throw this exception if a Translation group Already exist
    /// </summary>
    [Serializable]
    internal class TranslationProviderAlreadyExistsException : Exception
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public TranslationProviderAlreadyExistsException()
        {
        }

        /// <summary>
        /// construct a new <see cref="TranslationsGroupAlreadyExistException"/> with the name of the provider
        /// </summary>
        /// <param name="name"></param>
        public TranslationProviderAlreadyExistsException(string name)
            : base($"a translations provider with name : {name}, Already exist")
        {
        }
    }
}