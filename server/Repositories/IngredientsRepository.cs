
namespace all_spice.Repositories;

public class IngredientsRepository
{
    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData, string userId)
    {
        string sql = @"
        INSERT INTO
        ingredients(name, quantity, recipeId)
        VALUES(@Name, @Quantity, @RecipeId);

        SELECT
        *
        FROM ingredients
        WHERE ingredients.id = LAST_INSERT_ID();";

        Ingredient ingredient = _db.Query<Ingredient>(sql, ingredientData).FirstOrDefault();
            return ingredient;
    }
    
}