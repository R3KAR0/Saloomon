using System;

namespace PatientServiceModels.Exceptions
{
    public class InvalidBirthDateException : Exception
    {
        public InvalidBirthDateException(string message) : base(message) { }
    }
}
