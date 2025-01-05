using System;

namespace CookieCookbookApp.RecipesRepository;

 class StringsTextualRepository
{
    private static readonly string Separator = Environment.NewLine;


    public List<string> Read(string filePath)
    {
        var fileContents = File.ReadAllText(filePath);
        var namesFromFile = fileContents.Split(Separator).ToList();
        return namesFromFile;
    }

    public void Write(string filePath, List<string> strings) =>
        File.WriteAllText(filePath, string.Join(Separator, strings));


}




