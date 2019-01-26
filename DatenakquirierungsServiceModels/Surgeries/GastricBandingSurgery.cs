using System;
using System.Collections.Generic;
using System.Text;
using DatenakquirierungsServiceModels.Surgeries.SurgeryData;

namespace DatenakquirierungsServiceModels.Surgeries
{
    public class GastricBandingSurgery : ASurgery
    {
        public GastricBandingSurgeryData surgeryData { get; set; }
    }
}
