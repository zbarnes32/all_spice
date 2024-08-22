
namespace all_spice.Services;

public class IngredientsService
{
    private readonly IngredientsRepository _repository;
    private readonly RecipesService _recipesService;

    public IngredientsService(IngredientsRepository repository, RecipesService recipesService)

    {
        _repository = repository;
        _recipesService = recipesService;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData, string userId)
    {
        Recipe recipe = _recipesService.GetRecipeById(ingredientData.RecipeId);

        if (userId != recipe.CreatorId)
        {
            throw new Exception("Unable to add ingredient to a recipe you did not create.");
        }

        Ingredient ingredient = _repository.CreateIngredient(ingredientData, userId);
        return ingredient;
    }
}