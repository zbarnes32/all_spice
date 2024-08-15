
using System.Windows.Markup;

namespace all_spice.Repositories;

public class RecipesRepository
{
    private readonly IDbConnection _db;

    public RecipesRepository(IDbConnection db)
    {
        _db = db;
    }

    public Recipe CreateRecipe(Recipe recipeData)
    {
        string sql = @"
        INSERT INTO
        recipes(title, instructions, img, category, creatorId)
        VALUES(@Title, @Instructions, @Img, @Category, @CreatorId);

        SELECT
        recipes.*,
        accounts.*
        FROM recipes 
        JOIN accounts ON accounts.id = recipes.creatorId
        WHERE recipes.id = LAST_INSERT_ID();";

        Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
        {
            recipe.Creator = profile;
            return recipe;
        }, recipeData).FirstOrDefault();
        return recipe;
    }

    internal List<Recipe> GetAllRecipes()
    {
        string sql = @"
        SELECT
        recipes.*,
        accounts.*
        FROM recipes
        JOIN accounts ON accounts.id = recipes.creatorId;";

        List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) => 
        {
            recipe.Creator = profile;
            return recipe;
        }).ToList();

        return recipes;
    }

    public Recipe GetRecipeById(int recipeId)
    {
       string sql = @"
       SELECT
       recipes.*,
       accounts.*
       FROM recipes
       JOIN accounts ON accounts.id = recipes.creatorId
       WHERE recipes.id = @recipeId;";

       Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) => 
       {
        recipe.Creator = profile;
        return recipe;
       }, new {recipeId}).FirstOrDefault();

       return recipe;
    }

    public void UpdateRecipe(Recipe recipeToUpdate)
    {
        string sql =@"
        UPDATE
        recipes
        SET
        instructions = @Instructions,
        img = @Img,
        title = @Title,
        category = @category
        WHERE id = @Id LIMIT 1;";

        int rowsAffected = _db.Execute(sql, recipeToUpdate);

        if (rowsAffected == 0) throw new Exception("Unable to update");
        if (rowsAffected > 1) throw new Exception("Updated too many recipes");
    }

    public void DestroyRecipe(int recipeId)
    {
        string sql = "DELETE FROM recipes WHERE id = @recipeId LIMIT 1 ;";

        int rowsAffected = _db.Execute(sql, new { recipeId });

        if(rowsAffected == 0) throw new Exception("Unable to delete.");
        if (rowsAffected > 1) throw new Exception("Deleted more than attended.");

    }
}

