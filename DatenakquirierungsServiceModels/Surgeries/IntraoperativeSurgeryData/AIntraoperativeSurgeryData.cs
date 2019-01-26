using System.Collections.Generic;

namespace DatenakquirierungsServiceModels.Surgeries.IntraoperativeSurgeryData
{
    public abstract class AIntraoperativeComorbiditiesData : AEntity
    {
        public Dictionary<string, bool> comorbidities { get; set; }
        public string otherComorbidities { get; set; }

    }
}
