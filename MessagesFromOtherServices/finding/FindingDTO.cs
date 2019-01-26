using System;
using System.Collections.Generic;
using System.Text;
using DatentransformationsServiceModels.Findings;

namespace DatentransformationsServiceMessages.finding
{
    public interface FindingDTO : ADTO
    {
        Finding fidning { get; set; }
    }
}
