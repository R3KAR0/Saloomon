using System;
using System.Collections.Generic;
using System.Text;

namespace DatenakquirierungsServiceModels.FollowUps.Complications
{
    public class MortalityData : AEntity
    {
        public bool mortality30d { get; set; }

        public bool kuPflichtig { get; set; }

        public int lengthOfStay { get; set; }

        public string causeOfDeath { get; set; }

        public DateTime date { get; set; }
    }
}
