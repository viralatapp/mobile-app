using System;
using System.Net.Http;
using Refit;

namespace ViralatApp.Services
{
    public class ApiClient<T> : IApiClient<T>
    {
        Func<T> createClient;
        Lazy<T> lazyClient;

        public ApiClient(string apiBaseAddress)
        {
            createClient = () =>
            {
                var client = new HttpClient()
                {
                    BaseAddress = new Uri(apiBaseAddress)
                };

                return RestService.For<T>(client);
            };
        }


        public T Client
        {
            get
            {
                if (lazyClient == null)
                {
                    lazyClient = new Lazy<T>(() => createClient());
                }
                return lazyClient.Value;
            }
        }
    }
}