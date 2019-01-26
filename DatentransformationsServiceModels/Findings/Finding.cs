using System;
using System.Collections.Generic;
using System.Text;

namespace DatentransformationsServiceModels.Findings
{
    public class Finding : AEntity
    {
        public FindingType type { get; set; }
        public DateTime timestamp { get; set; }
    }
}
