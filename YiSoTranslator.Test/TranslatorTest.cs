using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YiSoTranslator.Test
{
    [TestClass]
    public class TranslatorTest
    {
        // the TEST in here should be run One by one

        static InMemoryTranslationProvider provider;
        static Translator translator;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            provider = new InMemoryTranslationProvider();
            translator = new Translator(provider);

            LanguageSetting.Instant.CurrentLanguage = Language.GetByEnum(Languages.English_UnitedStates);
            LanguageSetting.Instant.DefaultLanguage = Language.GetByEnum(Languages.English_UnitedStates);
        }

        [TestMethod]
        [Priority(1000)]
        public void ValideTranslatorTest()
        {
            //- Arrange

            //- Act
            var text = translator.GetText("hello_text");

            //- Assert
            Assert.AreEqual("Hello", text);
        }

        [TestMethod]
        [Priority(900)]
        [ExpectedException(typeof(TranslationsGroupNotExistException))]
        public void InValideTranslatorGetTextTest()
        {
            //- Arrange

            //- Act
            var text = translator.GetText("hello_there");

            //- Assert
        }

        [TestMethod]
        [Priority(700)]
        public void ValideTranslatorGetTextfallToDefaultTest()
        {
            //- Arrange

            //- Act
            // there is no translation for this language should fall back to default
            var text = translator.GetText("hello_text", Languages.Armenian_Armenia);

            //- Assert 
            Assert.AreEqual("Hello", text);
        }

        [TestMethod]
        [Priority(500)]
        public void ValideTranslatorLanguageInstantTest()
        {
            //- Arrange
            var translator = new Translator(provider);

            //- Act


            //- Assert
            Assert.AreEqual(Languages.English_UnitedStates.Code(), translator.LanguageSetting.CurrentLanguage.Code);
            Assert.AreEqual(Languages.English_UnitedStates.Code(), translator.LanguageSetting.DefaultLanguage.Code);
        }

        [TestMethod]
        public void ValideTranslatorLanguageInstantTest2()
        {
            //- Arrange
            var provider = new InMemoryTranslationProvider();
            var translator = new Translator(provider);
            var languageSetting = LanguageSetting.Instant;
            var currentLang = "";
            var oldLang = "";

            translator.CurrentLanguageChanged += (s, e) =>
            {
                currentLang = e.NewLanguage.Code;
                oldLang = e.OldLanguage.Code;
            };

            //- Act
            translator.LanguageSetting = languageSetting;
            languageSetting.CurrentLanguage = Language.GetByEnum(Languages.Spanish_Spain);

            //- Assert
            Assert.AreEqual(Languages.Spanish_Spain.Code(), currentLang);
            Assert.AreEqual(Languages.English_UnitedStates.Code(), oldLang);
        }

        [TestMethod]
        public void ValideTranslatorLanguageInstantTest3()
        {
            //- Arrange
            var provider = new InMemoryTranslationProvider();
            var translator = new Translator(provider);

            //- Act
            var languageSetting = LanguageSetting.Instant;

            //- Assert
            Assert.ReferenceEquals(languageSetting, translator.LanguageSetting);
        }
    }
}
