using System;
using System.Collections.Generic;
using System.Text;
using PatientServiceModels;

namespace HTTPRequestModels
{
    public class CreatePatientModel
    {
        public string Title { get; set; }

        public string SocialInsuranceNumber { get; set; }

        public int GDPRAcceptedId { get; set; }

        public bool StudyAccepted { get; set; }

        public Gender Gender { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }


        //PatientAddress
        public string Street { get; set; }

        public string ZipCode { get; set; }

        public string Town { get; set; }

        public Country Country { get; set; }



        public int FolderId { get; }
    }
}
