using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YiSoTranslator.Test
{
    [TestClass]
    public class TranslatorTest
    {
        // the TEST in here should be run One by one

        [TestMethod]
        public void ValideTranslatorTest()
        {
            //- Arrange
            var provider = new InMemoryTranslationProvider();
            var translator = new Translator(provider);

            //- Act
            var text = translator.GetText("hello_text");

            //- Assert
            Assert.AreEqual("Hello", text);
        }

        [TestMethod]
        public void ValideTranslatorLanguageInstantTest()
        {
            //- Arrange
            var provider = new InMemoryTranslationProvider();
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
