using System;

namespace PatientService.Exceptions
{
    public class ContainsCharactersException : Exception
    {
        private new const string Message = "Element does not contain numbers only!";

        public ContainsCharactersException() : base(Message)
        {

        }
    }
}
