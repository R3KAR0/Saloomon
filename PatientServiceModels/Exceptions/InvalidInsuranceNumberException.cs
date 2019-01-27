using System;

namespace PatientServiceModels.Exceptions
{
    public class InvalidInsuranceNumberException : Exception
    {
        public InvalidInsuranceNumberException(string message) : base(message)
        {

        }
    }
}
