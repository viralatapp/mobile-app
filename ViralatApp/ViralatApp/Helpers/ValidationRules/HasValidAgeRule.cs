using System;

namespace ViralatApp.Helpers.ValidationRules
{
    public class HasValidAgeRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }
        public int MinimumAge { get; set; }
        public bool Check(T value)
        {
            if (value is DateTime bday)
            {
                DateTime today = DateTime.Today;
                int age = today.Year - bday.Year;
                return (age >= MinimumAge);
            }

            return false;
        }
    }
}