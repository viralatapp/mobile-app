using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using ViralatApp.Models;

namespace ViralatApp.Services
{
    public interface IViralataApi
    {
        #region Authentication

        [Post("/auth/login")]
        Task<HttpResponseMessage> Login([Body] RequestLogin requestLogin);

        [Post("/auth/register")]
        Task<HttpResponseMessage> Register([Body] User user);

        [Post("/auth/send-verification-email")]
        Task<HttpResponseMessage> VerificationEmail([Body]User user);
        [Post("/auth/reset-password")]
        Task<HttpResponseMessage> ResetPassword([Body]User user);
        #endregion

        #region  User

        [Get("/users/{id}")]
        Task<HttpResponseMessage> GetUserById(string id,[Header("Authorization")] string token);

        #endregion
        #region  Pet
        [Post("/pets")]
        Task<HttpResponseMessage> CreatePet([Header("Authorization")] string token,[Body]Pet pet);
        [Get("/pets")]
        Task<HttpResponseMessage> GetPets([Header("Authorization")] string token);
        [Get("/pets/{id}")]
        Task<HttpResponseMessage> GetPetById(string id,[Header("Authorization")] string token);
        #endregion
        
        #region  Adoption

        [Get("/adoptions")]
        Task<HttpResponseMessage> GetAdoptions([Header("Authorization")] string token);
        [Get("/adoptions/{id}")]
        Task<HttpResponseMessage> GetAdoptionsId(string id,[Header("Authorization")] string token);
        [Post("/adoptions")]
        Task<HttpResponseMessage> CreateAdoptions([Body]RequestAdoption requestAdoption,[Header("Authorization")] string token);
        #endregion

        #region  Application

        [Post("/applications")]
        Task<HttpResponseMessage> CreateApplication([Body] ApplicationAdopt questionnaire,[Header("Authorization")] string token);

        #endregion
    }
}