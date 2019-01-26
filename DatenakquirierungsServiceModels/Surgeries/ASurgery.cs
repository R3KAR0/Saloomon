using System;
using System.Collections.Generic;
using System.Text;
using DatenakquirierungsServiceModels.FollowUps;
using DatenakquirierungsServiceModels.Surgeries.AccompanyingSurgeryData;
using DatenakquirierungsServiceModels.Surgeries.IntraoperativeSurgeryData;
using DatenakquirierungsServiceModels.Surgeries.PatientData;
using DatenakquirierungsServiceModels.Surgeries.PreviousSurgeryData;

namespace DatenakquirierungsServiceModels.Surgeries
{
    public abstract class ASurgery : AEntity
    {
        public AExtendedPatientData patientData { get; set; }

        public APreSurgeryData preSurgeryData { get; set; }

        public AAccompanyingSurgeryData accompanyingSurgeryData { get; set; }

        public AIntraoperativeComorbiditiesData comorbiditiesData { get; set; }

        public DateTime creationDate { get; set; }

        public List<AFollowUp> followUpList { get; set; }
    }
}
