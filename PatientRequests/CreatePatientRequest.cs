using System;
using System.Collections.Generic;
using System.Text;
using PatientService.Models;

namespace PatientServiceRequestMessages
{
    public interface CreatePatientRequest
    {
        Patient Patient { get; }
        int FolderId { get; }
    }
}
