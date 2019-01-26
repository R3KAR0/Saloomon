using System;
using System.Collections.Generic;
using System.Text;

namespace DatenakquirierungsServiceModels.FollowUps.Complications
{
    public abstract class AComplicationData : AEntity
    {
        public bool morbidity { get; set; }

        public bool stationaryResumption { get; set; }

        public DateTime stationaryResumptionBegin { get; set; }

        public DateTime stationaryResumptionEnd { get; set; }

        public int daysPostSurgery { get; set; }

        public int lieDuration { get; set; }

    }
}
