namespace CookieCookbookApp.DataAccess;

// this follows the template method design pattern!
// - the read and write methods below are ALMOST the same for json and text file storage
// - the two abstract methods converting between file text and strings are defined in the abstract method
//      - these two abstract methods are implemented twice in two different derived classes
//             - StringstTextRepository and StringsJsonRepository!
public abstract class StringsRepository : IStringsRepository
{
    public List<string> Read(string filePath)
    {
        if (File.Exists(filePath))
        {
            // reads file into giant string
            var fileContents = File.ReadAllText(filePath); 
            // splits string into list of strings, separating on new lines
            var linesFromFile = TextToStrings(fileContents);
            return linesFromFile;
        }
        return new List<string>();
    }

    public void Write(string filePath, List<string> strings) =>
    // writes the list to a giant string, joining together list elements
    //   with newline characters to put each element in list on a line
        File.WriteAllText(filePath, StringsToText(strings));

    protected abstract List<string> TextToStrings(string fileContents);
    protected abstract string StringsToText(List<string> strings);
}
