using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YiSoTranslator.Test
{
    [TestClass]
    public class TranslatorTestShould
    {
        // the TEST in here should be run One by one

        static InMemoryTranslationProvider provider;
        static Translator translator;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            provider = new InMemoryTranslationProvider();
            translator = new Translator();
            translator.AttachProvider(provider);

            Language.CurrentLanguage = Language.GetByEnum(Languages.English_UnitedStates);
            Language.DefaultLanguage = Language.GetByEnum(Languages.English_UnitedStates);
        }

        [TestMethod]
        [Priority(1000)]
        public void Get_Translation_For_Current_Language()
        {
            //- Arrange
            Language.CurrentLanguage = Language.GetByEnum(Languages.Chinese_China);

            //- Act
            var text = translator.GetText("hello_text");

            //- Assert
            Assert.AreEqual("你好", text);
        }

        [TestMethod]
        [Priority(1000)]
        public void Fall_Back_To_Default_Language_If_Not_Found()
        {
            //- Arrange
            Language.DefaultLanguage = Language.GetByEnum(Languages.Arabic_Morocco);

            //- Act
            // there is no translation for this language should fall back to default
            var text = translator.GetText("hello_text", Languages.Armenian_Armenia);

            //- Assert 
            Assert.AreEqual("مرحبا", text);
        }

        [TestMethod]
        [Priority(900)]
        [ExpectedException(typeof(TranslationsGroupNotExistException))]
        public void Throw_Exception_If_Translation_Group_Not_Exist()
        {
            //- Arrange

            //- Act
            var text = translator.GetText("hello_there");

            //- Assert
        }

        [TestMethod]
        public void Fire_Events_For_Current_Language_Change()
        {
            //- Arrange
            Language.CurrentLanguage = Language.GetByEnum(Languages.English_UnitedStates);
            var translator = new Translator();
            var currentLang = "";
            var oldLang = "";

            translator.CurrentLanguageChanged += (s, e) =>
            {
                currentLang = e.NewLanguage.Code;
                oldLang = e.OldLanguage.Code;
            };

            //- Act
            Language.CurrentLanguage = Language.GetByEnum(Languages.Spanish_Spain);

            //- Assert
            Assert.AreEqual(Languages.Spanish_Spain.Code(), currentLang);
            Assert.AreEqual(Languages.English_UnitedStates.Code(), oldLang);
        }

        [TestMethod]
        public void Fire_Events_For_Default_Language_Change()
        {
            //- Arrange
            Language.DefaultLanguage = Language.GetByEnum(Languages.English_UnitedStates);
            var translator = new Translator();
            var currentLang = "";
            var oldLang = "";

            translator.DefaultLanguageChanged += (s, e) =>
            {
                currentLang = e.NewLanguage.Code;
                oldLang = e.OldLanguage.Code;
            };

            //- Act
            Language.DefaultLanguage = Language.GetByEnum(Languages.Spanish_Spain);

            //- Assert
            Assert.AreEqual(Languages.Spanish_Spain.Code(), currentLang);
            Assert.AreEqual(Languages.English_UnitedStates.Code(), oldLang);
        }
    }
}
