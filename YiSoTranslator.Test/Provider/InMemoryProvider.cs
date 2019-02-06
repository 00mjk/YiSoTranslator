using System;
using System.Collections.Generic;

namespace YiSoTranslator.Test
{
    public class InMemoryProvider
    {
        /// <summary>
        /// the collection of translation groups
        /// </summary>
        public IList<TranslationsGroup> TranslationsGroups { get; set; }

        /// <summary>
        /// Event raised when the list is changed
        /// </summary>
        public event EventHandler<TranslationsGroupsListChangedEventArgs> ListChanged;

        /// <summary>
        /// constructor with the Translation file
        /// </summary>
        public InMemoryProvider()
        {
            GetTranslations();
        }

        /// <summary>
        /// save the changes
        /// </summary>
        /// <returns>1 if saved, -1 if any problem</returns>
        public bool SaveChanges()
        {
            return true;
        }

        /// <summary>
        /// get the list of translations from the JSON File and 
        /// populate the list property in current manager object
        /// and assign file to Translation File priority
        /// </summary>
        /// <param name="file"></param>
        public void GetTranslations()
        {
            var tg = new TranslationsGroup("Hello_text")
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Hello"))
                .Add(new Translation(Languages.Spanish_Spain.Code(), "Hola"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "مرحبا"))
                .Add(new Translation(Languages.Chinese_China.Code(), "你好"))
                .Add(new Translation(Languages.French_France.Code(), "Salut"));

            TranslationsGroups = new List<TranslationsGroup>()
            {
                tg
            };
        }

        internal void Dispose()
        {
            
        }
    }
}
