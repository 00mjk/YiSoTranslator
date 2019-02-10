using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YiSoTranslator.Test
{
    [TestClass]
    public class TranslationGroupTest
    {
        [TestMethod]
        public void ValideTranslationGroupTest()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");

            //- Act
            translationGroup
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"));

            //- Assert
            Assert.AreEqual("Email_Text", translationGroup.Name);
            Assert.AreEqual(3, translationGroup.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void InValideTranslationGroupNameTest()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("");

            //- Act

            //- Assert
        }

        [TestMethod]
        [ExpectedException(typeof(TranslationAlreadyExistExceptions))]
        public void InValideTranslationGroupTest()
        {
            //try to add an exiting translation to the translationGroup

            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text")
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"));

            var translation = new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك");

            //- Act

            translationGroup.Add(translation);

            //- Assert
        }

        [TestMethod]
        public void RemoveTranslationFromTranslationGroupTest()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");
            var translation = new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!");

            translationGroup
                .Add(translation)
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"));

            //- Act
            translationGroup.DeleteTranslation(translation);
            translationGroup.DeleteTranslation("fr-FR");

            //- Assert
            Assert.AreEqual(1, translationGroup.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(TranslationNotExistExceptions))]
        public void InValidRemoveTranslationByCodeFromTranslationGroupTest()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");

            translationGroup
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"));

            //- Act
            translationGroup.DeleteTranslation("ft-FR");

            //- Assert
        }

        [TestMethod]
        [ExpectedException(typeof(TranslationNotExistExceptions))]
        public void InValidRemoveTranslationByTranslationFromTranslationGroupTest()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");
            var translation = new Translation(Languages.Spanish_Spain.Code(), "¡Introduce tu correo electrónico!");

            translationGroup
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"));

            //- Act
            translationGroup.DeleteTranslation(translation);

            //- Assert
        }

        [TestMethod]
        public void ValidUpdateTranslationInTranslationGroupTest()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");
            var translation = new Translation(Languages.Spanish_Spain.Code(), "¡Introduce tu correo electrónico!");
            var translation1 = new Translation(Languages.Chinese_China.Code(), "输入你的电子邮箱！");

            translationGroup
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"))
                .Add(translation);

            //- Act
            translationGroup.UpdateTranslation(Languages.Arabic_Morocco.Code(), translation1);

            //- Assert
            Assert.AreEqual("输入你的电子邮箱！", translationGroup.Find(Languages.Chinese_China.Code()).Value);
            Assert.AreEqual(null, translationGroup.Find(Languages.Arabic_Morocco.Code()));
        }

        [TestMethod]
        public void ValidUpdateTranslationInTranslationGroupTest2()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");
            var translation = new Translation(Languages.Spanish_Spain.Code(), "¡Introduce tu correo electrónico!");

            translationGroup
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"))
                .Add(new Translation(Languages.Spanish_Spain.Code(), "¡Introduce electrónico!"));

            //- Act
            translationGroup.UpdateTranslation(Languages.Arabic_Morocco.Code(), translation);

            //- Assert
            Assert.AreEqual("ادخل الايميل الخاص بك", translationGroup.Find(Languages.Arabic_Morocco.Code()).Value);
            Assert.AreEqual("¡Introduce tu correo electrónico!", translationGroup.Find(Languages.Spanish_Spain.Code()).Value);
        }

        [TestMethod]
        [ExpectedException(typeof(TranslationNotExistExceptions))]
        public void InValidUpdateTranslationInTranslationGroupTest2()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");
            var translation = new Translation(Languages.Spanish_Spain.Code(), "¡Introduce tu correo electrónico!");

            translationGroup
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"))
                .Add(new Translation(Languages.Spanish_Spain.Code(), "¡Introduce electrónico!"));

            //- Act
            translationGroup.UpdateTranslation(Languages.Albanian_Albania.Code(), translation);

            //- Assert
        }

        [TestMethod]
        public void ValidDeleteTranslationInTranslationGroupTest()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");
            var translation = new Translation(Languages.Spanish_Spain.Code(), "¡Introduce tu correo electrónico!");

            translationGroup
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"))
                .Add(translation);

            //- Act
            translationGroup.DeleteTranslation(Languages.Arabic_Morocco.Code());
            translationGroup.DeleteTranslation(translation);

            //- Assert
            Assert.AreEqual(translationGroup.Count, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(TranslationNotExistExceptions))]
        public void InValidDeleteTranslationInTranslationGroupTest()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");
            var translation = new Translation(Languages.Spanish_Spain.Code(), "¡Introduce tu correo electrónico!");

            translationGroup
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"))
                .Add(translation);

            //- Act
            translationGroup.DeleteTranslation(Languages.Chinese_China.Code());

            //- Assert
        }

        [TestMethod]
        [ExpectedException(typeof(TranslationNotExistExceptions))]
        public void InValidDeleteTranslationInTranslationGroupTest2()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");
            var translation = new Translation(Languages.Spanish_Spain.Code(), "¡Introduce tu correo electrónico!");

            translationGroup
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"));

            //- Act
            translationGroup.DeleteTranslation(translation);

            //- Assert
        }

        [TestMethod]
        public void ValidCheckLanguageIfExistTranslationInTranslationGroupTest()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");

            translationGroup
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"));

            //- Act
            var exist = translationGroup.HasLanguage(Languages.Arabic_Morocco);
            var exist2 = translationGroup.HasLanguage(Languages.Spanish_Spain.Code());
            var exist3 = translationGroup.HasLanguage("go-GO");

            //- Assert
            Assert.AreEqual(true, exist);
            Assert.AreEqual(false, exist2);
            Assert.AreEqual(false, exist3);
        }

        [TestMethod]
        public void ValidEqualitycheckOperation()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text")
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"));

            var translationGroup2 = new TranslationsGroup("Email_Text")
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"));

            var translationGroup3 = new TranslationsGroup("Email_Text")
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"));

            var translationGroup4 = new TranslationsGroup("hello_text")
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Hello there"));

            //- Act
            var r1 = translationGroup != translationGroup2;
            var r2 = translationGroup2 == translationGroup3;
            var r3 = translationGroup3 != translationGroup4;

            //- Assert
            Assert.AreEqual(true, r1);
            Assert.AreEqual(true, r2);
            Assert.AreEqual(true, r3);
        }
    }
}
