using System;
using System.Collections.Generic;
using System.Text;
using DatenakquirierungsServiceModels.Surgeries.SurgeryData;

namespace DatenakquirierungsServiceModels.Surgeries
{
    public class SADI_SSurgery : ASurgery
    {
        public SADI_SSurgeryData surgeryData { get; set; }
    }
}
