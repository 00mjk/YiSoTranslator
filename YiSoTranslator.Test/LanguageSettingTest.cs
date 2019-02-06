using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace YiSoTranslator.Test
{
    [TestClass]
    public class LanguageSettingTest
    {
        [TestMethod]
        public void LanguageSettingValidInstantInitializationTest()
        {
            //- Arrange
            var LSO1 = LanguageSetting.Instant;
            var DefaultInitialLanguage = Language.GetByEnum(Languages.English_UnitedStates);

            //- Act

            //- Assert
            Assert.AreEqual(DefaultInitialLanguage.Code, LSO1.CurrentLanguage.Code);
            Assert.AreEqual(DefaultInitialLanguage.Name, LSO1.CurrentLanguage.Name);
            Assert.AreEqual(DefaultInitialLanguage.Code, LSO1.DefaultLanguage.Code);
            Assert.AreEqual(DefaultInitialLanguage.Name, LSO1.DefaultLanguage.Name);
        }

        [TestMethod]
        public void LanguageSettingInstantTest()
        {
            //- Arrange
            var LSO1 = LanguageSetting.Instant;
            var LSO2 = LanguageSetting.Instant;

            //- Act
            LSO1.CurrentLanguage = Language.GetByEnum(Languages.Arabic_Morocco);
            LSO1.DefaultLanguage = Language.GetByEnum(Languages.Spanish_Spain);

            //- Assert
            Assert.AreEqual(LSO2.CurrentLanguage.Code, LSO1.CurrentLanguage.Code);
            Assert.AreEqual(LSO2.DefaultLanguage.Code, LSO1.DefaultLanguage.Code);
        }

        [TestMethod]
        public void LanguageSettingEventTest()
        {
            //- Arrange
            var LSO1 = LanguageSetting.Instant;
            var LSO2 = LanguageSetting.Instant;
            var CurrentLanguageCode = "";
            var CurrentLanguageName = "";
            var DefaultLanguageCode = "";
            var DefaultLanguageName = "";

            LSO2.CurrentLanguageChanged += (s, e) =>
            {
                CurrentLanguageCode = e.NewLanguage.Code;
                CurrentLanguageName = e.NewLanguage.Name;
                Console.WriteLine($@"CurrentLanguageChanged Event is raised : 
e.OldLanguage.Code= {e.OldLanguage.Code} => e.NewLanguage.Code= {e.NewLanguage.Code}, 
e.OldLanguage.Name= {e.OldLanguage.Name} => e.NewLanguage.Name= {e.NewLanguage.Name}");
            };
            LSO2.DefaultLanguageChanged += (s, e) =>
            {
                DefaultLanguageCode = e.NewLanguage.Code;
                DefaultLanguageName = e.NewLanguage.Name;
                Console.WriteLine($@"DefaultLanguageChanged Event is raised : 
e.OldLanguage.Code= {e.OldLanguage.Code} => e.NewLanguage.Code= {e.NewLanguage.Code}, 
e.OldLanguage.Name= {e.OldLanguage.Name} => e.NewLanguage.Name= {e.NewLanguage.Name}");
            };

            //- Act
            LSO1.CurrentLanguage = Language.GetByEnum(Languages.Arabic_Morocco);
            LSO1.DefaultLanguage = Language.GetByEnum(Languages.Spanish_Spain);

            //- Assert
            Assert.AreEqual(CurrentLanguageCode, LSO1.CurrentLanguage.Code);
            Assert.AreEqual(CurrentLanguageName, LSO1.CurrentLanguage.Name);
            Assert.AreEqual(DefaultLanguageCode, LSO1.DefaultLanguage.Code);
            Assert.AreEqual(DefaultLanguageName, LSO1.DefaultLanguage.Name);
        }
    }
}
