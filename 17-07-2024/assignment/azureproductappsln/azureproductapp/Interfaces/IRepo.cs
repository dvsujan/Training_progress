namespace azureproductapp.Interfaces
{
    public interface IRepo<K, T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
    }
}
