using System;
using System.Collections.Generic;
using System.Text;
using DatenakquirierungsServiceModels.FollowUps.Complications;

namespace DatenakquirierungsServiceModels.FollowUps
{
    public class ComplicationSurgeryData : AFollowUp
    {
        public AComplicationData complicationData { get; set; }
        public GenericComplications genericComplications { get; set; }
        public PostoperativeComplications postopverativeComplications { get; set; }
        public MortalityData mortalityData { get; set; }
    }
}
