using System.Diagnostics;
using Test.Multilingual;

Stopwatch sw = new Stopwatch();

sw.Start();

for (int i = 0; i < 100; i++)
{
    LangHelper.ChangeLanguage("en");
    LangHelper.GetString("hello");
    LangHelper.GetString("world");
    LangHelper.ChangeLanguage("it");
    LangHelper.GetString("hello");
    LangHelper.GetString("world");
}

sw.Stop();
Console.WriteLine(sw.ElapsedMilliseconds.ToString());


sw = new Stopwatch();
sw.Start();

for (int i = 0; i < 100; i++)
{
    LangHelper2.GetString("hello", "en");
    LangHelper2.GetString("world", "en");
    LangHelper2.GetString("hello", "it");
    LangHelper2.GetString("world", "it");
}

sw.Stop();
Console.WriteLine(sw.ElapsedMilliseconds.ToString());
