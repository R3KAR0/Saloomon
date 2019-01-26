using System;
using System.Collections.Generic;
using System.Text;

namespace DatenakquirierungsServiceModels.Surgeries.SurgeryData
{
    public class GastricBandingSurgeryData : ASurgeryData
    {
        public LiverBiopsyData liverBiopsyData { get; set; }

        private string technique { get; set; }


        private string tapeType { get; set; }


        private string portLocalization { get; set; }


        private bool sekBanding { get; set; }


        private bool reBanding { get; set; }

        private string setting { get; set; }
    }
}
