using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;
using ViralatApp.Models;

namespace ViralatApp.Services
{
    public interface IApiService
    {
        #region Authentication

        Task<AuthenticationResponse> Login( RequestLogin RequestLogin);


        Task<AuthenticationResponse> Register( User user);


        Task<HttpResponseMessage> VerificationEmail(User user);

        Task<HttpResponseMessage> ResetPassword(User user);
        #endregion

        #region  User

        Task<User> GetUserById(string id);

        #endregion
        #region  Pet

        Task<List<Pet>> GetPets();

        Task<Pet> GetPetById(string id);
        #endregion
        
        #region  Adoption


        Task<List<Adoption>> GetAdoptions();
        Task<Adoption> GetAdoptionsId(string id);

        Task<HttpResponseMessage> CreateAdoptions(RequestAdoption requestAdoption);
        #endregion

        #region  Application

        Task<HttpResponseMessage> CreateApplication( Questionnaire questionnaire);

        #endregion
    }
}