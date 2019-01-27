using System;
using System.Collections.Generic;
using System.Text;
using PatientServiceModels;

namespace PatientServiceResponseMessages
{
    public interface SinglePatientResponse
    {
        Patient Patient { get; }
    }
}
