using System;
using System.Collections.Generic;
using System.Text;

namespace DatenakquirierungsServiceModels.Surgeries.SurgeryData
{
    public class GastricBypassSurgeryData : ASurgeryData
    {
        private LiverBiopsyData liverBiopsyData { get; set; }

        private string staplerSizeBiliodigestive { get; set; }

        private string staplerSizeAlimentary { get; set; }

        private float techniqueBiliodigestiveLeg { get; set; }

        private float techniqueAlimentaryLeg { get; set; }

        private string banded { get; set; }

        private string setting { get; set; }

        private string sutureFixation { get; set; }

        private float biliodigestiveLeg { get; set; }

        private float alimentaryLeg { get; set; }

        private float commonChannel { get; set; }

        private bool sekBanding { get; set; }

        private bool reBanding { get; set; }

        private bool mesoSlot { get; set; }

        private bool petersensSpace { get; set; }
    }
}
