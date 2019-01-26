using System;

namespace PatientService.Exceptions
{
    public class InvalidBirthDateException : Exception
    {
        public InvalidBirthDateException(string message) : base(message) { }
    }
}
