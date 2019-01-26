using System;
using System.Collections.Generic;
using System.Text;
using DatenakquirierungsServiceModels.FollowUps.WeightRegain;
using DatenakquirierungsServiceModels.Surgeries.AccompanyingSurgeryData;
using DatenakquirierungsServiceModels.Surgeries.IntraoperativeSurgeryData;
using DatenakquirierungsServiceModels.Surgeries.PatientData;
using DatenakquirierungsServiceModels.Surgeries.PreviousSurgeryData;

namespace DatenakquirierungsServiceModels.FollowUps
{
    public class WeightRegainSurgeryData : AFollowUp
    {
        public AExtendedPatientData extendedPatientData { get; set; }

        public APreSurgeryData preSurgeryData { get; set; }

        public WeightRegainSurgeryData weightRegainSurgeryData { get; set; }

        public WeightRegainPatientData beforeSurgery { get; set; }

        public WeightRegainPatientData afterSurgery { get; set; }

        public AAccompanyingSurgeryData aAccompanyingSurgeryData { get; set; }

        public AIntraoperativeComorbiditiesData intraoperativeComorbiditiesData { get; set; }
    }
}
