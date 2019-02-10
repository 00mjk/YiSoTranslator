using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YiSoTranslator.Test
{
    [TestClass]
    public class LanguageTest
    {
        [TestMethod]
        public void ValideLanguageTest()
        {
            //- Arrange
            var language = Language.GetByCode("en-GB");

            //- Act

            //- Assert
            Assert.AreEqual(language.Name, "English_UnitedKingdom");
            Assert.AreEqual(language.Code, "en-GB");
        }

        [TestMethod]
        public void LanguageEqualityTest()
        {
            //- Arrange
            var language = Language.GetByCode("en-GB");
            var language2 = Language.GetByEnum(Languages.English_UnitedKingdom);
            var language3 = Language.GetByEnum(Languages.Arabic_Morocco);

            //- Act
            var r = language == language2;
            var r1 = language2 != language3;

            //- Assert
            Assert.AreEqual(true, r);
            Assert.AreEqual(true, r1);
        }

        [TestMethod]
        public void LanguageNonEqualityTest()
        {
            //- Arrange
            var language = Language.GetByCode("en-GB");
            var language2 = Language.GetByEnum(Languages.English_UnitedKingdom);

            //- Act
            var r = language != language2;

            //- Assert
            Assert.AreEqual(false, r);
        }
    }
}
