using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YiSoTranslator.Test.HelpersTest
{
    [TestClass]
    public class StringHelperTest
    {
        [TestMethod]
        public void ValidateString()
        {
            string value1 = "";
            string value2 = null;
            string value3 = "   ";
            string value4 = "something";
            string value5 = " something ";

            var result1 = value1.IsValid();
            var result2 = value2.IsValid();
            var result3 = value3.IsValid();
            var result4 = value4.IsValid();
            var result5 = value5.IsValid();

            Assert.AreEqual(false, result1, "an empty string value should be invalid");
            Assert.AreEqual(false, result2, "a null string value should be invalid");
            Assert.AreEqual(false, result3, "a whitespace string value should be invalid");
            Assert.AreEqual(true, result4, "all strings with value should be valid");
            Assert.AreEqual(true, result5, "all strings with value should be valid");
        }
    }
}
