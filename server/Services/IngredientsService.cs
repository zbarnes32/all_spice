namespace all_spice.Services;

public class IngredientsService
{
    private readonly IngredientsRepository _repository;

    public IngredientsService(IngredientsRepository repository)

    {
        _repository = repository;
    }
}