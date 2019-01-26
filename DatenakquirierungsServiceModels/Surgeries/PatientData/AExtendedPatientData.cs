using System;

namespace DatenakquirierungsServiceModels.Surgeries.PatientData
{
    public abstract class AExtendedPatientData : APatientData
    {
        public string surgicalProcedure { get; set; }

        public DateTime surgeryDate { get; set; }
    }
}
