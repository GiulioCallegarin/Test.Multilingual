using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Test.Multilingual;

public static class LangHelper2
{
    private static Dictionary<string, ResourceManager> managers;
    private static string[] languages = ["en", "it"];
    private static string defaultLanguage = languages[0];

    static LangHelper2()
    {
        Console.WriteLine(Directory.GetCurrentDirectory());
        managers = new Dictionary<string, ResourceManager>();
        foreach (string language in languages)
            managers.Add(language, new ResourceManager($"Test.Multilingual.Locales.{language}.translations", Assembly.GetExecutingAssembly()));
    }

    public static string? GetString(string name, string? language = null)
    {
        if (language is null) language = defaultLanguage;
        try { return managers[language].GetString(name); }
        catch { return managers[defaultLanguage]?.GetString(name); }
    }

    public static void ChangeLanguage(string language)
    {
        var cultureInfo = new CultureInfo(language);

        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;
    }
}