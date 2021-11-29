using System;
using ViralatApp.Helpers;
using ViralatApp.Helpers.ValidationRules;

namespace ViralatApp.Models
{
    public class UserValidator
    {
        public ValidatableObject<string> Name { get; set; }
        public ValidatableObject<string> FirstName { get; set; }
        public ValidatableObject<string> LastName { get; set; }
        public ValidatableObject<string> Address { get; set; }
        public ValidatableObject<string> City { get; set; }
        public ValidatableObject<string> Country { get; set; }
        public DateTime DateBirth { get; set; }=DateTime.Today;

        public UserValidator()
        {
            Name = new ValidatableObject<string>()
            {
                Validations = { new IsNotNullOrEmptyRule<string>() }
            };
            FirstName = new ValidatableObject<string>()
            {
                Validations = { new IsNotNullOrEmptyRule<string>() }
            };
            Address = new ValidatableObject<string>()
            {
                Validations = { new IsNotNullOrEmptyRule<string>() }
            };
            City = new ValidatableObject<string>()
            {
                Validations = { new IsNotNullOrEmptyRule<string>() }
            };
            Country = new ValidatableObject<string>()
            {
                Validations = { new IsNotNullOrEmptyRule<string>() }
            };
        }

        public bool IsValid => Name.IsValid && FirstName.IsValid && Address.IsValid && City.IsValid && Country.IsValid;


    }
}