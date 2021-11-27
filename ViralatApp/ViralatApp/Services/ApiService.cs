using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ViralatApp.Helpers;
using ViralatApp.Models;

namespace ViralatApp.Services
{
    public class ApiService:BaseService,IApiService
    {
        public ApiService() : base(new ApiClient<IViralataApi>(Config.ApiUrl))
        {
        }

        public async Task<AuthenticationResponse> Login(RequestLogin requestLogin)
        {   
            var response = await RemoteRequestAsync<AuthenticationResponse>(ViralataService.Client.Login(requestLogin));
            if (!response.SuccessResult)
                throw new Exception(response.ResponseMessage.ReasonPhrase);
            var result = response.Result;
            Settings.Token =  Task.FromResult(result.Tokens.Access.Token);
            return result;
        }

        public async Task<AuthenticationResponse> Register(User user)
        {
            var response = await RemoteRequestAsync<AuthenticationResponse>(ViralataService.Client.Register(user));
            if (!response.SuccessResult)
                throw new Exception(response.ResponseMessage.ReasonPhrase);
            var result = response.Result;
            Settings.Token =  Task.FromResult(result.Tokens.Access.Token);
            return result;
        }

        public async Task<HttpResponseMessage> VerificationEmail(User user)
        {
            var response = await RemoteRequestAsync<HttpResponseMessage>(ViralataService.Client.VerificationEmail(user));
            if (!response.SuccessResult)
                throw new Exception(response.ResponseMessage.ReasonPhrase);
            return response.Result;
        }

        public async Task<HttpResponseMessage> ResetPassword(User user)
        {
            var response = await RemoteRequestAsync<HttpResponseMessage>(ViralataService.Client.ResetPassword(user));
            if (!response.SuccessResult)
                throw new Exception(response.ResponseMessage.ReasonPhrase);
            return response.Result;
        }

        public async Task<User> GetUserById(string id)
        {
            var response = await RemoteRequestAsync<User>(ViralataService.Client.GetUserById(id,await Settings.Token));
            if (!response.SuccessResult)
                throw new Exception(response.ResponseMessage.ReasonPhrase);
            return response.Result;
        }

        public async Task<List<Pet>> GetPets()
        {
            var response = await RemoteRequestAsync<List<Pet>>(ViralataService.Client.GetPets(await Settings.Token));
            if (!response.SuccessResult)
                throw new Exception(response.ResponseMessage.ReasonPhrase);
            return response.Result;
        }

        public async Task<Pet> GetPetById(string id)
        {
            var response = await RemoteRequestAsync<Pet>(ViralataService.Client.GetPetById(id,await Settings.Token));
            if (!response.SuccessResult)
                throw new Exception(response.ResponseMessage.ReasonPhrase);
            return response.Result;
        }

        public async Task<List<Adoption>> GetAdoptions()
        {
            var response = await RemoteRequestAsync<List<Adoption>>(ViralataService.Client.GetAdoptions(await Settings.Token));
            if (!response.SuccessResult)
                throw new Exception(response.ResponseMessage.ReasonPhrase);
            return response.Result;
        }

        public async Task<Adoption> GetAdoptionsId(string id)
        {
            var response = await RemoteRequestAsync<Adoption>(ViralataService.Client.GetAdoptionsId(id,await Settings.Token));
            if (!response.SuccessResult)
                throw new Exception(response.ResponseMessage.ReasonPhrase);
            return response.Result;
        }

        public async Task<HttpResponseMessage> CreateAdoptions(RequestAdoption requestAdoption)
        {
            var response = await RemoteRequestAsync<HttpResponseMessage>(ViralataService.Client.CreateAdoptions(requestAdoption,await Settings.Token));
            if (!response.SuccessResult)
                throw new Exception(response.ResponseMessage.ReasonPhrase);
            return response.Result;
        }

        public async Task<HttpResponseMessage> CreateApplication(Questionnaire questionnaire)
        {
            var response = await RemoteRequestAsync<HttpResponseMessage>(ViralataService.Client.CreateApplication(questionnaire,await Settings.Token));
            if (!response.SuccessResult)
                throw new Exception(response.ResponseMessage.ReasonPhrase);
            return response.Result;
        }
    }
}