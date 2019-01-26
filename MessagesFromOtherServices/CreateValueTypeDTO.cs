using System;
using System.Collections.Generic;
using System.Text;

namespace DatentransformationsServiceMessages
{
    public interface CreateValueTypeDTO : ADTO
    {
        string name { get; }
        string unit { get; }
        double maxValue { get; }
        double minValue { get; }
    }
}
