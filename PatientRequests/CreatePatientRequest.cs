using System;
using System.Collections.Generic;
using System.Text;
using PatientServiceModels;

namespace PatientServiceRequestMessages
{
    public interface CreatePatientRequest
    {

        string Title { get; set; }

        string SocialInsuranceNumber { get; set; }

        int GDPRAcceptedId { get; set; }

        bool StudyAccepted { get; set; }

        Gender Gender { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        DateTime BirthDate { get; set; }


        //PatientAddress
        string Street { get; set; }

        string ZipCode { get; set; }

        string Town { get; set; }

        Country Country { get; set; }



        int FolderId { get; }
    }
}
