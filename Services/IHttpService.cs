
namespace DBSQLite.Services
{
    public interface IHttpService
    {
        void SetBaseUri(string baseUri);
        Task<T> GetAsync<T>(string url);
    }
}