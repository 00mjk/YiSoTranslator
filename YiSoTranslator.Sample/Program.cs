using System;
using System.Windows.Forms;
using YiSoTranslator;

namespace YiSoTranslator.Sample
{
    static class Program
    {
        public static LanguageSetting setting;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            setting = new LanguageSetting(Languages.Arabic_Morocco, Languages.English_UnitedStates);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
