using System;
using System.Collections.Generic;
using System.Text;

namespace DatenakquirierungsServiceModels.Surgeries.SurgeryData
{
    public class ASurgeryData : AEntity
    {
        public string country { get; set; }
        public string hospital { get; set; }
        public float cutSeamTime { get; set; }
        public string access { get; set; }
    }
}
