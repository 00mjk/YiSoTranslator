using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace YiSoTranslator.Test
{
    [TestClass]
    public class LanguageTestShould
    {
        [TestMethod]
        public void Get_Valid_Language()
        {
            //- Arrange
            var language = Language.GetByCode("en-GB");

            //- Act

            //- Assert
            Assert.AreEqual(language.Name, "English_UnitedKingdom");
            Assert.AreEqual(language.Code, "en-GB");
        }

        [TestMethod]
        public void Check_Language_Equality()
        {
            //- Arrange
            var language = Language.GetByCode("en-GB");
            var language2 = Language.GetByEnum(Languages.English_UnitedKingdom);

            //- Act
            var r = language == language2;

            //- Assert
            Assert.AreEqual(true, r);
        }

        [TestMethod]
        public void Check_Language_Non_Equality()
        {
            //- Arrange
            var language = Language.GetByCode("en-GB");
            var language2 = Language.GetByEnum(Languages.English_UnitedKingdom);

            //- Act
            var r = language != language2;

            //- Assert
            Assert.AreEqual(false, r);
        }

        [TestMethod]
        public void Should_Fall_To_Default_Value_If_Language_Not_Exist()
        {
            //- Arrange
            var language = Language.GetByCode("go-Go"); // this language doesn't exist so we should get default value
            var language2 = Language.GetByEnum(Languages.English_UnitedKingdom); // this language exist so we should get language

            //- Act
            var hasDefaultValue = language.HasDefaultValue();
            var hasDefaultValue2 = language2.HasDefaultValue();

            //- Assert
            Assert.AreEqual(true, hasDefaultValue);
            Assert.AreEqual(false, hasDefaultValue2);
        }

        [TestMethod]
        public void Implicitly_Convert_From_String_To_Language_And_Vice_Versa()
        {
            var language = Language.GetByEnum(Languages.English_UnitedKingdom);

            //- Arrange
            Language languageFromString = "en-GB";
            string languageCodeFromLanguage = language; 

            //- Act

            //- Assert
            Assert.AreEqual(language.Name, languageFromString.Name);
            Assert.AreEqual("en-GB", languageCodeFromLanguage);
        }

        [TestMethod]
        public void Fire_Language_Changed_Events()
        {
            //- Arrange
            var arabic = Language.GetByEnum(Languages.Arabic_Morocco);
            var spanish = Language.GetByEnum(Languages.Spanish_Spain);
            var CurrentLanguageCode = "";
            var CurrentLanguageName = "";
            var DefaultLanguageCode = "";
            var DefaultLanguageName = "";

            Language.CurrentLanguageChanged += (s, e) =>
            {
                CurrentLanguageCode = e.NewLanguage.Code;
                CurrentLanguageName = e.NewLanguage.Name;
                Console.WriteLine($@"CurrentLanguageChanged Event is raised : 
        e.OldLanguage.Code= {e.OldLanguage.Code} => e.NewLanguage.Code= {e.NewLanguage.Code}, 
        e.OldLanguage.Name= {e.OldLanguage.Name} => e.NewLanguage.Name= {e.NewLanguage.Name}");
            };
            Language.DefaultLanguageChanged += (s, e) =>
            {
                DefaultLanguageCode = e.NewLanguage.Code;
                DefaultLanguageName = e.NewLanguage.Name;
                Console.WriteLine($@"DefaultLanguageChanged Event is raised : 
        e.OldLanguage.Code= {e.OldLanguage.Code} => e.NewLanguage.Code= {e.NewLanguage.Code}, 
        e.OldLanguage.Name= {e.OldLanguage.Name} => e.NewLanguage.Name= {e.NewLanguage.Name}");
            };

            //- Act
            Language.CurrentLanguage = arabic;
            Language.DefaultLanguage = spanish;

            //- Assert
            Assert.AreEqual(CurrentLanguageCode, arabic.Code);
            Assert.AreEqual(CurrentLanguageName, arabic.Name);
            Assert.AreEqual(DefaultLanguageCode, spanish.Code);
            Assert.AreEqual(DefaultLanguageName, spanish.Name);
        }
    }
}
