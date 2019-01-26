using System;
using System.Collections.Generic;
using System.Text;
using DatentransformationsServiceModels.Findings;

namespace DatentransformationsServiceMessages
{
    public interface GetFindingTypeDTO : ADTO
    {
        FindingType findingType { get; }
    }
}
