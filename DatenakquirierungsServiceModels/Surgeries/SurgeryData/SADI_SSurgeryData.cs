using System;
using System.Collections.Generic;
using System.Text;

namespace DatenakquirierungsServiceModels.Surgeries.SurgeryData
{
    public class SADI_SSurgeryData : ASurgeryData
    {
        public LiverBiopsyData liverBiopsyData { get; set; }

        public string technique { get; set; }

        public string banded { get; set; }

        public string setting { get; set; }

        public string sutureFixation { get; set; }

        public float commonChannel { get; set; }

        public float calibrationProbe { get; set; }

        public float resectedVolume { get; set; }

        public bool sekBanding { get; set; }

        public bool reBanding { get; set; }
    }
}
