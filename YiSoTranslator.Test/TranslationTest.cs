using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace YiSoTranslator.Test
{
    [TestClass]
    public class TranslationTest
    {
        [TestMethod]
        public void ValidTranslationTest()
        {
            var translation = new Translation("en-US", "Hello there");

            Assert.AreEqual(translation.Value, "Hello there");
            Assert.AreEqual(translation.LanguageCode, "en-US");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidLanguageCode))]
        public void InValidTranslationTest()
        {
            var translation = new Translation("go-GO", "Hello there");

            Assert.AreEqual(translation.Value, "Hello there");
            Assert.AreEqual(translation.LanguageCode, "go-GO");
        }

        [TestMethod]
        public void ValidTranslationEqualityTest()
        {
            var translation = new Translation("en-US", "Hello there");
            var translation1 = new Translation("en-US", "Hello there");
            var translation2 = new Translation(Language.GetByEnum(Languages.Arabic_Morocco).Code, "Hello there");

            var r1 = translation.Equals(translation1);
            var r2 = !translation2.Equals(translation1);

            Assert.AreEqual(true, r1, "the translations are equaled");
            Assert.AreEqual(true, r2, "the translations are not equaled");
        }
    }
}
