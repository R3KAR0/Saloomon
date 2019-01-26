using System;
using System.Collections.Generic;
using System.Text;
using DatenakquirierungsServiceModels.Surgeries.SurgeryData;

namespace DatenakquirierungsServiceModels.Surgeries
{
    public class BDPSurgery : ASurgery
    {
        public BDPSurgeryData surgeryData { get; set; }
    }
}
