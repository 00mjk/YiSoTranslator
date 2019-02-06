using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YiSoTranslator.Test
{
    [TestClass]
    public class TranslationGroupManagerTest
    {
        [TestMethod]
        public void ValideTranslationGroupManagerTest()
        {
            //- Arrange
            var provider = new InMemoryTranslationProvider();
            var manager = new TranslationGroupManager(provider);

            //- Act
            var translationGroup = manager.Find("Hello_text");

            //- Assert
            Assert.AreEqual(5, translationGroup.Count);
        }

        [TestMethod]
        public void ValideAddTranslationGroupWithManagerTest()
        {
            //- Arrange
            var provider = new InMemoryTranslationProvider();
            var manager = new TranslationGroupManager(provider);

            //- Act
            var tranlsationGroup = manager.Add(new TranslationsGroup("Email_text"));
            tranlsationGroup
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"));

            //- Assert
            Assert.AreEqual(2, manager.Count); //assert that the manager has 2 translation groups
            Assert.AreEqual(3, manager.Find("Email_text").Count); // assert that the translation group "Email_text" has 3 translations
        }

        [TestMethod]
        [ExpectedException(typeof(TranslationGroupAlreadyExistException))]
        public void InValideAddTranslationGroupWithManagerTest()
        {
            //- Arrange
            var provider = new InMemoryTranslationProvider();
            var manager = new TranslationGroupManager(provider);
            var tranlsationGroup = manager.Add(new TranslationsGroup("Email_text"));
            tranlsationGroup
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"));

            //- Act
            //the manager has a translation group with the same name, an exception must be thrown
            manager.Add(new TranslationsGroup("hello_text")); 

            //- Assert
        }

        [TestMethod]
        public void ValideFindTranslationGroupWithManagerTest()
        {
            //- Arrange
            var provider = new InMemoryTranslationProvider();
            var manager = new TranslationGroupManager(provider);

            var tranlsationGroup = manager.Add(new TranslationsGroup("Email_text"));
            tranlsationGroup
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"));

            //- Act
            var exist1 = manager.Find("Email_text");
            var exist2 = manager.Find("go_Go");

            //- Assert
            Assert.IsInstanceOfType(exist1, typeof(TranslationsGroup)); 
            Assert.AreEqual(null, exist2); 
        }

        [TestMethod]
        public void ValideRemoveTranslationGroupWithManagerTest()
        {
            //- Arrange
            var provider = new InMemoryTranslationProvider();
            var manager = new TranslationGroupManager(provider);

            var tranlsationGroup = manager.Add(new TranslationsGroup("Email_text"));
            tranlsationGroup
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"));

            //- Act
            var removed = manager.Remove("HELLO_TEXT");

            //- Assert
            Assert.AreEqual(true, removed);
            Assert.AreEqual(1, manager.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(TranslationGroupNotExistException))]
        public void InValideRemoveTranslationGroupWithManagerTest()
        {
            //- Arrange
            var provider = new InMemoryTranslationProvider();
            var manager = new TranslationGroupManager(provider);

            var tranlsationGroup = manager.Add(new TranslationsGroup("Email_text"));
            tranlsationGroup
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"));

            //- Act
            var removed = manager.Remove("go_GO");

            //- Assert
        }

        [TestMethod]
        public void ValideUpdateTranslationGroupWithManagerTest()
        {
            //- Arrange
            var provider = new InMemoryTranslationProvider();
            var manager = new TranslationGroupManager(provider);

            var tranlsationGroup = manager.Add(new TranslationsGroup("Email_text"));
            tranlsationGroup
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"));

            //- Act
            var updated = manager.Update("HELLO_TEXT", "NewName_Text");
            var exist = manager.Find("HELLO_TEXT");

            //- Assert
            Assert.AreEqual("NewName_Text", updated.Name);
            Assert.AreEqual(null, exist);
            Assert.AreEqual(2, manager.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(TranslationGroupAlreadyExistException))]
        public void InValideUpdateTranslationGroupWithManagerTest()
        {
            //- Arrange
            var provider = new InMemoryTranslationProvider();
            var manager = new TranslationGroupManager(provider);

            var tranlsationGroup = manager.Add(new TranslationsGroup("Email_text"));
            tranlsationGroup
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"));

            //- Act
            var updated = manager.Update("HELLO_TEXT", "Email_text");

            //- Assert
        }

        [TestMethod]
        [ExpectedException(typeof(TranslationGroupNotExistException))]
        public void InValideUpdateTranslationGroupWithManagerTest2()
        {
            //- Arrange
            var provider = new InMemoryTranslationProvider();
            var manager = new TranslationGroupManager(provider);

            var tranlsationGroup = manager.Add(new TranslationsGroup("Email_text"));
            tranlsationGroup
                .Add(new Translation(Languages.English_UnitedStates.Code(), "Enter your Email!"))
                .Add(new Translation(Languages.French_France.Code(), "Entrer votre Email!"))
                .Add(new Translation(Languages.Arabic_Morocco.Code(), "ادخل الايميل الخاص بك"));

            //- Act
            var updated = manager.Update("go_GO", "Email_text");

            //- Assert
        }
    }
}
