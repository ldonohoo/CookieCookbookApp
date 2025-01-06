using System.Text.Json;
namespace CookieCookbookApp.DataAccess;

class StringsJsonRepository : StringsRepository
{
    private static readonly string Separator = Environment.NewLine;
    protected override List<string> TextToStrings(string fileContents) =>
        JsonSerializer.Deserialize<List<string>>(fileContents);

    protected override string StringsToText(List<string> strings) =>
         JsonSerializer.Serialize(strings);
}