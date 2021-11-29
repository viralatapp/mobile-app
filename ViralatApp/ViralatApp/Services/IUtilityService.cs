using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ViralatApp.Services
{
    public interface IUtilityService
    {
        Task<Placemark> GetCurrentPlaceLocation();
        Task<Location> GetCurrentLocation();
        void PlacePhoneCall(string number);
    }
}