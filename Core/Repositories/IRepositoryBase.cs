namespace JobsApi.Core.Repositories
{
  public interface IRepositoryBase<Model, Id>
  {
    Model Create(Model data);
    Model? FindById(Id id);
    bool ExistsById(Id id);
    ICollection<Model> FindAll();
    Model Update(Model data);
    void DeleteById(Id id);
  }
}