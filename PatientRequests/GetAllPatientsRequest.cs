using System;
using System.Collections.Generic;
using System.Text;

namespace PatientServiceRequestMessages
{
    public interface GetAllPatientsRequest
    {
        string UserID { get; set; }
    }
}
