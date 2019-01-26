using System;
using System.Collections.Generic;
using System.Text;
using PatientService.Models;

namespace PatientServiceResponseMessages
{
    public interface PatientListResponse
    {
        List<Patient> Patients { get; }
    }
}
