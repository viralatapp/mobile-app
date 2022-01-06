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

            //Reemplaza la data que sabemos que está vacía con información de ejemplo. 
            /*return new User()
            {
                Name = response.Result.Name,
                Description = "Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años, sino que tambien ingresó como texto de relleno en documentos electrónicos, quedando esencialmente igual al original",
                Email = response.Result.Email,
                AdoptionHistory = new List<string>()
                {
                    "Ha adoptado a una perrita de 5 meses llamada Diana el día 25/09/2021.",
                    "Ha apadrinado a Spy, un cachorro de 3 meses.",
                    "Ha adoptado a un gato con  2 semanas de nacido."
                },
                BirthDate = response.Result.BirthDate,
                Address = response.Result.Address,
                City= response.Result.City,
                Country=response.Result.Country,
                Phone="809-568-2222"
            };*/
            /*return new User()
            {
                Name ="Juan Pérez González" ,
                Description = "Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen. No sólo sobrevivió 500 años, sino que tambien ingresó como texto de relleno en documentos electrónicos, quedando esencialmente igual al original",
                Email= "Juan@gmail.Com",
                AdoptionHistory = new List<string>()
                {
                    "Ha adoptado a una perrita de 5 meses llamada Diana el día 25/09/2021.",
                    "Ha apadrinado a Spy, un cachorro de 3 meses.",
                    "Ha adoptado a un gato con  2 semanas de nacido."
                }
            };*/

        }

        public async Task<List<Pet>> GetPets()
        {
            var response = await RemoteRequestAsync<PetResponse>(ViralataService.Client.GetPets(await Settings.Token));
            if (!response.SuccessResult)
                throw new Exception(response.ResponseMessage.ReasonPhrase);
            return response.Result.Results;
            
            // return new List<Pet>
            // {
            //     new Pet
            //     {
            //         Name = "Linda", Image = "firstPet", Breed = "Mestizo", Age = 12, Sex = $"{EGender.Masculino}",Type = "Perros"
            //     },
            //     new Pet
            //     {
            //         Name = "Kiko", Image = "secondPet", Breed = "Mestizo", Age = 3, Sex = $"{EGender.Masculino}",Type = "Perros"
            //     },
            //     new Pet { Name = "Coco", Image = "thridPet", Breed = "Mestizo", Age = 5, Sex = $"{EGender.Masculino}",Type = "Perros"},
            //     new Pet { Name = "Shira", Image = "fourthPet", Breed = "Mestizo", Age = 52, Sex = $"{EGender.Femenino}",Type = "Perros"}
            // };
        }

        public async Task<PetForm> CreatePet(PetForm pet)
        {
            var response = await RemoteRequestAsync<PetForm>(ViralataService.Client.CreatePet(await Settings.Token, pet));
            if (!response.SuccessResult)
                throw new Exception(response.ResponseMessage.ReasonPhrase);
            return response.Result;
        }

        public async Task<List<Category>> GetCategories()
        {
            return new List<Category>
            {
                new Category("dog", "dogCategory"),
                new Category("Cat", "catCategory"),
                new Category("Birds", "birdCategory")
            };
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

        public async Task<Adoption> CreateAdoptions(RequestAdoption requestAdoption)
        {
            var response = await RemoteRequestAsync<Adoption>(ViralataService.Client.CreateAdoptions(requestAdoption,await Settings.Token));
            if (!response.SuccessResult)
                throw new Exception(response.ResponseMessage.ReasonPhrase);
            return response.Result;
        }

        public async Task<HttpResponseMessage> CreateApplication(ApplicationAdopt questionnaire)
        {
            var response = await RemoteRequestAsync<HttpResponseMessage>(ViralataService.Client.CreateApplication(questionnaire,await Settings.Token));
            if (!response.SuccessResult)
                throw new Exception(response.ResponseMessage.ReasonPhrase);
            return response.Result;
        }
    }
}