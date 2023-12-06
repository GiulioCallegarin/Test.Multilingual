using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Test.Multilingual;

public static class LangHelper
{
    private static ResourceManager resourceManager;

    static LangHelper()
    {
        resourceManager = new ResourceManager("Test.Multilingual.Languages.strings", Assembly.GetExecutingAssembly());
    }

    public static string? GetString(string name)
    {
        return resourceManager.GetString(name);
    }

    public static void ChangeLanguage(string language)
    {
        try
        {
            var cultureInfo = new CultureInfo(language);

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
        }
        catch { }   
    }
}