
using CookieCookbookApp;
using CookieCookbookApp.Recipes;
using CookieCookbookApp.App;
using CookieCookbookApp.DataAccess;
using CookieCookbookApp.FileAccess;

const FileFormat Format = FileFormat.Json;
const string FileName = "recipe";
FileMetaData fileMetaData = new FileMetaData(FileName, Format);


IStringsRepository stringsRepository = Format == FileFormat.Text ? new StringsTextRepository() : new StringsJsonRepository();

var ingredientsRegister = new IngredientsRegister();
var cookiesCookbook = new CookiesCookbook(
    new RecipesRepository(
        new StringsTextRepository(),
        ingredientsRegister
    ),
    new RecipesConsoleUserInteraction(
        ingredientsRegister
    )
);

cookiesCookbook.Open(fileMetaData.ToPath());
