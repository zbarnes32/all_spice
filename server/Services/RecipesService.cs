



namespace all_spice.Services;

public class RecipesService
{
    private readonly RecipesRepository _repository;

    public RecipesService(RecipesRepository repository)
    {
        _repository = repository;
    }

    public Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe recipe = _repository.CreateRecipe(recipeData);
        return recipe;
    }

    public List<Recipe> GetAllRecipes()
    {
        List<Recipe> recipes = _repository.GetAllRecipes();
        return recipes;
    }

    public Recipe GetRecipeById(int recipeId)
    {
       Recipe recipe = _repository.GetRecipeById(recipeId);

       if (recipe == null)
       {
        throw new Exception($"No recipe with the id of {recipeId}.");
       }
       return recipe; 
    }

    public Recipe UpdateRecipe(int recipeId, string userId, Recipe recipeData)
    {
        Recipe recipeToUpdate = GetRecipeById(recipeId);

        if (recipeToUpdate.CreatorId != userId)
        {
            throw new Exception("You are unable to update a recipe that you did not create.");
        }

        recipeToUpdate.Instructions = recipeData.Instructions ?? recipeToUpdate.Instructions;
        recipeToUpdate.Img = recipeData.Img ?? recipeToUpdate.Img;
        recipeToUpdate.Title = recipeData.Title ?? recipeToUpdate.Title;
        recipeToUpdate.Category = recipeData.Category ?? recipeToUpdate.Category;

        _repository.UpdateRecipe(recipeToUpdate);

        return recipeToUpdate;
    }

    public string DestroyRecipe(int recipeId, string userId)
    {
        Recipe recipe = GetRecipeById(recipeId);

        if(recipe.CreatorId != userId)
        {
            throw new Exception("You are not able to delete a recipe you didn't create.");
        }

        _repository.DestroyRecipe(recipeId);

        return "Recipe has been deleted.";
    }
}