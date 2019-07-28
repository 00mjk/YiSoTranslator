namespace YiSoTranslator
{
    using System;

    /// <summary>
    /// raise this exception if no translations provider has been found
    /// </summary>
    [Serializable]
    internal class TranslationProviderNotFoundException : Exception
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public TranslationProviderNotFoundException()
        {
        }

        /// <summary>
        /// construct new <see cref="TranslationProviderNotFoundException"/> exception with the name of the provider
        /// </summary>
        /// <param name="name">the name of the provider</param>
        public TranslationProviderNotFoundException(string name) 
            : base($"there is o translations provider with the given name : {name}")
        {
        }
    }
}