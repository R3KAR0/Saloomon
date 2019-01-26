using System;
using System.Collections.Generic;
using System.Text;

namespace DatenakquirierungsServiceModels.Surgeries.SurgeryData
{
    public class BDPSurgeryData : ASurgeryData
    {
        public LiverBiopsyData LiverBiopsyData { get; set; }
        public string techniqueBiliodigestive { get; set; }
        public string techniqueAlimentary { get; set; }

        public string staplerSizeBiliodigestive { get; set; }

        public string staplerSizeAlimentary { get; set; }

        public float biliodigestiveLeg { get; set; }

        public float alimentaryLeg { get; set; }

        public float commonChannel { get; set; }

        public bool mesoSlot { get; set; }

        public bool petersensSpace { get; set; }
    }
}
