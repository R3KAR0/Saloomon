using System.Collections.Generic;

namespace DatenakquirierungsServiceModels.Surgeries.AccompanyingSurgeryData
{
    public abstract class AAccompanyingSurgeryData : AEntity
    {
        public List<string> accompanyingSurgeries { get; set; }
        public string otherAccompanyingSurgeries { get; set; }
    }
}
