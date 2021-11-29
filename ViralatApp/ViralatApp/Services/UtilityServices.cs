using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ViralatApp.Services
{
    public class UtilityService:IUtilityService
    {
        public async Task<Placemark> GetCurrentPlaceLocation()
        {
            try
            {
                var location = await GetCurrentLocation();
                if (location == null)
                    return null;
                var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);
                return     placemarks?.FirstOrDefault();;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
                throw fnsEx;
            }
            catch (Exception ex)
            {
                // Handle exception that may have occurred in geocoding
                throw ex;
            }
        }
        public void PlacePhoneCall(string number)
        {
            try
            {
                PhoneDialer.Open(number);
            }
            catch (ArgumentNullException anEx)
            {
                throw anEx;
            }
            catch (FeatureNotSupportedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }
        public async Task<Location> GetCurrentLocation()
        {
            try
            {
                var location = await Geolocation.GetLocationAsync();

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }

                return location;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                throw fnsEx;
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                throw fneEx;
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                throw pEx;
            }
            catch (Exception ex)
            {
                // Unable to get location
                throw ex;
            }
        }
    }
}