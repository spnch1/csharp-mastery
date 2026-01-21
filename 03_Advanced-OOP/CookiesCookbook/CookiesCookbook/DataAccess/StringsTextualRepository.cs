namespace CookiesCookbook.DataAccess;

public class StringsTextualRepository : StringsRepository
{
    private static readonly string Separator = Environment.NewLine;

    protected override List<string> TextToStrings(string text) =>
        text.Split(Separator).ToList();

    protected override string StringsToText(List<string> strings) =>
        string.Join(Separator, strings);
}