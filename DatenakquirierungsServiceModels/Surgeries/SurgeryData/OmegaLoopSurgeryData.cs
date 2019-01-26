using System;
using System.Collections.Generic;
using System.Text;

namespace DatenakquirierungsServiceModels.Surgeries.SurgeryData
{
    public class OmegaLoopSurgeryData
    {
        public LiverBiopsyData liverBiopsyData { get; set; }

        public string technique { get; set; }

        public string banded { get; set; }

        public string setting { get; set; }

        public string sutureFixation { get; set; }

        public float staplerSize { get; set; }

        public float olbLoop { get; set; }

        public float commonChannel { get; set; }

        public bool mesoSlot { get; set; }
    }
}
