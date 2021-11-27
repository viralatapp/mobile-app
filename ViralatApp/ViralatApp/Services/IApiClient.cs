namespace ViralatApp.Services
{
    public interface IApiClient<T>
    {
        T Client { get; }
    }
}