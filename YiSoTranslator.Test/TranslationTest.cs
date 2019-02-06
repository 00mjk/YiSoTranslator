using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YiSoTranslator.Test
{
    [TestClass]
    public class TranslationTest
    {
        [TestMethod]
        public void ValideTranslationTest()
        {
            //- Arrange
            var translation = new Translation("en-GB", "Hello there!");

            //- Act

            //- Assert
            Assert.AreEqual(translation.Value, "Hello there!");
            Assert.AreEqual(translation.LanguageCode, "en-GB");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidLanguageCode))]
        public void InValideTranslationTest()
        {
            //- Arrange
            var translation = new Translation("go-GO", "Hello there!");

            //- Act

            //- Assert
        }
    }
}
