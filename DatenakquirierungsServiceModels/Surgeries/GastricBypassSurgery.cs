using System;
using System.Collections.Generic;
using System.Text;
using DatenakquirierungsServiceModels.Surgeries.SurgeryData;

namespace DatenakquirierungsServiceModels.Surgeries
{
    public class GastricBypassSurgery : ASurgery
    {
        public GastricBypassSurgeryData surgeryData { get; set; }
    }
}
