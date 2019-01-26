using System;
using System.Collections.Generic;
using System.Text;

namespace DatenakquirierungsServiceModels.FollowUps.WeightRegain
{
    public class WeightRegainPatientData : AEntity
    {
        public float olbLoop { get; set; }

        public float biliopancreaticLeg { get; set; }

        public float alimentaryLeg { get; set; }

        public float commonChannel { get; set; }
    }
}
