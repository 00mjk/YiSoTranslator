using System;
using System.Windows.Forms;
using System.Linq;
using YiSoTranslator;

namespace YiSoTranslator.Sample
{
    public partial class Form1 : Form
    {
        #region Translator Configuration

        private Translator translator;

        /// <summary>
        /// this method is used to Initialize the Translator object
        /// </summary>
        private void InitializeTranslator()
        {
            //the 'Form1.json' is the name of the translation witch contain the translation for this Form
            translator = new Translator("Form1.json", Program.setting);

            //Here we listen for the Changes in the current language, 
            //if it changed we reload the translation Asynchronously
            translator.CurrentLanguageChanged += (s, e) => GetTranslationsAsync();

            //we call this function to load the translations for the first time
            GetTranslationsAsync();
        }

        /// <summary>
        /// this method is used to load the translations, and display them in the controls
        /// </summary>
        private async void GetTranslationsAsync()
        {
            //Make the calls to your translations
            label1.Text = await translator.GetTextAsync("Email_text");
            //button1.text = await translator.GetTextAsync("Submit_text");
            //...
        }

        /// <summary>
        /// you can use this method to add translations to your file
        /// </summary>
        private void AddTranslations()
        {
            //the Manager Prop in the translator obj, it used to manipulate the translations
            //remember that you can't have multiple TranslationsGroup with the same name
            translator.Manager.Add(new TranslationGroup("Hello_text"))
              .Add(new Translation(Languages.English_UnitedStates, "Hello there"))
              .Add(new Translation(Languages.Spanish_Spain, "Hola"))
              .Add(new Translation(Languages.Arabic_Morocco, "مرحبا"))
              .Add(new Translation(Languages.Chinese_China, "你好"))
              .Add(new Translation(Languages.French_France, "Salut"));

            //call the SaveToFileAsync() method to save the changes to your file
            translator.Manager.SaveToFileAsync();
        }

        #endregion

        public Form1()
        {
            InitializeComponent();
            InitializeTranslator();

            comboBox1.ValueMember = "Code";
            comboBox1.DisplayMember = "Name";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //populate the comboBox1 with the list of Languages
            comboBox1.DataSource = Language.GetLanguageList();

            //to show only the languages you want to make the user able to choose from you can use Linq
            //comboBox1.DataSource = Language.GetLanguageList()
            //    .Where(l => l.Code == "en-US" || l.Code == "fr-FR" || l.Code == "ar-MA" || l.Code == "zh-CN" || l.Code == "es-ES")
            //    .ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //we get the selected Language in the ComboBox, and then we change the Current language
            //for the global LanguageSetting Object
            Program.setting.CurrentLanguage = (Language)comboBox1.SelectedItem;
        }
    }
}
