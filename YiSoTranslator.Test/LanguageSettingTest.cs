using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace YiSoTranslator.Test
{
    [TestClass]
    public class LanguageSettingTest
    {
        [TestMethod]
        [Priority(1000)]
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

            var arabic = Language.GetByEnum(Languages.Arabic_Morocco);
            var spanish = Language.GetByEnum(Languages.Spanish_Spain);

            //- Act
            LSO1.CurrentLanguage = arabic;
            LSO1.DefaultLanguage = spanish;

            //- Assert
            Assert.AreEqual(arabic.Code, LSO2.CurrentLanguage.Code);
            Assert.AreEqual(spanish.Code, LSO2.DefaultLanguage.Code);
        }

        [TestMethod]
        public void LanguageSettingEventTest()
        {
            //- Arrange
            var LSO1 = LanguageSetting.Instant;
            var LSO2 = LanguageSetting.Instant;
            var arabic = Language.GetByEnum(Languages.Arabic_Morocco);
            var spanish = Language.GetByEnum(Languages.Spanish_Spain);
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
            LSO1.CurrentLanguage = arabic;
            LSO1.DefaultLanguage = spanish;

            //- Assert
            Assert.AreEqual(CurrentLanguageCode, arabic.Code);
            Assert.AreEqual(CurrentLanguageName, arabic.Name);
            Assert.AreEqual(DefaultLanguageCode, spanish.Code);
            Assert.AreEqual(DefaultLanguageName, spanish.Name);
        }

        [TestMethod]
        public void ValidEqualityOperation()
        {
            var instant1 = LanguageSetting.Instant;
            var instant2 = LanguageSetting.Instant;

            var r1 = ReferenceEquals(instant1, instant2);
            var r2 = instant1 == instant2;
            var r3 = instant1 != instant2;

            Assert.AreEqual(true, r1);
            Assert.AreEqual(true, r2);
            Assert.AreEqual(false, r3);
        }

        [ClassCleanup]
        public static void CleanUP()
        {
            LanguageSetting.Instant.CurrentLanguage = Language.GetByEnum(Languages.English_UnitedStates);
            LanguageSetting.Instant.DefaultLanguage = Language.GetByEnum(Languages.English_UnitedStates);
        }
    }
}
