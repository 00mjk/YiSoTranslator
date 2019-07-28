namespace YiSoTranslator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A struct that represent the language and give the list of the supported languages it cannot be instantiated,
    /// use the static methods <see cref="GetByCode(string)"/>, <see cref="GetByEnum(Languages)"/> or <see cref="GetByName(string)"/> to get the desired language.
    /// in case of a look up using one of the previous method check if the returned <see cref="Language"/> value has a default value with <see cref="HasDefaultValue"/>
    /// if it has a default value that means it not a valid
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public partial struct Language : IEquatable<Language>
    {
        /// <summary>
        /// the language code presented by Microsoft
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// the full name of the language
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// get the mode of the language, RTL or LTR
        /// </summary>
        public LanguageMode Mode { get; }

        /// <summary>
        /// default constructor with the Code, the name and the mode of the language
        /// </summary>
        private Language(string name, string code, LanguageMode mode)
        {
            Code = code;
            Name = name;
            Mode = mode;
        }

        /// <summary>
        /// determine if the given language has a default value
        /// </summary>
        /// <param name="language">the language to check</param>
        /// <returns>true if it has the default value false if not</returns>
        public bool HasDefaultValue()
            => HasDefaultValue(this);

        /// <summary>
        /// get the ENUM value of the current language objects
        /// </summary>
        /// <returns></returns>
        public Languages EnumVal()
        {
            switch (Code)
            {
                case "sq-AL": return Languages.Albanian_Albania;
                case "ar-DZ": return Languages.Arabic_Algeria;
                case "ar-BH": return Languages.Arabic_Bahrain;
                case "ar-EG": return Languages.Arabic_Egypt;
                case "ar-IQ": return Languages.Arabic_Iraq;
                case "ar-JO": return Languages.Arabic_Jordan;
                case "ar-KW": return Languages.Arabic_Kuwait;
                case "ar-LB": return Languages.Arabic_Lebanon;
                case "ar-LY": return Languages.Arabic_Libya;
                case "ar-MA": return Languages.Arabic_Morocco;
                case "ar-OM": return Languages.Arabic_Oman;
                case "ar-QA": return Languages.Arabic_Qatar;
                case "ar-SA": return Languages.Arabic_SaudiArabia;
                case "ar-SY": return Languages.Arabic_Syria;
                case "ar-TN": return Languages.Arabic_Tunisia;
                case "ar-AE": return Languages.Arabic_UnitedArabEmirates;
                case "ar-YE": return Languages.Arabic_Yemen;
                case "hy-AM": return Languages.Armenian_Armenia;
                case "Cy-az-AZ": return Languages.AzeriCyrillic_Azerbaijan;
                case "Lt-az-AZ": return Languages.AzeriLatin_Azerbaijan;
                case "eu-ES": return Languages.Basque_Basque;
                case "be-BY": return Languages.Belarusian_Belarus;
                case "bg-BG": return Languages.Bulgarian_Bulgaria;
                case "ca-ES": return Languages.Catalan_Catalan;
                case "zh-CN": return Languages.Chinese_China;
                case "zh-HK": return Languages.Chinese_HongKongSAR;
                case "zh-MO": return Languages.Chinese_MacauSAR;
                case "zh-SG": return Languages.Chinese_Singapore;
                case "zh-TW": return Languages.Chinese_Taiwan;
                case "zh-CHS": return Languages.Chinese_Simplified;
                case "zh-CHT": return Languages.Chinese_Traditional;
                case "hr-HR": return Languages.Croatian_Croatia;
                case "cs-CZ": return Languages.Czech_CzechRepublic;
                case "da-DK": return Languages.Danish_Denmark;
                case "div-MV": return Languages.Dhivehi_Maldives;
                case "nl-BE": return Languages.Dutch_Belgium;
                case "nl-NL": return Languages.Dutch_TheNetherlands;
                case "en-AU": return Languages.English_Australia;
                case "en-BZ": return Languages.English_Belize;
                case "en-CA": return Languages.English_Canada;
                case "en-CB": return Languages.English_Caribbean;
                case "en-IE": return Languages.English_Ireland;
                case "en-JM": return Languages.English_Jamaica;
                case "en-NZ": return Languages.English_NewZealand;
                case "en-PH": return Languages.English_Philippines;
                case "en-ZA": return Languages.English_SouthAfrica;
                case "en-TT": return Languages.English_TrinidadAndTobago;
                case "en-GB": return Languages.English_UnitedKingdom;
                case "en-US": return Languages.English_UnitedStates;
                case "en-ZW": return Languages.English_Zimbabwe;
                case "et-EE": return Languages.Estonian_Estonia;
                case "fo-FO": return Languages.Faroese_FaroeIslands;
                case "fa-IR": return Languages.Farsi_Iran;
                case "fi-FI": return Languages.Finnish_Finland;
                case "fr-BE": return Languages.French_Belgium;
                case "fr-CA": return Languages.French_Canada;
                case "fr-FR": return Languages.French_France;
                case "fr-LU": return Languages.French_Luxembourg;
                case "fr-MC": return Languages.French_Monaco;
                case "fr-CH": return Languages.French_Switzerland;
                case "gl-ES": return Languages.Galician_Galician;
                case "ka-GE": return Languages.Georgian_Georgia;
                case "de-AT": return Languages.German_Austria;
                case "de-DE": return Languages.German_Germany;
                case "de-LI": return Languages.German_Liechtenstein;
                case "de-LU": return Languages.German_Luxembourg;
                case "de-CH": return Languages.German_Switzerland;
                case "el-GR": return Languages.Greek_Greece;
                case "hi-IN": return Languages.Gujarati_India;
                case "he-IL": return Languages.Hindi_India;
                case "hu-HU": return Languages.Hungarian_Hungary;
                case "is-IS": return Languages.Icelandic_Iceland;
                case "id-ID": return Languages.Indonesian_Indonesia;
                case "it-IT": return Languages.Italian_Italy;
                case "it-CH": return Languages.Italian_Switzerland;
                case "ja-JP": return Languages.Japanese_Japan;
                case "kn-IN": return Languages.Kannada_India;
                case "kk-KZ": return Languages.Kazakh_Kazakhstan;
                case "kok-IN": return Languages.Konkani_India;
                case "ko-KR": return Languages.Korean_Korea;
                case "ky-KZ": return Languages.Kyrgyz_Kazakhstan;
                case "lv-LV": return Languages.Latvian_Latvia;
                case "lt-LT": return Languages.Lithuanian_Lithuania;
                case "mk-MK": return Languages.Macedonian_FYROM;
                case "ms-BN": return Languages.Malay_Brunei;
                case "ms-MY": return Languages.Malay_Malaysia;
                case "mr-IN": return Languages.Marathi_India;
                case "mn-MN": return Languages.Mongolian_Mongolia;
                case "nb-NO": return Languages.NorwegianBokmål_Norway;
                case "nn-NO": return Languages.NorwegianNynorsk_Norway;
                case "pl-PL": return Languages.Polish_Poland;
                case "pt-BR": return Languages.Portuguese_Brazil;
                case "pt-PT": return Languages.Portuguese_Portugal;
                case "pa-IN": return Languages.Punjabi_India;
                case "ro-RO": return Languages.Romanian_Romania;
                case "ru-RU": return Languages.Russian_Russia;
                case "sa-IN": return Languages.Sanskrit_India;
                case "Cy-sr-SP": return Languages.SerbianCyrillic_Serbia;
                case "Lt-sr-SP": return Languages.SerbianLatin_Serbia;
                case "sk-SK": return Languages.Slovak_Slovakia;
                case "sl-SI": return Languages.Slovenian_Slovenia;
                case "es-AR": return Languages.Spanish_Argentina;
                case "es-BO": return Languages.Spanish_Bolivia;
                case "es-CL": return Languages.Spanish_Chile;
                case "es-CO": return Languages.Spanish_Colombia;
                case "es-CR": return Languages.Spanish_CostaRica;
                case "es-DO": return Languages.Spanish_DominicanRepublic;
                case "es-EC": return Languages.Spanish_Ecuador;
                case "es-SV": return Languages.Spanish_ElSalvador;
                case "es-GT": return Languages.Spanish_Guatemala;
                case "es-HN": return Languages.Spanish_Honduras;
                case "es-MX": return Languages.Spanish_Mexico;
                case "es-NI": return Languages.Spanish_Nicaragua;
                case "es-PA": return Languages.Spanish_Panama;
                case "es-PY": return Languages.Spanish_Paraguay;
                case "es-PE": return Languages.Spanish_Peru;
                case "es-PR": return Languages.Spanish_PuertoRico;
                case "es-ES": return Languages.Spanish_Spain;
                case "es-UY": return Languages.Spanish_Uruguay;
                case "es-VE": return Languages.Spanish_Venezuela;
                case "sw-KE": return Languages.Swahili_Kenya;
                case "sv-FI": return Languages.Swedish_Finland;
                case "sv-SE": return Languages.Swedish_Sweden;
                case "syr-SY": return Languages.Syriac_Syria;
                case "ta-IN": return Languages.Tami_India;
                case "tt-RU": return Languages.Tata_Russia;
                case "te-IN": return Languages.Telugu_India;
                case "th-TH": return Languages.Thai_Thailand;
                case "tr-TR": return Languages.Turkish_Turkey;
                case "uk-UA": return Languages.Ukrainian_Ukraine;
                case "ur-PK": return Languages.Urdu_Pakistan;
                case "Cy-uz-UZ": return Languages.UzbekCyrillic_Uzbekistan;
                case "Lt-uz-UZ": return Languages.UzbekLatin_Uzbekistan;
                case "vi-VN": return Languages.Vietnamese_Vietnam;
                default: return Languages.English_UnitedStates;
            }
        }

        #region Overrides

        /// <summary>
        /// check if the given object is equal to this instant
        /// </summary>
        /// <param name="obj">the object to compare to</param>
        /// <returns>true if equals</returns>
        public override bool Equals(object obj)
            => Equals(obj);

        /// <summary>
        /// check if the given language is equal to this instant
        /// we compare the name and the language code
        /// </summary>
        /// <param name="language">the language to compare to</param>
        /// <returns>true if equals</returns>
        public bool Equals(Language language)
            => !language.HasDefaultValue() && Code == language.Code && Name == language.Name;

        /// <summary>
        /// get the HashCode
        /// </summary>
        /// <returns>the HashCode</returns>
        public override int GetHashCode()
        {
            var hashCode = -168117446;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Code);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }

        /// <summary>
        /// get the string Representation of the object
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
            => HasDefaultValue() ? "default" : $"Name : {Name}, Code : {Code}, Mode : {Mode}";

        /// <summary>
        /// implement the equality operator
        /// </summary>
        /// <param name="language1"></param>
        /// <param name="language2"></param>
        /// <returns>true if equals</returns>
        public static bool operator ==(Language language1, Language language2)
            => EqualityComparer<Language>.Default.Equals(language1, language2);

        /// <summary>
        /// implement the non equality operator
        /// </summary>
        /// <param name="language1"></param>
        /// <param name="language2"></param>
        /// <returns>true not equals</returns>
        public static bool operator !=(Language language1, Language language2)
            => !(language1 == language2);

        /// <summary>
        /// implement the equality operator
        /// </summary>
        /// <param name="language1"></param>
        /// <param name="language2"></param>
        /// <returns>true if equals</returns>
        public static bool operator ==(Language language1, string languageCode)
        {
            var language2 = GetByCode(languageCode);

            if (language2.HasDefaultValue())
                throw new InvalidLanguageCode("the given language code is not valid, language not exist");

            return EqualityComparer<Language>.Default.Equals(language1, language2);
        }

        /// <summary>
        /// implement the non equality operator
        /// </summary>
        /// <param name="language1"></param>
        /// <param name="language2"></param>
        /// <returns>true not equals</returns>
        public static bool operator !=(Language language1, string languageCode)
            => !(language1 == languageCode);

        #endregion

        #region implicit

        /// <summary>
        /// convert the language into a language code string
        /// </summary>
        /// <param name="language">the language to convert</param>
        public static implicit operator string(Language language)
        {
            if (language.HasDefaultValue())
                throw new InvalidLanguage("the given language instant doesn't have a value");

            return language.Code;
        }

        /// <summary>
        /// convert a language code given as string to a language
        /// </summary>
        /// <param name="langaugeCode">the code to get the language form it</param>
        public static implicit operator Language(string langaugeCode)
        {
            var language = GetByCode(langaugeCode);

            if (language.HasDefaultValue())
                throw new InvalidLanguageCode(langaugeCode);

            return language;
        }
        
        #endregion
    }

    /// <summary>
    /// the partial part of the <see cref="Language"/> that hold all the static functionalities
    /// </summary>
    public partial struct Language
    {
        #region Private static members

        private static Language _currentLanguage;

        private static Language _defaultLanguage;

        private static readonly IEnumerable<Language> _languagesList;

        static Language()
        {
            _languagesList = new HashSet<Language>
            {
                new Language( name : "Albanian_Albania", code : "sq-AL", mode: LanguageMode.LTR),
                new Language( name : "Arabic_Algeria", code : "ar-DZ", mode: LanguageMode.RTL),
                new Language( name : "Arabic_Bahrain", code : "ar-BH", mode: LanguageMode.RTL ),
                new Language( name : "Arabic_Egypt", code : "ar-EG", mode: LanguageMode.RTL ),
                new Language( name : "Arabic_Iraq", code : "ar-IQ", mode: LanguageMode.RTL ),
                new Language( name : "Arabic_Jordan", code : "ar-JO", mode: LanguageMode.RTL ),
                new Language( name : "Arabic_Kuwait", code : "ar-KW", mode: LanguageMode.RTL ),
                new Language( name : "Arabic_Lebanon", code : "ar-LB", mode: LanguageMode.RTL ),
                new Language( name : "Arabic_Libya", code : "ar-LY", mode: LanguageMode.RTL ),
                new Language( name : "Arabic_Morocco", code : "ar-MA" , mode: LanguageMode.RTL),
                new Language( name : "Arabic_Oman", code : "ar-OM" , mode: LanguageMode.RTL),
                new Language( name : "Arabic_Qatar", code : "ar-QA" , mode: LanguageMode.RTL),
                new Language( name : "Arabic_SaudiArabia", code : "ar-SA" , mode: LanguageMode.RTL),
                new Language( name : "Arabic_Syria", code : "ar-SY" , mode: LanguageMode.RTL),
                new Language( name : "Arabic_Tunisia", code : "ar-TN" , mode: LanguageMode.RTL),
                new Language( name : "Arabic_UnitedArabEmirates", code : "ar-AE" , mode: LanguageMode.RTL),
                new Language( name : "Arabic_Yemen", code : "ar-YE" , mode: LanguageMode.RTL),
                new Language( name : "Armenian_Armenia", code : "hy-AM" , mode: LanguageMode.LTR),
                new Language( name : "AzeriCyrillic_Azerbaijan", code : "Cy-az-AZ" , mode: LanguageMode.RTL),
                new Language( name : "AzeriLatin_Azerbaijan", code : "Lt-az-AZ" , mode: LanguageMode.RTL),
                new Language( name : "Basque_Basque", code : "eu-ES" , mode: LanguageMode.LTR),
                new Language( name : "Belarusian_Belarus", code : "be-BY" , mode: LanguageMode.LTR),
                new Language( name : "Bulgarian_Bulgaria", code : "bg-BG" , mode: LanguageMode.LTR),
                new Language( name : "Catalan_Catalan", code : "ca-ES" , mode: LanguageMode.LTR),
                new Language( name : "Chinese_China", code : "zh-CN" , mode: LanguageMode.LTR),
                new Language( name : "Chinese_HongKongSAR", code : "zh-HK" , mode: LanguageMode.LTR),
                new Language( name : "Chinese_MacauSAR", code : "zh-MO" , mode: LanguageMode.LTR),
                new Language( name : "Chinese_Singapore", code : "zh-SG" , mode: LanguageMode.LTR),
                new Language( name : "Chinese_Taiwan", code : "zh-TW" , mode: LanguageMode.LTR),
                new Language( name : "Chinese_Simplified", code : "zh-CHS" , mode: LanguageMode.LTR),
                new Language( name : "Chinese_Traditional", code : "zh-CHT" , mode: LanguageMode.LTR),
                new Language( name : "Croatian_Croatia", code : "hr-HR" , mode: LanguageMode.LTR),
                new Language( name : "Czech_CzechRepublic", code : "cs-CZ" , mode: LanguageMode.LTR),
                new Language( name : "Danish_Denmark", code : "da-DK" , mode: LanguageMode.LTR),
                new Language( name : "Dhivehi_Maldives", code : "div-MV" , mode: LanguageMode.RTL),
                new Language( name : "Dutch_Belgium", code : "nl-BE" , mode: LanguageMode.LTR),
                new Language( name : "Dutch_TheNetherlands", code : "nl-NL" , mode: LanguageMode.LTR),
                new Language( name : "English_Australia", code : "en-AU" , mode: LanguageMode.LTR),
                new Language( name : "English_Belize", code : "en-BZ" , mode: LanguageMode.LTR),
                new Language( name : "English_Canada", code : "en-CA" , mode: LanguageMode.LTR),
                new Language( name : "English_Caribbean", code : "en-CB" , mode: LanguageMode.LTR),
                new Language( name : "English_Ireland", code : "en-IE" , mode: LanguageMode.LTR),
                new Language( name : "English_Jamaica", code : "en-JM" , mode: LanguageMode.LTR),
                new Language( name : "English_NewZealand", code : "en-NZ" , mode: LanguageMode.LTR),
                new Language( name : "English_Philippines", code : "en-PH" , mode: LanguageMode.LTR),
                new Language( name : "English_SouthAfrica", code : "en-ZA" , mode: LanguageMode.LTR),
                new Language( name : "English_TrinidadAndTobago", code : "en-TT" , mode: LanguageMode.LTR),
                new Language( name : "English_UnitedKingdom", code : "en-GB" , mode: LanguageMode.LTR),
                new Language( name : "English_UnitedStates", code : "en-US" , mode: LanguageMode.LTR),
                new Language( name : "English_Zimbabwe", code : "en-ZW" , mode: LanguageMode.LTR),
                new Language( name : "Estonian_Estonia", code : "et-EE" , mode: LanguageMode.LTR),
                new Language( name : "Faroese_FaroeIslands", code : "fo-FO" , mode: LanguageMode.LTR),
                new Language( name : "Farsi_Iran", code : "fa-IR" , mode: LanguageMode.RTL),
                new Language( name : "Finnish_Finland", code : "fi-FI" , mode: LanguageMode.LTR),
                new Language( name : "French_Belgium", code : "fr-BE" , mode: LanguageMode.LTR),
                new Language( name : "French_Canada", code : "fr-CA" , mode: LanguageMode.LTR),
                new Language( name : "French_France", code : "fr-FR" , mode: LanguageMode.LTR),
                new Language( name : "French_Luxembourg", code : "fr-LU" , mode: LanguageMode.LTR),
                new Language( name : "French_Monaco", code : "fr-MC" , mode: LanguageMode.LTR),
                new Language( name : "French_Switzerland", code : "fr-CH" , mode: LanguageMode.LTR),
                new Language( name : "Galician_Galician", code : "gl-ES" , mode: LanguageMode.LTR),
                new Language( name : "Georgian_Georgia", code : "ka-GE" , mode: LanguageMode.LTR),
                new Language( name : "German_Austria", code : "de-AT" , mode: LanguageMode.LTR),
                new Language( name : "German_Germany", code : "de-DE" , mode: LanguageMode.LTR),
                new Language( name : "German_Liechtenstein", code : "de-LI" , mode: LanguageMode.LTR),
                new Language( name : "German_Luxembourg", code : "de-LU" , mode: LanguageMode.LTR),
                new Language( name : "German_Switzerland", code : "de-CH" , mode: LanguageMode.LTR),
                new Language( name : "Greek_Greece", code : "el-GR" , mode: LanguageMode.LTR),
                new Language( name : "Gujarati_India", code : "hi-IN" , mode: LanguageMode.LTR),
                new Language( name : "Hindi_India", code : "he-IL" , mode: LanguageMode.LTR),
                new Language( name : "Hungarian_Hungary", code : "hu-HU" , mode: LanguageMode.LTR),
                new Language( name : "Icelandic_Iceland", code : "is-IS" , mode: LanguageMode.LTR),
                new Language( name : "Indonesian_Indonesia", code : "id-ID" , mode: LanguageMode.LTR),
                new Language( name : "Italian_Italy", code : "it-IT" , mode: LanguageMode.LTR),
                new Language( name : "Italian_Switzerland", code : "it-CH" , mode: LanguageMode.LTR),
                new Language( name : "Japanese_Japan", code : "ja-JP" , mode: LanguageMode.LTR),
                new Language( name : "Kannada_India", code : "kn-IN" , mode: LanguageMode.LTR),
                new Language( name : "Kazakh_Kazakhstan", code : "kk-KZ" , mode: LanguageMode.RTL),
                new Language( name : "Konkani_India", code : "kok-IN" , mode: LanguageMode.LTR),
                new Language( name : "Korean_Korea", code : "ko-KR" , mode: LanguageMode.LTR),
                new Language( name : "Kyrgyz_Kazakhstan", code : "ky-KZ" , mode: LanguageMode.RTL),
                new Language( name : "Latvian_Latvia", code : "lv-LV" , mode: LanguageMode.LTR),
                new Language( name : "Lithuanian_Lithuania", code : "lt-LT" , mode: LanguageMode.LTR),
                new Language( name : "Macedonian_FYROM", code : "mk-MK" , mode: LanguageMode.LTR),
                new Language( name : "Malay_Brunei", code : "ms-BN" , mode: LanguageMode.RTL),
                new Language( name : "Malay_Malaysia", code : "ms-MY" , mode: LanguageMode.RTL),
                new Language( name : "Marathi_India", code : "mr-IN" , mode: LanguageMode.LTR),
                new Language( name : "Mongolian_Mongolia", code : "mn-MN" , mode: LanguageMode.LTR),
                new Language( name : "NorwegianBokmål_Norway", code : "nb-NO" , mode: LanguageMode.LTR),
                new Language( name : "NorwegianNynorsk_Norway", code : "nn-NO" , mode: LanguageMode.LTR),
                new Language( name : "Polish_Poland", code : "pl-PL" , mode: LanguageMode.LTR),
                new Language( name : "Portuguese_Brazil", code : "pt-BR" , mode: LanguageMode.LTR),
                new Language( name : "Portuguese_Portugal", code : "pt-PT" , mode: LanguageMode.LTR),
                new Language( name : "Punjabi_India", code : "pa-IN" , mode: LanguageMode.RTL),
                new Language( name : "Romanian_Romania", code : "ro-RO" , mode: LanguageMode.LTR),
                new Language( name : "Russian_Russia", code : "ru-RU" , mode: LanguageMode.LTR),
                new Language( name : "Sanskrit_India", code : "sa-IN" , mode: LanguageMode.LTR),
                new Language( name : "erbianCyrillic_Serbia", code : "Cy-sr-SP" , mode: LanguageMode.LTR),
                new Language( name : "SerbianLatin_Serbia", code : "Lt-sr-SP" , mode: LanguageMode.LTR),
                new Language( name : "Slovak_Slovakia", code : "sk-SK" , mode: LanguageMode.LTR),
                new Language( name : "Slovenian_Slovenia", code : "sl-SI" , mode: LanguageMode.LTR),
                new Language( name : "Spanish_Argentina", code : "es-AR" , mode: LanguageMode.LTR),
                new Language( name : "Spanish_Bolivia", code : "es-BO" , mode: LanguageMode.LTR),
                new Language( name : "Spanish_Chile", code : "es-CL" , mode: LanguageMode.LTR),
                new Language( name : "Spanish_Colombia", code : "es-CO" , mode: LanguageMode.LTR),
                new Language( name : "Spanish_CostaRica", code : "es-CR" , mode: LanguageMode.LTR),
                new Language( name : "Spanish_DominicanRepublic", code : "es-DO" , mode: LanguageMode.LTR),
                new Language( name : "Spanish_Ecuador", code : "es-EC" , mode: LanguageMode.LTR),
                new Language( name : "Spanish_ElSalvador", code : "es-SV" , mode: LanguageMode.LTR),
                new Language( name : "Spanish_Guatemala", code : "es-GT" , mode: LanguageMode.LTR),
                new Language( name : "Spanish_Honduras", code : "es-HN" , mode: LanguageMode.LTR),
                new Language( name : "Spanish_Mexico", code : "es-MX" , mode: LanguageMode.LTR),
                new Language( name : "Spanish_Nicaragua", code : "es-NI" , mode: LanguageMode.LTR),
                new Language( name : "Spanish_Panama", code : "es-PA" , mode: LanguageMode.LTR),
                new Language( name : "Spanish_Paraguay", code : "es-PY" , mode: LanguageMode.LTR),
                new Language( name : "Spanish_Peru", code : "es-PE" , mode: LanguageMode.LTR),
                new Language( name : "Spanish_PuertoRico", code : "es-PR" , mode: LanguageMode.LTR),
                new Language( name : "Spanish_Spain", code : "es-ES" , mode: LanguageMode.LTR),
                new Language( name : "Spanish_Uruguay", code : "es-UY" , mode: LanguageMode.LTR),
                new Language( name : "Spanish_Venezuela", code : "es-VE" , mode: LanguageMode.LTR),
                new Language( name : "Swahili_Kenya", code : "sw-KE" , mode: LanguageMode.LTR),
                new Language( name : "Swedish_Finland", code : "sv-FI" , mode: LanguageMode.LTR),
                new Language( name : "Swedish_Sweden", code : "sv-SE" , mode: LanguageMode.LTR),
                new Language( name : "Syriac_Syria", code : "syr-SY" , mode: LanguageMode.RTL),
                new Language( name : "Tami_India", code : "ta-IN" , mode: LanguageMode.LTR),
                new Language( name : "Tata_Russia", code : "tt-RU" , mode: LanguageMode.LTR),
                new Language( name : "Telugu_India", code : "te-IN" , mode: LanguageMode.LTR),
                new Language( name : "Thai_Thailand", code : "th-TH" , mode: LanguageMode.LTR),
                new Language( name : "Turkish_Turkey", code : "tr-TR" , mode: LanguageMode.LTR),
                new Language( name : "Ukrainian_Ukraine", code : "uk-UA" , mode: LanguageMode.LTR),
                new Language( name : "Urdu_Pakistan", code : "ur-PK" , mode: LanguageMode.RTL),
                new Language( name : "UzbekCyrillic_Uzbekistan", code : "Cy-uz-UZ" , mode: LanguageMode.LTR),
                new Language( name : "UzbekLatin_Uzbekistan", code : "Lt-uz-UZ" , mode: LanguageMode.LTR),
                new Language( name : "Vietnamese_Vietnam", code : "vi-VN", mode: LanguageMode.LTR)
            };
        }

        #endregion

        /// <summary>
        /// the Current language, this is the language that will be used to retrieve
        /// the proper translation
        /// </summary>
        public static Language CurrentLanguage
        {
            get => _currentLanguage;
            set
            {
                var tempVar = _currentLanguage;
                _currentLanguage = value;
                CurrentLanguageChanged?.Invoke(value, new LanguageChangedEventArgs(tempVar, value));
            }
        }

        /// <summary>
        /// the default language of the application, used as the fall back value
        /// </summary>
        public static Language DefaultLanguage
        {
            get => _defaultLanguage;
            set
            {
                var tempVar = _defaultLanguage;
                _defaultLanguage = value;
                DefaultLanguageChanged?.Invoke(value, new LanguageChangedEventArgs(tempVar, value));
            }
        }

        /// <summary>
        /// event raised when the CurrentLanguage is changed
        /// </summary>
        public static event EventHandler<LanguageChangedEventArgs> CurrentLanguageChanged;

        /// <summary>
        /// event raised when the DefaultLanguage is changed
        /// </summary>
        public static event EventHandler<LanguageChangedEventArgs> DefaultLanguageChanged;

        /// <summary>
        /// determine if the given language has a default value
        /// </summary>
        /// <param name="language">the language to check</param>
        /// <returns>true if it has the default value false if not</returns>
        public static bool HasDefaultValue(Language language)
            => !(language.Code.IsValid() || language.Name.IsValid());

        /// <summary>
        /// Get you a list of all supported Languages
        /// </summary>
        /// <returns>A list of Languages</returns>
        public static IEnumerable<Language> GetLanguageList() => _languagesList;

        /// <summary>
        /// Find a language by the name
        /// </summary>
        /// <param name="name">the name of the language</param>
        /// <returns>return the language, if nothing found will return null</returns>
        public static Language GetByName(string name)
            => _languagesList.FirstOrDefault(l => l.Name == name);

        /// <summary>
        /// Find a language by it code
        /// </summary>
        /// <param name="code">the code of the language</param>
        /// <returns>return the language, if nothing found will return null</returns>
        public static Language GetByCode(string code)
            => _languagesList.FirstOrDefault(l => l.Code == code);

        /// <summary>
        /// Get the string representation of the language 
        /// </summary>
        /// <param name="language">the language to get the string representation for</param>
        /// <returns>Return the Language that have the given name</returns>
        public static Language GetByEnum(Languages language)
            => _languagesList.FirstOrDefault(l => l.Name == language.ToString());
    }
}
