using System;
using System.Collections.Generic;
using System.Text;
using PatientServiceModels;

namespace PatientServiceResponseMessages
{
    public interface PatientListResponse
    {
        List<Patient> Patients { get; }
    }
}
