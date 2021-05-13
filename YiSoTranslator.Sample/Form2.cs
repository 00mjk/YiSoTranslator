using System.Windows.Forms;
using YiSoTranslator;

namespace YiSoTranslator.Sample
{
    public partial class Form2 : Form
    {
        #region Translator Configuration

        /// <summary>
        /// the Translator Object, which is responsible for managing the translations
        /// </summary>
        private Translator translator;

        /// <summary>
        /// this method is used to Initialize the Translator object
        /// </summary>
        private void InitializeTranslator()
        {
            //the 'Form1.json' is the name of the translation witch contain the translation for this Form
            translator = new Translator("main.json", Program.setting);

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

        #endregion

        public Form2()
        {
            InitializeComponent();
            InitializeTranslator();
        }

        private void Form2_Load(object sender, System.EventArgs e)
        {

        }
    }
}
