using System;
using System.Collections.Generic;
using System.Text;

namespace DatenakquirierungsServiceModels.Surgeries.SurgeryData
{
    public class WeightRegainData : ASurgeryData
    {
        public LiverBiopsyData liverBiopsyData { get; set; }

        public string technique1 { get; set; }

        public string technique2 { get; set; }

        public string technique3 { get; set; }

        public string technique4 { get; set; }

        public string staplerSize1 { get; set; }

        public string staplerSize2 { get; set; }

        public string staplerSize3 { get; set; }

        public string staplerSize4 { get; set; }

        public string banded { get; set; }

        public string setting { get; set; }

        public string sutureFixation { get; set; }

        public float calibrationProbe { get; set; }

        public float resectedVolume { get; set; }

        public bool sekBanding { get; set; }

        public bool reBanding { get; set; }

        public bool mesoSlot { get; set; }

        public bool petersensSpace { get; set; }
    }
}
