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
    }
}
