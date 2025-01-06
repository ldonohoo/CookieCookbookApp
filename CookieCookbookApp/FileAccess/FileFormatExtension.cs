

namespace CookieCookbookApp.FileAccess;

public static class FileFormatExtension
{
    public static string AsFileExtension(this FileFormat fileFormat)
    {
        return fileFormat == FileFormat.Text ? "txt" : "json";
    }
    
}
