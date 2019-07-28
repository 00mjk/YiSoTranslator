using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace YiSoTranslator.Test
{
    [TestClass]
    public class TranslationTestShould
    {
        [TestMethod]
        public void ValidTranslationTest()
        {
            var translation = new Translation("en-US", "Hello there");

            Assert.AreEqual(translation.Value, "Hello there");
            Assert.AreEqual(translation.Language.Code, "en-US");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidLanguageCode))]
        public void Throw_Exception_If_Language_Code_Not_Valid()
        {
            var translation = new Translation("go-GO", "Hello there");

            Assert.AreEqual(translation.Value, "Hello there");
            Assert.AreEqual(translation.Language.Code, "go-GO");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidLanguage))]
        public void Throw_Exception_If_Language_Has_Defaut_Value()
        {
            var translation = new Translation(default(Language), "Hello there");

            Assert.AreEqual(translation.Value, "Hello there");
            Assert.AreEqual(translation.Language.Code, "go-GO");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidLanguage))]
        public void Throw_Exception_If_Language_Has_Defaut_Value_passed_As_Variable()
        {
            var language = Language.GetByCode("go-GO");

            var translation = new Translation(language, "Hello there");

            Assert.AreEqual(translation.Value, "Hello there");
            Assert.AreEqual(translation.Language.Code, "go-GO");
        }

        [TestMethod]
        public void Check_For_Equality()
        {
            var translation = new Translation("en-US", "Hello there");
            var translation1 = new Translation("en-US", "Hello there");
            var translation2 = new Translation(Language.GetByEnum(Languages.Arabic_Morocco).Code, "Hello there");

            var r1 = translation.Equals(translation1);
            var r2 = !translation2.Equals(translation1);

            Assert.AreEqual(true, r1, "the translations are equaled");
            Assert.AreEqual(true, r2, "the translations are not equaled");
        }

        [TestMethod]
        public void Check_For_Equality_with_operators()
        {
            var translation = new Translation("en-US", "Hello there");
            var translation1 = new Translation("en-US", "Hello there");
            var translation2 = new Translation(Language.GetByEnum(Languages.Arabic_Morocco).Code, "Hello there");

            var r1 = translation == translation1;
            var r2 = translation2 != translation1;

            Assert.AreEqual(true, r1, "the translations are equaled");
            Assert.AreEqual(true, r2, "the translations are not equaled");
        }
    }
}
