# YiSoTranslator
YiSoTranslator is an open source plugin that will allows you to add multi language functionality to your applications (tested on winforms and WPF), the plugin is build on .Net Standard 2.0 ,and works properly on .Net 4.6.1 and higher.
## How it works
the idea of the app is base on saving the translations using a `IYiSoTranslationProvider`, and retrieve the translations as objects. when you install the plugin,
you also need to install the provider, for now we only have a JSON provider, that will allow you to work with translation using json file files.

the translation are wrapped inside a `TranslationsGroup` Object, this object have a unique name and a List of translations:

* The "Name" is used to specified the Translation Group name (should be unique).  
* The "TranslationsList" used to store the list of translations of the group, each translation in the list is an object with two properties:  
  - "LanguageCode" which hold the the code of the language of the translation.
  - "Value" which represent the actual translation.

the first translation in the list is you default language. if no translation found for a given language the plugin will return the value of the default language, and if you didn't specified the default language the plugin will throw an exception.

if the given translation name not found an exception will be thrown, also if you add a translation group name which already exist an exception will be thrown.
  
to start using the Translator first you need to config your `LanguageSettings`, and that will be by getting an instant of the `LanguageSetting` object and setting the Default, and the Current Language:  
```
  public static void Initialize()
  {
    LanguageSetting.Instant.DefaultLanguage = GetDefaultLanguage();
    LanguageSetting.Instant.CurrentLanguage = GetCurrentLanguage();
  }

  private static Language GetDefaultLanguage()
  {
    //ToDo : implement your own logic for retrieving the Current language
    return Language.GetByEnum(Languages.English_UnitedStates);
  }

  public static Language GetCurrentLanguage()
  {
    //ToDo : implement your own logic for retrieving the Current language
    return Language.GetByEnum(Languages.Arabic_Morocco);
  }
```  

now you can call the Initialize() method in your main method.

than the next step is to construct your Translator object :  
```
  #region Translator Configuration

  private Translator translator;

  private void InitializeTranslator()
  {
    IYiSoTranslationProvider provider = GetTheProvider();
    translator = new Translator(provider);

    //Here we listen for the Changes in the current language, 
    //if it changed we reload the translation Asynchronously
    translator.CurrentLanguageChanged += (s, e) => GetTranslationsAsync();

    //we call this function to load the translations for the first time
    GetTranslationsAsync();
  }

  private async void GetTranslationsAsync()
  {
    //Make the calls to your translations
    label1.Text = await translator.GetTextAsync("Email_text");
    button1.text = await translator.GetTextAsync("Submit_text");
    ...
  }

  #endregion

```  
the Translator Object tacks only one parameter and that is the provider that you will be using to work with the translation

now to get the translation simply call the GetText() method like so:  
`translator.GetText("translationName")`  
the function will return the convenient translation for the current language specified in the Language Setting object, if no translation found the default translation will be returned, if default not found an exception will be thrown.

if you want to add translations you can do it manually, or from code like so:
```
private void AddTranslations()
{
  translator.Manager.Add(new TranslationGroup("Hello_text"))
    .Add(new Translation(Languages.English_UnitedStates, "Hello there"))
    .Add(new Translation(Languages.Spanish_Spain, "Hola"))
    .Add(new Translation(Languages.Arabic_Morocco, "مرحبا"))
    .Add(new Translation(Languages.Chinese_China, "你好"))
    .Add(new Translation(Languages.French_France, "Salut"));

  translator.Manager.SaveToFileAsync();
}
```
"Translator" expose a property which is of type "TranslationGroupManager" allowing to manage the list of the translations, so that you can add translation Groups and the there translations, once you finish you can call the SaveChanges()Method on the Manager property to save the the changes.

## Tools For the plugin
We have created simple Code snippets that you can use to make your coding faster, which you can download from here: [Click here](https://github.com/YoussefSell/YiSoTranslator/raw/master/YiSoTranslator%20Snippets.zip.zip)  

## Getting Started
add the YiSoTranslator package to your project by using he nuget package manager or nuget package manager console:  
`PM> Install-Package YiSoTranslator`  
