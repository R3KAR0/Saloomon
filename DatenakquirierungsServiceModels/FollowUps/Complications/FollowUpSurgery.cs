using System;
using System.Collections.Generic;
using System.Text;
using DatenakquirierungsServiceModels.Surgeries.PreviousSurgeryData;

namespace DatenakquirierungsServiceModels.FollowUps.Complications
{
    public class FollowUpSurgery : PreviousSurgery
    {
        public string hospital { get; set; }
    }
}
