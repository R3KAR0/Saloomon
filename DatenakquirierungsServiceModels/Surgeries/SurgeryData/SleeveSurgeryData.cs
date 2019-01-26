using System;
using System.Collections.Generic;
using System.Text;

namespace DatenakquirierungsServiceModels.Surgeries.SurgeryData
{
    public class SleeveSurgeryData : ASurgeryData
    {
        public string technique { get; set; }

        public string setting { get; set; }

        public string sutureFixation { get; set; }

        public float calibrationProbe { get; set; }

        public float resectedVolume { get; set; }

        public bool sekBanding { get; set; }

        public bool reBanding { get; set; }
    }
}
