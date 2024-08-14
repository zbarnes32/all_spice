namespace all_spice.Controllers;

[ApiController]
[Route("api/[recipes]")]

public class RecipeController : ControllerBase
{
    private readonly RecipesService _recipesService;

    public RecipeController(RecipesService recipesService)
    {
        _recipesService = recipesService;
    }
}
