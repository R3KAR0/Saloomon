using System.Collections.Generic;

namespace DatenakquirierungsServiceModels.Surgeries.PreviousSurgeryData
{
    public abstract class APreSurgeryData : AEntity
    {
        public Dictionary<string, bool> previousBariatricSurgeries { get; set; }
        public List<PreviousSurgery> previousSurgeries { get; set; }
        private string otherPreviousSurgeries { get; set; }
        private string studyParticipation { get; set; }
    }
}
