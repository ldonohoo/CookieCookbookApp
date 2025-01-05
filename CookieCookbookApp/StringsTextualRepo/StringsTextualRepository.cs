using System;

namespace CookieCookbookApp.StringsTextRepo;

interface IStringsRepository
{
    List<string> Read(string filePath);
    void Write(string filePath, List<string> strings);
}

// reads lines from file into a list of strings 
// writes from a list of strings to lines in a file
 class StringsTextRepository : IStringsRepository
{
    private static readonly string Separator = Environment.NewLine;

    public List<string> Read(string filePath)
    {
        // reads file into giant string
        var fileContents = File.ReadAllText(filePath); 
        // splits string into list of strings, separating on new lines
        var linesFromFile = fileContents.Split(Separator).ToList();
        return linesFromFile;
    }

    public void Write(string filePath, List<string> strings) =>
    // writes the list to a giant string, joining together list elements
    //   with newline characters to put each element in list on a line
        File.WriteAllText(filePath, string.Join(Separator, strings));
}

 class StringsJsonRepository : IStringsRepository
{
    private static readonly string Separator = Environment.NewLine;

    public List<string> Read(string filePath)
    {
        // reads file into giant string
        var fileContents = File.ReadAllText(filePath); 
        // splits string into list of strings, separating on new lines
        var linesFromFile = fileContents.Split(Separator).ToList();
        return linesFromFile;
    }

    public void Write(string filePath, List<string> strings) =>
    // writes the list to a giant string, joining together list elements
    //   with newline characters to put each element in list on a line
        File.WriteAllText(filePath, string.Join(Separator, strings));



}




