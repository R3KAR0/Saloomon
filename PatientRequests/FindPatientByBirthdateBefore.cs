using System;
using System.Collections.Generic;
using System.Text;

namespace PatientServiceRequestMessages
{
    public interface FindPatientByBirthdateBefore
    {
        DateTime Before { get; }
    }
}
