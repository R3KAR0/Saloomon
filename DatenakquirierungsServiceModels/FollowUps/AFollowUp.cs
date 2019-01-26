using System;
using System.Collections.Generic;
using System.Text;
using DatenakquirierungsServiceModels.Surgeries.PatientData;

namespace DatenakquirierungsServiceModels.FollowUps
{
    public abstract class AFollowUp : AEntity
    {
        public APatientData patientData { get; set; }
    }
}
