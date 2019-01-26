using System;

namespace PatientService.Exceptions
{
    public class InvalidInsuranceNumberException : Exception
    {
        public InvalidInsuranceNumberException(string message) : base(message)
        {

        }
    }
}
