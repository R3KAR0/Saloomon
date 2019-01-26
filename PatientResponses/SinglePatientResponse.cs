using System;
using System.Collections.Generic;
using System.Text;
using PatientService.Models;

namespace PatientServiceResponseMessages
{
    public interface SinglePatientResponse
    {
        Patient Patient { get; }
    }
}
