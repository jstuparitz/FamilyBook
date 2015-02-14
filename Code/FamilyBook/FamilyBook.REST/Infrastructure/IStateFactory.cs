namespace FamilyBook.REST.Infrastructure
{
    public interface IStateFactory<TModel, TState>
    {
        TState Create(TModel model);
    }
}