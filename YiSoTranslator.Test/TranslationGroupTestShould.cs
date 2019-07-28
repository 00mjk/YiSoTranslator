using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace YiSoTranslator.Test
{
    [TestClass]
    public class TranslationGroupTestShould
    {
        [TestMethod]
        public void Create_A_Valid_TranslationGroup()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");

            //- Act
            translationGroup
                .Add(new Translation(Languages.English_UnitedStates, "Enter your Email!"))
                .Add(new Translation(Languages.French_France, "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco, "ادخل الايميل الخاص بك"));

            //- Assert
            Assert.AreEqual("Email_Text", translationGroup.Name);
            Assert.AreEqual(3, translationGroup.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Throw_Argument_Exception_Name_Invalid()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("");

            //- Act

            //- Assert
        }

        [TestMethod]
        [ExpectedException(typeof(TranslationAlreadyExistExceptions))]
        public void Throw_Exception_If_Translation_Exist()
        {
            //try to add an exiting translation to the translationGroup

            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text")
                .Add(new Translation(Languages.English_UnitedStates, "Enter your Email!"))
                .Add(new Translation(Languages.French_France, "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco, "ادخل الايميل الخاص بك"));

            var translation = new Translation(Languages.Arabic_Morocco, "ادخل الايميل الخاص بك");

            //- Act

            translationGroup.Add(translation);

            //- Assert
        }

        [TestMethod]
        public void Remove_Translation_From_TranslationGroup()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");
            var translation = new Translation(Languages.English_UnitedStates, "Enter your Email!");

            translationGroup
                .Add(translation)
                .Add(new Translation(Languages.French_France, "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco, "ادخل الايميل الخاص بك"));

            //- Act
            translationGroup.Remove(translation);
            translationGroup.Remove("fr-FR");

            //- Assert
            Assert.AreEqual(1, translationGroup.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(TranslationNotExistExceptions))]
        public void Throw_Exception_onRemove_ByCode_If_Translation_Not_Exist()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");

            translationGroup
                .Add(new Translation(Languages.English_UnitedStates, "Enter your Email!"))
                .Add(new Translation(Languages.French_France, "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco, "ادخل الايميل الخاص بك"));

            //- Act
            translationGroup.Remove("ft-FR");

            //- Assert
        }

        [TestMethod]
        [ExpectedException(typeof(TranslationNotExistExceptions))]
        public void Throw_Exception_onRemove_ByTranslation_If_Translation_Not_Exist()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");
            var translation = new Translation(Languages.Spanish_Spain, "¡Introduce tu correo electrónico!");

            translationGroup
                .Add(new Translation(Languages.English_UnitedStates, "Enter your Email!"))
                .Add(new Translation(Languages.French_France, "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco, "ادخل الايميل الخاص بك"));

            //- Act
            translationGroup.Remove(translation);

            //- Assert
        }

        [TestMethod]
        public void Update_translation_with_new_value()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");
            var translation = new Translation(Languages.Spanish_Spain, "¡Introduce tu correo electrónico!");
            var translation1 = new Translation(Languages.Arabic_Morocco, "ادخل الايميل الخاص بك");

            translationGroup
                .Add(new Translation(Languages.English_UnitedStates, "Enter your Email!"))
                .Add(new Translation(Languages.French_France, "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco, "ادخل الايميل"))
                .Add(translation);

            //- Act
            translationGroup.UpdateTranslation(translation1);

            //- Assert
            Assert.AreEqual("ادخل الايميل الخاص بك", translationGroup.Find(Languages.Arabic_Morocco).Value);
            Assert.AreNotEqual("ادخل الايميل", translationGroup.Find(Languages.Arabic_Morocco).Value);
        }

        [TestMethod]
        [ExpectedException(typeof(TranslationNotExistExceptions))]
        public void Throw_exception_onUpdate_if_translation_not_exist()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");
            var translation = new Translation(Languages.Spanish_Spain, "¡Introduce tu correo electrónico!");

            translationGroup
                .Add(new Translation(Languages.English_UnitedStates, "Enter your Email!"))
                .Add(new Translation(Languages.French_France, "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco, "ادخل الايميل الخاص بك"));

            //- Act
            translationGroup.UpdateTranslation(translation);

            //- Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throw_exception_onUpdate_if_new_translation_value_isNull()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");

            translationGroup
                .Add(new Translation(Languages.English_UnitedStates, "Enter your Email!"))
                .Add(new Translation(Languages.French_France, "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco, "ادخل الايميل الخاص بك"));

            //- Act
            translationGroup.UpdateTranslation(null);

            //- Assert
        }

        [TestMethod]
        public void Delete_transltaion()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");
            var translation = new Translation(Languages.Spanish_Spain, "¡Introduce tu correo electrónico!");

            translationGroup
                .Add(new Translation(Languages.Arabic_Morocco, "ادخل الايميل الخاص بك"))
                .Add(new Translation(Languages.English_UnitedStates, "Enter your Email!"))
                .Add(new Translation(Languages.French_France, "Entrer votre Email!"))
                .Add(translation);

            //- Act
            translationGroup.Remove(Languages.English_UnitedStates.Code());
            translationGroup.Remove(Languages.French_France);
            translationGroup.Remove(translation);

            //- Assert
            Assert.AreEqual(translationGroup.Count, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(TranslationNotExistExceptions))]
        public void Throw_Exception_OnDelete_ByEnum_If_transltaion_NotExist()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");
            var translation = new Translation(Languages.Spanish_Spain, "¡Introduce tu correo electrónico!");

            translationGroup
                .Add(new Translation(Languages.English_UnitedStates, "Enter your Email!"))
                .Add(new Translation(Languages.French_France, "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco, "ادخل الايميل الخاص بك"))
                .Add(translation);

            //- Act
            translationGroup.Remove(Languages.Chinese_China);

            //- Assert
        }

        [TestMethod]
        [ExpectedException(typeof(TranslationNotExistExceptions))]
        public void Throw_Exception_OnDelete_ByObject_If_transltaion_NotExist()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");
            var translation = new Translation(Languages.Spanish_Spain, "¡Introduce tu correo electrónico!");

            translationGroup
                .Add(new Translation(Languages.English_UnitedStates, "Enter your Email!"))
                .Add(new Translation(Languages.French_France, "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco, "ادخل الايميل الخاص بك"));

            //- Act
            translationGroup.Remove(translation);

            //- Assert
        }

        [TestMethod]
        [ExpectedException(typeof(TranslationNotExistExceptions))]
        public void Throw_Exception_OnDelete_ByLanguageCode_If_transltaion_NotExist()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text");
            var translation = new Translation(Languages.Spanish_Spain, "¡Introduce tu correo electrónico!");

            translationGroup
                .Add(new Translation(Languages.English_UnitedStates, "Enter your Email!"))
                .Add(new Translation(Languages.French_France, "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco, "ادخل الايميل الخاص بك"));

            //- Act
            translationGroup.Remove(Languages.Spanish_Spain.Code());

            //- Assert
        }

        [TestMethod]
        public void Check_If_language_exist_with_HasLanguage()
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
        public void Check_For_equality_with_equality_operators()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text")
                .Add(new Translation(Languages.English_UnitedStates, "Enter your Email!"))
                .Add(new Translation(Languages.French_France, "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco, "ادخل الايميل الخاص بك"));

            var translationGroup2 = new TranslationsGroup("Email_Text")
                .Add(new Translation(Languages.Arabic_Morocco, "ادخل الايميل الخاص بك"));

            var translationGroup3 = new TranslationsGroup("Email_Text")
                .Add(new Translation(Languages.French_France, "Entrer votre Email!"));

            var translationGroup4 = new TranslationsGroup("hello_text")
                .Add(new Translation(Languages.English_UnitedStates, "Hello there"));

            //- Act
            var r1 = translationGroup as TranslationsGroup == translationGroup2 as TranslationsGroup;
            var r2 = translationGroup2 as TranslationsGroup == translationGroup3 as TranslationsGroup;
            var r3 = translationGroup3 as TranslationsGroup == translationGroup4 as TranslationsGroup;

            var r4 = translationGroup as TranslationsGroup == translationGroup2;
            var r5 = translationGroup3 as TranslationsGroup == translationGroup4;

            //- Assert
            Assert.AreEqual(true, r1, "group 1 and group 2 have the same name, so they are equals");
            Assert.AreEqual(true, r2, "group 2 and group 3 have the same name, so they are equals");
            Assert.AreEqual(false, r3, "group 3 has a deferent name than group 4, so they are not equals");
            Assert.AreEqual(true, r4, "group 1 and group 2 have the same name, so they are equals (interface)");
            Assert.AreEqual(false, r5, "group 3 has a deferent name than group 4, so they are not equals (interface)");
        }

        [TestMethod]
        public void Iterate_Over_Translation()
        {
            //- Arrange
            var translationGroup = new TranslationsGroup("Email_Text")
                .Add(new Translation(Languages.English_UnitedStates, "Enter your Email!"))
                .Add(new Translation(Languages.French_France, "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco, "ادخل الايميل الخاص بك"));

            var count = 0;

            // Act
            foreach (var translation in translationGroup)
            {
                count++;
            }

            //- Assert
            Assert.AreEqual(3, count, "list contains 3 translation, so the count should be 3");
        }
    }
}
