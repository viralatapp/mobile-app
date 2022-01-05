using System;
using ViralatApp.Helpers;
using ViralatApp.Helpers.ValidationRules;

namespace ViralatApp.Models
{
    public class UserValidator
    {
        public ValidatableObject<string> Name { get; set; }
        public ValidatableObject<string> Address { get; set; }
        public ValidatableObject<string> City { get; set; }
        public ValidatableObject<string> Country { get; set; }
        public DateTime DateBirth { get; set; } = DateTime.Today.AddYears(-5).AddDays(-25);

        public UserValidator()
        {
            Name = new ValidatableObject<string>()
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

        public bool IsValid => Name.IsValid && Address.IsValid && City.IsValid && Country.IsValid;
    }
}