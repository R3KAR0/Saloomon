using System;
using System.Collections.Generic;
using System.Text;
using DatentransformationsServiceModels.Findings;

namespace DatentransformationsServiceMessages.valueGroup
{
    public interface CreateValueGroupDTO : ADTO
    {
        ValueGroup valueGroup { get; }
    }
}
